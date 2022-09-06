using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Common.HttpClientHelpers
{
    public static class CallApiHelper
    {
        public static async Task<T> GetAsync<T>(string url, string requestUrl, string mediaType, string bearer) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    //GET Method
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(result);
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task<HttpResponseMessage> PostAsync(string url, string requestUrl, IFormCollection dataContent, string bearer)
        {
            try
            {
                MultipartFormDataContent mpfdc = new MultipartFormDataContent();
                foreach (var item in dataContent)
                {
                    mpfdc.Add(new StringContent(item.Value), item.Key);
                }
                foreach (var item in dataContent.Files)
                {
                    //mpfdc.Add(new StreamContent(item), item.Key);
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                    return await client.PostAsync(requestUrl, mpfdc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<HttpResponseMessage> PutAsync(string url, string requestUrl, IFormCollection dataContent, string bearer)
        {
            try
            {
                MultipartFormDataContent mpfdc = new MultipartFormDataContent();
                foreach (var item in dataContent)
                {
                    mpfdc.Add(new StringContent(item.Value), item.Key);
                }
                foreach (var item in dataContent.Files)
                {
                    //mpfdc.Add(new StreamContent(item), item.Key);
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                    return await client.PutAsync(requestUrl, mpfdc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<HttpResponseMessage> PostAsync(string url, string requestUrl, MultipartFormDataContent mpfdc, string bearer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                    return await client.PostAsync(requestUrl, mpfdc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<HttpResponseMessage> PutAsync(string url, string requestUrl, MultipartFormDataContent mpfdc, string bearer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                    return await client.PutAsync(requestUrl, mpfdc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<HttpResponseMessage> DeleteAsync(string url, string requestUrl, string bearer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                    return await client.DeleteAsync(requestUrl);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}