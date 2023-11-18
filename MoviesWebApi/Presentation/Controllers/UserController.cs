using Application;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController :Controller
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Recibe el usuario y la contraseña si son correctos da acceso al endpoint.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns> String JWT </returns>
        [HttpPost("login")]
        public IActionResult LoginAuth(string username, string password)
        {
            if(username == null || password == null)
            {
                return BadRequest("Username or password is missing, please enter.");
            }

            var userToken = _userService.Login(username, password);
            
            if(userToken == null)
            {
                return NoContent();
            }

            return Json(userToken);
        }

        /// <summary>
        /// Crea un Usuario con los datos proporcionados.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>200 Ok</returns>
        [HttpPost("create")]
        public IActionResult Create(User user) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("No valid User JSON");
            }

            _userService.CreateUser(user);
            return Ok();
        }


        /// <summary>
        /// Obtiene todos los usarios
        /// </summary>
        /// <returns> IEnumerable<user> </returns>
        [HttpGet("get")]
        [Authorize]
        public IActionResult Get() 
        {
            var users = _userService.GetUsers();
            if(users == null)
            {
                return NoContent();
            }

            return Json(users);
        }
    }
}
