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
using TesteMutant.Model;

namespace TestMutantFronEnd.Controllers
{
    public class PedidoController : Controller
    {
        public IHttpClientFactory _HttpClientFactory;
        private readonly AsyncRetryPolicy _retryPolicy;

        public PedidoController(IHttpClientFactory HttpClientFactory)
        {
            _retryPolicy = Policy.Handle<HttpRequestException>().WaitAndRetryAsync(3, times => TimeSpan.FromSeconds(10));
            _HttpClientFactory = HttpClientFactory;
        }

        public IActionResult Pedido()
        {
            return View();
        }

        public async Task<IActionResult> AbrirPedido()
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/pedido/abrirpedido");

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

        public async Task<IActionResult> ListarLanches()
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/lanche");

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

        public async Task<IActionResult> ListarPedidosAbertos()
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/pedido/pedidosabertos");

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

        public async Task<IActionResult> ListarIngredientesLanche(int id)
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/lanche/buscaringredientes/" + id);

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

        public async Task<IActionResult> InserirItemPedido([FromBody]ItemPedidoModel itemPedido)
        {
            try
            {
                var httpClient = _HttpClientFactory.CreateClient("MyHttpClient");
                httpClient.BaseAddress = new Uri("http://localhost:5100/v1/itempedido");

                var jsonContent = JsonConvert.SerializeObject(itemPedido);
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
