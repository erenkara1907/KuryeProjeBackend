using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetList()
        {

            var result = _userService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getclaims")]
        [Authorize]
        public IActionResult GetAllClaims(User user)
        {
            var result = _userService.GetClaims(user);
            return Ok();
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok();
        }

        [HttpGet("getbymail")]
        [Authorize]
        public IActionResult GetById(string email)
        {
            var result = _userService.GetByMail(email);
            return Ok();
        }
    }
}
