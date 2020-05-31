using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace TestMutantFronEnd.Controllers
{
    public class FecharPedidoController : Controller
    {
        public IHttpClientFactory _HttpClientFactory;
        private readonly AsyncRetryPolicy _retryPolicy;

        public FecharPedidoController(IHttpClientFactory HttpClientFactory)
        {
            _retryPolicy = Policy.Handle<HttpRequestException>().WaitAndRetryAsync(3, times => TimeSpan.FromSeconds(10));
            _HttpClientFactory = HttpClientFactory;
        }

        public IActionResult FecharPedido()
        {
            return View();
        }

        public async Task<IActionResult> ListarItensPedido(int id)
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/itempedido/" + id);

                return await _retryPolicy.ExecuteAsync(async () =>
                {
                    HttpResponseMessage response = await httpClient.GetAsync("");

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw (new Exception(response.StatusCode.ToString()));
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return Ok(content);
                    }
                });

            }
            catch (HttpRequestException ex)
            {
                throw (ex);
            }
        }

        public async Task<IActionResult> FecharPedidoCliente(int id)
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/pedido/fecharpedido/" + id);

                var jsonContent = JsonConvert.SerializeObject("");
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return await _retryPolicy.ExecuteAsync(async () =>
                {
                    HttpResponseMessage response = await httpClient.PutAsync("", contentString);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw (new Exception(response.StatusCode.ToString()));
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return Ok(content);
                    }
                });

            }
            catch (HttpRequestException ex)
            {
                throw (ex);
            }
        }

        public async Task<IActionResult> AplicarPromocao(int id)
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/pedido/aplicarpromocao/" + id);

                var jsonContent = JsonConvert.SerializeObject("");
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return await _retryPolicy.ExecuteAsync(async () =>
                {
                    HttpResponseMessage response = await httpClient.PostAsync("", contentString);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw (new Exception(response.StatusCode.ToString()));
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return Ok(content);
                    }
                });

            }
            catch (HttpRequestException ex)
            {
                throw (ex);
            }
        }
    }
}
