using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UberEats_RespAPI.Models;

namespace UberEats_RespAPI.Controllers
{
    public class BaseAPIControllerController : ApiController
    {
        protected readonly UberEatsEntitiesApi db = new UberEatsEntitiesApi();

        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }
    }
}
