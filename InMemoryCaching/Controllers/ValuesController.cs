using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        
        [HttpGet("set/{name}")]
        public void Set(string name)
        {
            // name key i ile bir name'i cacheleme
            _memoryCache.Set("name", name);
            // _memoryCache.Get("name");
        }

        [HttpGet]
        public string Get()
        {
            // klasik
            // return _memoryCache.Get<string>("name");

            // hatalara karsi dayanikliligi attirmak icin
            if (_memoryCache.TryGetValue<string>("name", out string name))
            {
                return name.Substring(3);
            }
            return "";

        }

        

        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                // belirlenen sure sonunda silinsin
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),

                // belirlene sure icinde kullanılırsa uzasin yoksa silinsin
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });

        }

        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }
    }
}
