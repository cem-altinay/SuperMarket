using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Helper
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Checks for existence of specified key in session.
        /// </summary>
        /// <param name="key">Name of item</param>
        /// <returns></returns>
        public bool IsExists(string key)
        {
            return _httpContextAccessor.HttpContext.Session.Get(key) != null;
        }

        /// <summary>
        /// Insert value into the session.
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="key">Name of item</param>
        /// <param name="value">Value of the item</param>
        public void Add<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Retrieve item in the session for the given name.
        /// </summary>
        /// <typeparam name="T">Type of stored item</typeparam>
        /// <param name="key">Name of stored item</param>
        /// <param name="value">Stored value. Default(T) if item doesn't exist.</param>
        public bool CheckGet<T>(string key, out T value)
        {
            if (IsExists(key))
            {
                var obj = _httpContextAccessor.HttpContext.Session.GetString(key);
                value = string.IsNullOrEmpty(obj) == true ? default : JsonConvert.DeserializeObject<T>(obj);
                return true;
            }

            value = default(T);
            return false;
        }

        /// <summary>
        /// Try to retrieve item from session, if it doesn't exist get it via
        /// getter function and write it to session.
        /// </summary>
        /// <typeparam name="T">Type of the stored item</typeparam>
        /// <param name="key">Name of the item</param>
        /// <param name="getter">Getter function in the case of particular session item is empty.</param>
        /// <returns></returns>
        public T GetOrAdd<T>(string key, Func<T> getter)
        {
            T value;

            if (!CheckGet(key, out value))
            {
                value = getter();
            }
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
            return Get<T>(key);
        }

        /// <summary>
        /// Try to retrieve item from session, if it doesn't exist set value
        /// to session and returns it.
        /// </summary>
        /// <typeparam name="T">Type of the stored item</typeparam>
        /// <param name="key">Name of the item</param>
        /// <param name="value">Value for the case of particular session item is empty.</param>
        /// <returns></returns>
        public T GetOrAdd<T>(string key, T value)
        {
            if (IsExists(key))
            {
                value = Get<T>(key);
            }
            else
            {
                Set(key, value);
            }

            return value;
        }

        /// <summary>
        /// Retrieve item in the session for the given name.
        /// </summary>
        /// <typeparam name="T">Type of stored item</typeparam>
        /// <param name="key">Name of stored item</param>
        public T Get<T>(string key)
        {
            var obj = _httpContextAccessor.HttpContext.Session.GetString(key);
            return JsonConvert.DeserializeObject<T>(obj);
        }

        /// <summary>
        /// Puts given object to session with the given key.
        /// </summary>
        /// <param name="key">Session key of the object</param>
        /// <param name="source">Object to be stored</param>
        public void Set(string key, object source)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(source));
        }

        /// <summary>
        /// Remove cache for the given key.
        /// </summary>
        /// <param name="key">Name of item</param>
        /// <returns></returns>
        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        /// <summary>
        /// Clear the session keys and values.
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();        
        }
    
    }
}
