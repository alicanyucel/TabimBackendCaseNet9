namespace TabimBackendCaseNet8.Dtos
{
    public class RequestCreateDto
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public IFormFile Document { get; set; }
    }
}
