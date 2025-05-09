using ChatApp_Fronted.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChatApp_Fronted.Controllers
{
    
    public class ChatController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            var client = _httpClientFactory.CreateClient("MyHttpClient"); // BU önemli
            var response = await client.PostAsJsonAsync("/chat", new
            {
                Prompt = request.Message,
                ConnectionId = request.ConnectionId
            });

            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }

    }

}
