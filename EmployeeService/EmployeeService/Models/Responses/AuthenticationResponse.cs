using Microsoft.Extensions.Primitives;

namespace EmployeeService.Models.Responses
{
    public class AuthenticationResponse
    {

        public AuthenticationStatus Status { get; set; }
        public SessionDto Session { get; set; }
        public StringValues SessionDto { get; internal set; }
    }
}
