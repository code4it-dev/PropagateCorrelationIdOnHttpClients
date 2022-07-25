using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropagateCorrelationIdOnHttpClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            var item = new Item(value);

            var httpClient = _httpClientFactory.CreateClient("items");
            await httpClient.PostAsJsonAsync("/", item);
            return NoContent();
        }
    }

    public class Item
    {
        public Item(string value)
        {
            Value = value;
            Id = Guid.NewGuid();
        }

        public string Value { get; }
        public Guid Id { get; }
    }
}