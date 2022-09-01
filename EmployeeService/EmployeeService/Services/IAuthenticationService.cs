using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Models.Responses;

namespace EmployeeService.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Login(AuthenticationRequest authenticationRequest);

        public SessionDto GetSession(string sessionToken);
    }
}
