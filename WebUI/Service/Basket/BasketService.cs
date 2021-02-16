using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Helper;

namespace WebUI.Service.Basket
{
    public class BasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISessionManager _sessionManager;

        public BasketService(ISessionManager sessionManager, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _sessionManager = sessionManager;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
