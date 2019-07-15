using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkRedirect.Interface;
using LinkRedirect.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LinkRedirect.Controllers {
    [Route("[controller]")]
    public class LinkController : Controller {
        private readonly IKVDB db;
        public LinkController(IKVDB db) {
            this.db = db;
        }

        // GET: <controller>
        [HttpGet]
        public IActionResult Get(string link) {
            var hash = HashHelper.Hash_SHA_256(link, false);
            db.Put(hash, link);
            return Redirect("https://i.miaostay.com/"+hash+".jpg");
            // return new string[] { hash, link };
        }
    }
}
