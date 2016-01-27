using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BerlinClockHcl.Demo.Controllers
{
    public class BerlinClockController : ApiController
    {
        public string Get(string time)
        {
            ITimeConverter timeConverter = new TimeConverter();
            return timeConverter.ConvertTime(time);
        }
    }
}