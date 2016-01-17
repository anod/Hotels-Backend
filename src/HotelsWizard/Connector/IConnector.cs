using HotelsWizard.Connector.Etb.Utils;
using HotelsWizard.Models.Request;
using HotelsWizard.Models.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsWizard.Connector
{
    public interface IConnector {
        ILogger Logger { set; get; }

        Task<SearchResponse> Search(SearchRequest searchRequest);
        Task<SearchResponse> Search(QueryCollection query);
        Task<SearchResponse> Search(SearchRequest searchRequest, int offset);

        Task<DetailsResponse> Details(int id, HotelRequest hotelRequest);
        Task<DetailsResponse> Details(int id, QueryCollection query);

        Task<RatesResponse> Rates(int id, HotelRequest hotelRequest);
        Task<RatesResponse> Rates(int id, QueryCollection query);

        Task<OrderResponse> Retrieve(String confirmationId, String password);
        Task<OrderResponse> Retrieve(int orderId, String password);
    }
}
