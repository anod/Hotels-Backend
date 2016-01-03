
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;

using HotelsWizard.Models.Request;
using HotelsWizard.Models.Response;
using HotelsWizard.Models.Search;

using HotelsWizard.Connector.Etb.Utils;

using System;
using System.Net;
using System.Net.Http;
using System.IO;
//using System.Net.Http.Formatting;

using Newtonsoft.Json;

namespace HotelsWizard.Connector.Etb
{

    /**
     * @author alex
     * @date 2015-04-19
     */
    public class EtbApi
    {
        const string PATH_ACCOMMODATIONS = "/v1/accommodations";
        const string PATH_SEARCH = PATH_ACCOMMODATIONS + "/results";
        const string PATH_ORDERS = "/v1/orders";

        const int LIMIT = 15;
        private HttpClient HttpClient;

        private EtbApiConfig Config;

        const string DATE_FORMAT = "yyyy-MM-dd";
        //private SimpleDateFormat DateFormat = new SimpleDateFormat(, Locale.US);

        // private Interceptor mRequestInterceptor = new Interceptor() {
        //     @Override
        //     public Response intercept(Chain chain) throws IOException {
        //         Request request = chain.request();

        //         HttpUrl url = request.httpUrl().newBuilder()
        //                 .addQueryParameter("apiKey", mConfig.getApiKey())
        //                 .addQueryParameter("campaignId", String.valueOf(mConfig.getCampaignId()))
        //                 .build();


        //         return chain.proceed(request.newBuilder().url(url).build());
        //     }
        // };

        public EtbApi(String apiKey, int campaignId) : base((new EtbApiConfig(apiKey, campaignId), null)
        {
        }

        public EtbApi(EtbApiConfig config) : base(config, null)
        {
        }

        public EtbApi(EtbApiConfig config, HttpClient httpClient)
        {
            Config = config;
            HttpClient = httpClient == null ? new HttpClient() : httpClient;
            //mHttpClient.interceptors().add(0, mRequestInterceptor);
        }


        // private Service create(bool isSecure) {
        //     Retrofit.Builder builder = new Retrofit.Builder()
        //             .client(mHttpClient)
        //             .addConverterFactory(GsonConverterFactory.create())
        //             .baseUrl(isSecure ? mConfig.getSecureEndpoint() : mConfig.getEndpoint());

        //     Retrofit restAdapter = builder.build();

        //     return restAdapter.create(Service.class);
        // }

        // public Call<ResultsResponse> results(SearchRequest searchRequest) throws InvalidParameterException {
        //     return results(searchRequest, 0);
        // }

        public SearchResponse results(SearchRequest searchRequest, int offset)
        {

            StringDictionary query = new StringDictionary();

            // Location
            ContextType loc = searchRequest.Context;
            if (loc == null)
            {
                throw new InvalidParameterException();
            }
            query.Add("type", loc.Value);
            query.Add("context", loc.GetContext());

            query.Add("currency", searchRequest.Currency);
            query.Add("language", searchRequest.Language);

            // Availability
            if (searchRequest.NumberOfPersons != 0 && searchRequest.NumberOfRooms != 0)
            {
                query.Add("capacity", RequestUtils.capacity(searchRequest.NumberOfPersons, searchRequest.NumberOfRooms));
            }
            if (searchRequest.DateRange != null)
            {
                query.Add("checkIn", searchRequest.DateRange.From.ToString(DATE_FORMAT));
                query.Add("checkOut", searchRequest.DateRange.To.ToString(DATE_FORMAT));
            }

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
                String[] sortStr = sort.Split('_');
                query.Add("orderBy", sortStr[0]);
                if (sortStr.Length > 1)
                {
                    query.Add("order", sortStr[1]);
                }
            }

            query.Add("metaFields", "all"); // full = This also includes the field filterNrs

            query.Add("customerCountryCode", searchRequest.CustomerCountryCode);

            return request<SearchResponse>();
        }

        private async T request<T>(String path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Config.Endpoint);
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetAsync(Config.Endpoint + path);
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    using (StreamReader sr = new StreamReader(stream))
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        T responseObject = serializer.Deserialize<T>(reader);
                        return responseObject;
                    }
                }
                else if (response.StatusCode < HttpStatusCode.InternalServerError)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    using (StreamReader sr = new StreamReader(stream))
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        ErrorResponse errorObject = serializer.Deserialize<ErrorResponse>(reader);
                        throw new ResponseException(errorObject);
                    }
                }
                else
                {
                    ErrorResponse errorObject = new ErrorResponse();
                    errorObject.Meta = new ErrorMeta((int)response.StatusCode, 0, "Generic error has occurred on the server.");
                    throw new ResponseException(errorObject);
                }


            }
        }

        interface IConnectorResult
        {

        }

        // public Call<DetailsResponse> details(int id, HotelRequest hotelRequest) {
        //     Service service = create(false);
        //     ArrayMap<String, String> query = new ArrayMap<>();
        //     query.put("capacity", RequestUtils.capacity(hotelRequest.getNumberOfPersons(), hotelRequest.getNumberOfRooms()));
        //     if (hotelRequest.getDateRange() != null) {
        //         query.put("checkIn", mDateFormat.format(hotelRequest.getDateRange().from.getTime()));
        //         query.put("checkOut", mDateFormat.format(hotelRequest.getDateRange().to.getTime()));
        //     }
        //     query.put("currency", hotelRequest.getCurrency());
        //     query.put("language", hotelRequest.getLanguage());

        //     query.put("customerCountryCode", hotelRequest.getCustomerCountryCode());

        //     return service.details(id, query);
        // }

        // public Call<OrderResponse> order(OrderRequest request) {
        //     Service service = create(true);
        //     return service.order(request);
        // }

        // public Call<CancelResponse> cancel(CancelRequest request, String orderId, String rateId) {
        //     Service service = create(true);
        //     return service.cancel(request, orderId, rateId);
        // }

        // public Call<OrderResponse> retrieve(String orderId, String password) {
        //     Service service = create(true);
        //     Map<String, String> query = new HashMap<>();
        //     if (password != null) {
        //         query.put("password", password);
        //     }
        //     return service.retrieve(orderId, query);
        // }


        // public interface Service {

        //     @GET(PATH_SEARCH)
        //     Call<ResultsResponse> results(@QueryMap Map<String, String> query);

        //     @GET(PATH_ACCOMMODATIONS + "/{id}")
        //     Call<DetailsResponse> details(@Path("id") int id, @QueryMap Map<String, String> query);

        //     @POST(PATH_ORDERS + "/")
        //     Call<OrderResponse> order(@Body OrderRequest request);

        //     @POST(PATH_ORDERS + "/{orderId}/rates/{rateId}/cancel")
        //     Call<CancelResponse> cancel(@Body CancelRequest request, @Path("orderId") String orderId, @Path("rateId") String rateId);

        //     @GET(PATH_ORDERS + "/{orderId}")
        //     Call<OrderResponse> retrieve(@Path("orderId") String orderId, @QueryMap Map<String, String> query);
        // }

    }
}