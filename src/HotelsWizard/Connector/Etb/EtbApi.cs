
using System;
using System.Net.Http;

using HotelsWizard.Models.Request;
using HotelsWizard.Models.Response;
using HotelsWizard.Models.Search;

using HotelsWizard.Connector.Etb.Utils;
using HotelsWizard.Connector;

using System.Net;
using System.Threading.Tasks;
using System.IO;


using Microsoft.Extensions.Logging;
using HotelsWizard.Connector.Rest;
using Newtonsoft.Json;

namespace HotelsWizard.Connector.Etb
{

    /**
     * @author alex
     * @date 2015-04-19
     */
    public class EtbApi : IConnector {
        const string PATH_ACCOMMODATIONS = "/v1/accommodations";
        const string PATH_SEARCH = PATH_ACCOMMODATIONS + "/results";
        const string PATH_ORDERS = "/v1/orders";

        const int LIMIT = 15;
        private RestClient RestClient;

        private EtbApiConfig Config;

        private ILogger _logger;
        public ILogger Logger {
            get { return _logger; }
            set { _logger = value; }
        }

        enum RetrieveType { OrderId, ConfirmationId, AffiliateConfirmationId };

        const string DATE_FORMAT = "yyyy-MM-dd";
        
        public EtbApi(String apiKey, int campaignId) : this(new EtbApiConfig(apiKey, campaignId), null)
        {
        }

        public EtbApi(EtbApiConfig config) : this(config, null)
        {
        }

        public EtbApi(EtbApiConfig config, HttpClient httpClient)
        {
            Config = config;
            RestClient = new RestClient(config.Endpoint, httpClient == null ? new HttpClient() : httpClient);
            //mHttpClient.interceptors().add(0, mRequestInterceptor);
        }


        public async Task<SearchResponse> Search(SearchRequest searchRequest) { 
             return await Search(searchRequest, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <param name="offset"></param>
        /// <exception cref="ResponseException">Throws when no valid response found</exception>
        /// <returns></returns>
        public async Task<SearchResponse> Search(SearchRequest searchRequest, int offset)
        {

            var query = HotelsRequestToQuery(searchRequest);

            // Location
            var context = searchRequest.Context;
            if (context == null)
            {
                throw new ArgumentException("Context canot be nul");
            }
            query.Add("type", context.Value);
            query.Add("context", context.GetContext());


            // Filters
            if (searchRequest.HaveFilter())
            {
                Filter filter = searchRequest.Filter;

                if (filter.Stars != null)
                {
                    query.Add("stars", RequestUtils.list(filter.Stars));
                }
                if (filter.Rating != null)
                {
                    query.Add("rating", RequestUtils.list(filter.Rating));
                }
                if (filter.AccTypes != null)
                {
                    query.Add("accTypes", RequestUtils.list(filter.AccTypes));
                }
                if (filter.MinRate > 0)
                {
                    query.Add("minRate", filter.MinRate.ToString());
                }
                if (filter.MaxRate > 0)
                {
                    query.Add("maxRate", filter.MaxRate.ToString());
                }
                if (filter.MainFacilities != null)
                {
                    query.Add("mainFacilities", RequestUtils.list(filter.MainFacilities));
                }
            }
            // Limit
            if (searchRequest.Context is ListType)
            {
                query.Add("limit", "999");
                query.Add("offset", "0");
            }
            else
            {
                query.Add("limit", LIMIT.ToString());
                query.Add("offset", offset.ToString());
            }

            // Sort
            var sort = searchRequest.SortType;
            if (sort != null)
            {
                // TODO: do not use split
                String[] sortStr = sort.Split('_');
                query.Add("orderBy", sortStr[0]);
                if (sortStr.Length > 1)
                {
                    query.Add("order", sortStr[1]);
                }
            }

            query.Add("metaFields", "all"); // full = This also includes the field filterNrs


            return await Search(query);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <exception cref="ResponseException">Throws when no valid response found</exception>
        /// <returns></returns>
        public async Task<SearchResponse> Search(QueryCollection query)
        {
            query["apiKey"] = Config.ApiKey;
            query["campaignId"] = Config.CampaignId.ToString();
            return await RestClient.Get<SearchResponse>(PATH_SEARCH, query);
        }

        public async Task<DetailsResponse> Details(int id, HotelRequest hotelRequest) {
            var query = HotelsRequestToQuery(hotelRequest);
            return await Details(id, query);
        }

        public async Task<DetailsResponse> Details(int id, QueryCollection query) {
            query["apiKey"] = Config.ApiKey;
            query["campaignId"] = Config.CampaignId.ToString();
            return await RestClient.Get<DetailsResponse>(PATH_ACCOMMODATIONS + '/' + id, query);
        }

        public async Task<RatesResponse> Rates(int id, HotelRequest hotelRequest) {
            var query = HotelsRequestToQuery(hotelRequest);
            return await Rates(id, query);
        }

        public async Task<RatesResponse> Rates(int id, QueryCollection query) {
            query["apiKey"] = Config.ApiKey;
            query["campaignId"] = Config.CampaignId.ToString();
            return await RestClient.Get<RatesResponse>(PATH_ACCOMMODATIONS + '/' + id + "/rates", query);
        }

        private QueryCollection HotelsRequestToQuery(HotelRequest request) {
            QueryCollection query = new QueryCollection();
            query.Add("currency", request.Currency);
            query.Add("language", request.Language);

            // Availability
            if (request.NumberOfPersons != 0 && request.NumberOfRooms != 0) {
                query.Add("capacity", RequestUtils.capacity(request.NumberOfPersons, request.NumberOfRooms));
            }
            if (request.DateRange != null) {
                query.Add("checkIn", request.DateRange.From.ToString(DATE_FORMAT));
                query.Add("checkOut", request.DateRange.To.ToString(DATE_FORMAT));
            }
            query.Add("customerCountryCode", request.CustomerCountryCode);

            return query;
        }

        public async Task<OrderResponse> Order(OrderRequest request) {
            return await Order(new JsonContent(request));
        }

        public async Task<OrderResponse> Order(HttpContent request) {
            QueryCollection query = new QueryCollection();
            query["apiKey"] = Config.ApiKey;
            query["campaignId"] = Config.CampaignId.ToString();
            return await RestClient.Post<OrderResponse>(PATH_ORDERS, query, request);
        }

        //public async Task<CancelResponse> Cancel(CancelRequest request, String orderId, String rateId) {
        //     Sasync ervice service = create(true);
        //     return service.cancel(request, orderId, rateId);
        //}

        public async Task<OrderResponse> Retrieve(String confirmationId, String password) {
            QueryCollection query = new QueryCollection();
            if (password != null) {
                query.Add("password", password);
            }
            return await Retrieve(confirmationId, RetrieveType.ConfirmationId, query);
        }

        public async Task<OrderResponse> Retrieve(int orderId, String password) {
            QueryCollection query = new QueryCollection();
            if (password != null) {
                query.Add("password", password);
            }
            return await Retrieve(orderId.ToString(), RetrieveType.OrderId, query);
        }

        private async Task<OrderResponse> Retrieve(String id, RetrieveType type, QueryCollection query) {
            query["apiKey"] = Config.ApiKey;
            query["campaignId"] = Config.CampaignId.ToString();

            var path = "";
            if (type == RetrieveType.OrderId) {
                path = id;
            } else if (type == RetrieveType.ConfirmationId) {
                path = "B-" + id;
            } else if (type == RetrieveType.AffiliateConfirmationId) {
                path = "confirmation/" + id;
            }

            return await RestClient.Get<OrderResponse>(PATH_ORDERS+'/'+path, query);
        }

       


        //     @POST(PATH_ORDERS + "/")
        //     Call<OrderResponse> order(@Body OrderRequest request);

        //     @POST(PATH_ORDERS + "/{orderId}/rates/{rateId}/cancel")
        //     Call<CancelResponse> cancel(@Body CancelRequest request, @Path("orderId") String orderId, @Path("rateId") String rateId);

    }
}