using HotelRoomBookingApi.Models;
using HotelRoomBookingApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo Repositories = null;
        private readonly MyDbContext context;
        public UserController(IUserRepo repo)
        {
            Repositories = repo;
        }
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> users = Repositories.GetAllUsers();
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                return NotFound();
            }
        }
        [Route("{id:int}")]
        [HttpGet]
        public ActionResult<User> Get(int id)
        {
            User user = Repositories.GetUserById(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{email},{password}")]
        public async Task<IActionResult> Login(string email,string password)
        {

            User user = Repositories.UserGetUserByName(email,password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("user is invalid");
            }

        }

        [HttpPost]
        public string Post(User user)
        {
            string Response = Repositories.AddNewUser(user);
            return Response;
        }
        [HttpPut]
        public string Put(User user)
        {
            string Response = Repositories.UpdateUser(user);
            return Response;
        }

        [Route("{id:int}")]
        [HttpDelete]
        public string Delete(int id)
        {
            string Response = Repositories.DeleteUser(id);
            return Response;
        }
    }
}
