using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infinit.ApiClient
{
    public class APIClientResult
    {
        public object Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class APIClientParametro
    {
        public APIClientParametro(string Nome, string Valor)
        {
            this.Nome = Nome;
            this.Valor = Valor;
        }
        public string Nome { get; set; }
        public string Valor { get; set; }
    }
    public class APIClient
    {
        public async Task<APIClientResult> GetJSON(string URI, List<APIClientParametro> parametros, Type deserializeObjectType, string authorization = null)
        {
            var uriComParametros = new StringBuilder();
            uriComParametros.Append(URI);
            if (parametros != null)
            {
                var parametroId = parametros.FirstOrDefault(p => p.Nome.ToUpper() == "ID");
                if (parametroId != null)
                {
                    uriComParametros.AppendFormat("{0}", parametroId.Valor);
                }
                var parateosSemId = parametros.Where(p => p.Nome.ToUpper() != "ID").ToList();
                for (int i = 0; i < parateosSemId.Count; i++)
                {
                    if (i == 0)
                        uriComParametros.Append("?");
                    uriComParametros.AppendFormat("{0}{1}={2}", i > 0 ? "&" : string.Empty, parateosSemId[i].Nome, parateosSemId[i].Valor);
                }
            }
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authorization);
            }
            var result = client.GetAsync(uriComParametros.ToString()).Result;
            var contents = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.NotAcceptable)
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
            else
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, deserializeObjectType);
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
        }
        public async Task<APIClientResult> GetJSON(string URI, long id, Type deserializeObjectType, string authorization)
        {
            var uriComParametros = new StringBuilder();
            uriComParametros.Append(URI);
            uriComParametros.AppendFormat("{0}", id);
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Net.WebUtility.UrlDecode(authorization));
            }
            var result = await client.GetAsync(uriComParametros.ToString());
            var contents = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.NotAcceptable)
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
            else
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, deserializeObjectType);
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
        }
        public async Task<APIClientResult> GetJSON(string URI, string id, Type deserializeObjectType, string authorization)
        {
            var uriComParametros = new StringBuilder();
            uriComParametros.Append(URI);
            uriComParametros.AppendFormat("{0}", id);
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Net.WebUtility.UrlDecode(authorization));
            }
            var result = await client.GetAsync(uriComParametros.ToString());
            var contents = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.NotAcceptable)
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
            else
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, deserializeObjectType);
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
        }
        public async Task<APIClientResult> PostarJSON(string URI, object objetoASerPostado, string authorization = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Net.WebUtility.UrlDecode(authorization));
            }
            string jsonText = JsonConvert.SerializeObject(objetoASerPostado);

            var result = await client.PostAsync(URI, new StringContent(jsonText, Encoding.UTF8, "application/json"));
            var contents = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.NotAcceptable)
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
            else
            {
                return new APIClientResult() { Result = null, StatusCode = result.StatusCode };
            }
        }
        public async Task<APIClientResult> PostarJSON(string URI, object objetoASerPostado, Type deserializeObjectType, string authorization = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Net.WebUtility.UrlDecode(authorization));
            }
            string jsonText = JsonConvert.SerializeObject(objetoASerPostado);

            var result = await client.PostAsync(URI, new StringContent(jsonText, Encoding.UTF8, "application/json"));
            var contents = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.NotAcceptable)
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
            else
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, deserializeObjectType);
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
        }
        public async Task<APIClientResult> PutJSON(string URI, object objetoASerPostado, Type deserializeObjectType, string authorization = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Net.WebUtility.UrlDecode(authorization));
            }
            string jsonText = JsonConvert.SerializeObject(objetoASerPostado);

            try
            {
                var result = client.PutAsync(URI, new StringContent(jsonText, Encoding.UTF8, "application/json")).Result;
                var contents = await result.Content.ReadAsStringAsync();
                if (result.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                    return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
                }
                else
                {
                    var resultDeserialized = JsonConvert.DeserializeObject(contents, deserializeObjectType);
                    return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
                }
            }
            catch (Exception)
            {

                return null;
            }

        }
        public async Task<APIClientResult> DeletarJSON(string URI, long idASerDeletado, Type deserializeObjectType, string authorization = "")
        {

            var uriComParametros = URI.EndsWith("/") ? string.Format("{0}{1}", URI, idASerDeletado) : string.Format("{0}/{1}", URI, idASerDeletado);

            var client = new HttpClient();
            if (!string.IsNullOrEmpty(authorization))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Net.WebUtility.UrlDecode(authorization));
            }

            var result = await client.DeleteAsync(uriComParametros.ToString());
            var contents = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.NotAcceptable)
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, typeof(MensagemErro));
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
            else
            {
                var resultDeserialized = JsonConvert.DeserializeObject(contents, deserializeObjectType);
                return new APIClientResult() { Result = resultDeserialized, StatusCode = result.StatusCode };
            }
        }
    }
}
