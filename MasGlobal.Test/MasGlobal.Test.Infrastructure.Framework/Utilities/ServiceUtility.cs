using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MasGlobal.Test.Infrastructure.Framework.Utilities
{
    public class ServiceUtility<T>
    {
        public static T HttpGet(string url)
        {
            try
            {
                T entity = default(T);

                using (var client = new HttpClient())
                {        
                    var result = client.GetAsync(url).Result;

                    if (result.StatusCode != HttpStatusCode.OK)
                    {
                        return default(T);
                    }

                    entity = JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);

                    //}

                    return entity;
                }
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                throw new Exception("An error occurred, status code: " + statusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
