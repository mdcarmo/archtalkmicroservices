using GatewayApi.Models;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace GatewayApi.Aggregators
{
    public class CustomerWithOrdersAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<DownstreamResponse> responses)
        {
            var customerWithOrders = responses[0].Content.ReadAsAsync<CustomerWithOrders>().Result;
            customerWithOrders.Orders = responses[1].Content.ReadAsAsync<List<Order>>().Result;

            HttpResponseMessage response = new HttpResponseMessage();

            response.Content = new ObjectContent<CustomerWithOrders>(customerWithOrders, new JsonMediaTypeFormatter());

            return Task.FromResult(new DownstreamResponse(response));
        }
    }
}
