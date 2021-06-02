using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NextIT.Assignment.Models;
using NextIT.Assignment.WebApi.Services.Definitions;

namespace NextIT.Assignment.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Sign in to the system.
        /// </summary>
        /// <param name="user">Username and password of the user.</param>
        /// <returns>
        /// Username as a token if the user is authenticated properly.
        /// </returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> SignInAsync([FromBody] User user)
        {
            try
            {
                string token = await _userService.SignInAsync(user);
                if (token == user.Username)
                {
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not sign in.");
                throw;
            }
        }

        /// <summary>
        /// Register a user to the system
        /// </summary>
        /// <param name="user">Username and password user wants to use.</param>
        /// <returns>
        /// True or false based on either being authenticated or not.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> SignUpAsync([FromBody] User user)
        {
            try
            {
                bool signedUp = await _userService.SignUpAsync(user);
                return Ok(signedUp);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not sign up.");
                throw;
            }
        }
    }
}