using HaloInfiniteMobileApp.Interfaces;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Polly;
using Newtonsoft.Json;
using HaloInfiniteMobileApp.Exceptions;

namespace HaloInfiniteMobileApp.Repository;

public class GenericRepository : IGenericRepository
{
    public async Task<T> GetAsync<T>(string uri, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(authToken);
            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.GetAsync(uri));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult =
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<T> PostAsync<T>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(authToken);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

        }
        catch (Exception e)
        {
            Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(authToken);
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
            .Handle<WebException>(ex =>
            {
                Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                return true;
            })
            .WaitAndRetryAsync
            (
                5,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            )
            .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TR>(jsonResult);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<T> PutAsync<T>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(authToken);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PutAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

        }
        catch (Exception e)
        {
            Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task DeleteAsync(string uri, string authToken = "")
    {
        HttpClient httpClient = CreateHttpClient(authToken);
        await httpClient.DeleteAsync(uri);
    }

    private HttpClient CreateHttpClient(string authToken)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (!string.IsNullOrEmpty(authToken))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        }
        return httpClient;
    }
}
