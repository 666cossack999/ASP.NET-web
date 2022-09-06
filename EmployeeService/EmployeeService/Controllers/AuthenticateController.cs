using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Models.Responses;
using EmployeeService.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace EmployeeService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        #region Services

        private readonly IAuthenticationService _authenticationService;
        private readonly IValidator<AuthenticationRequest> _authenticationRequestValidator;

        #endregion

        #region Constructors

        public AuthenticateController(IAuthenticationService authenticationService, IValidator<AuthenticationRequest> authenticationRequestValidator)
        {

            _authenticationService = authenticationService;
            _authenticationRequestValidator = authenticationRequestValidator;
        }

        #endregion

        #region Public Methods

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public IActionResult Login([FromBody] AuthenticationRequest authenticationRequest)
        {
            ValidationResult validationResult = _authenticationRequestValidator.Validate(authenticationRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            AuthenticationResponse authenticationResponse = _authenticationService.Login(authenticationRequest);
            if (authenticationResponse.Status == Models.AuthenticationStatus.Success)
            {
                Response.Headers.Add("X-Session-Token", authenticationResponse.Session.SessionToken);
            }
            return Ok(authenticationResponse);
        }

        [HttpGet]
        [Route("session")]
        [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
        public IActionResult GetSession()
        {
            var authorizationHeader = Request.Headers[HeaderNames.Authorization];

            if (AuthenticationHeaderValue.TryParse(authorizationHeader, out var headerValue))
            {
                var scheme = headerValue.Scheme; //Bearer
                var sessionToken = headerValue.Parameter; //Token
                if (string.IsNullOrEmpty(sessionToken))
                    return Unauthorized();

                SessionDto sessionDto = _authenticationService.GetSession(sessionToken);
                if (sessionDto == null)
                    return Unauthorized();

                return Ok(sessionDto);
            }
            return Unauthorized();
        }

        #endregion
    
    }
}
