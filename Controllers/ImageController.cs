using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LinkRedirect.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinkRedirect.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase {
        private readonly IKVDB db;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger _logger;
        public ImageController(IKVDB db, IHttpClientFactory clientFactory, ILogger<ImageController> logger) {
            this.db = db;
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<byte[]> Crawl(string url) {
            _logger.LogInformation(url);
            _logger.LogError("Crawl: "+url);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            // var stream = new MemoryStream();
            return await response.Content.ReadAsByteArrayAsync();
            // return stream;
        }

        // GET: <controller>
        [HttpGet("{url}")]
        public async Task<IActionResult> Get(string url) {
            _logger.LogInformation(url);
            _logger.LogError("Get: s"+url);
            var hash = url.Split(".")[0];
            var link = db.Get(hash); // await Crawl(link)
            return File(await Crawl(link), "image/jpeg");
            // return new string[] { hash, link };
        }
    }
}