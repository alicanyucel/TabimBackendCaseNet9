using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabimBackendCaseNet8.Dtos;
using TabimBackendCaseNet8.Services;

namespace TabimBackendCaseNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RequestsController : ControllerBase
    {
        private readonly RequestService _requestService;

        public RequestsController(RequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromForm] RequestCreateDto requestDto)
        {
            var userId = 1;
            var request = await _requestService.CreateRequestAsync(requestDto, userId);
            return Ok(request);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var requests = await _requestService.GetPendingRequestsAsync();
            return Ok(requests);
        }

        [HttpPost("evaluate/{requestId}")]
        public async Task<IActionResult> EvaluateRequest(int requestId, [FromBody] EvaluateRequestDto dto)
        {
            await _requestService.EvaluateRequestAsync(requestId, dto.Result, dto.Comment);
            return Ok();
        }
    }

}
