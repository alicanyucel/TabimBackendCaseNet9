using Microsoft.EntityFrameworkCore;
using TabimBackendCaseNet8.Context;
using TabimBackendCaseNet8.Dtos;
using TabimBackendCaseNet8.Entities;
using TabimBackendCaseNet8.Enums;

namespace TabimBackendCaseNet8.Services
{
    public class RequestService
    {
        private readonly ApplicationDbContext _context;

        public RequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Request> CreateRequestAsync(RequestCreateDto requestDto, int userId)
        {
            var request = new Request
            {
                UserId = userId,
                FullName = requestDto.FullName,
                Description = requestDto.Description,
                Document = requestDto.Document.FileName,
                SubmittedDate = DateTime.Now,
                Status = RequestStatus.Pending
            };

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<List<Request>> GetPendingRequestsAsync()
        {
            return await _context.Requests
                .Where(r => r.Status == RequestStatus.Pending)
                .OrderBy(r => r.SubmittedDate)
                .ToListAsync();
        }

        public async Task EvaluateRequestAsync(int requestId, string result, string comment)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                request.Status = RequestStatus.Evaluated;
                request.EvaluatedDate = DateTime.Now;
                request.EvaluationResult = result;
                request.EvaluationComment = comment;
                await _context.SaveChangesAsync();
            }
        }
    }

}
