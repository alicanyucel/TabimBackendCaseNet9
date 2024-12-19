using TabimBackendCaseNet8.Enums;

namespace TabimBackendCaseNet8.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? EvaluatedDate { get; set; }
        public string EvaluationResult { get; set; }
        public string EvaluationComment {  get; set; }
     
    }
}
