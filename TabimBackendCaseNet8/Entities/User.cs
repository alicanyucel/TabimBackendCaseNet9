using TabimBackendCaseNet8.Enums;

namespace TabimBackendCaseNet8.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
