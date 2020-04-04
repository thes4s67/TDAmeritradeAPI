using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TDAmeritradeAPI.Props;

namespace TDAmeritradeAPI.Client
{
    public partial class TDClient
    {
        private RestRequest _request;
        private RestClient _client;
        private string AccessToken { get; }
        private string ClientId { get; }
        public TDClient(string accessToken)
        {
            AccessToken = accessToken;
        }

        private async Task<TDResponse<T>> ExecuteEndPoint<T>(string endPoint, Dictionary<string, object> requestParams, Method method)
        {
            var instance = (TDResponse<T>)Activator.CreateInstance(typeof(TDResponse<T>));
            _client = new RestClient(endPoint);
            _request = new RestRequest(method);
            _request.AddHeader("Authorization", $"Bearer {AccessToken}");

            if (requestParams != null)
            {
                foreach (var p in requestParams)
                {
                    //TODO: Review != 0
                    if (p.Value != null)
                    {
                        _request.AddParameter(p.Key, p.Value);
                    }
                }
            }

            var response = _client.Execute(_request);
            var result = JsonConvert.DeserializeObject<T>(response.Content);
            instance.Data = result;
            return instance;
        }

        private async Task<TDResponse<T>> ExecuteEndPoint<T>(string endPoint, object settings, Method method)
        {
            var instance = (TDResponse<T>)Activator.CreateInstance(typeof(TDResponse<T>));
            _client = new RestClient(endPoint);
            _request = new RestRequest(method);
            _request.AddHeader("Authorization", $"Bearer {AccessToken}");
            settings = JsonConvert.SerializeObject(settings, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _request.AddJsonBody(settings);
            var response = _client.Execute(_request);
            var result = JsonConvert.DeserializeObject<T>(response.Content);
            instance.Success = response.IsSuccessful;
            instance.Data = result;
            instance.Error = response.ErrorMessage;
            return instance;
        }

    }
}
