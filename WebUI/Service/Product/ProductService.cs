
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebUI.Models;

namespace WebUI.Service.Account
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(HttpClient httpClient,IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> GetProductList()
        {
           
          //  AddToken(_httpClient);
           
            var response = await _httpClient.GetAsync("Product/List");

            return response;

        }

        public void AddToken(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "JwtToken").Value);

        }

        private string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return "?" + string.Join("&", properties.ToArray());
        }
    }
}
