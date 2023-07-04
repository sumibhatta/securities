using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Securities.API.Repositories;
using Securities.API.Models;

namespace Securities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDataAccessLayer _dataAccessLayer;
        public UserController(UserDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;

        }
        //List All User
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> users = await _dataAccessLayer.GetAllUsers();
            return Ok(users);
        }

        //List An USer
        [HttpGet("{id}")]
        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("User Not Found");
            }

            Task<User> user = _dataAccessLayer.GetUserData(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Add An User
        [HttpPost("add")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _dataAccessLayer.AddAUser(user);
                return Ok("User Added");
            }
            return Ok(user);

        }

        //Update An User
        [HttpPost("update/{id}")]
        public async Task<IActionResult> EditUser(User user, int? id)
        {
            if (id != user.UserId)
            {
                return BadRequest("User Not Found");
            }
            if (ModelState.IsValid)
            {
                _dataAccessLayer.UpdateUser(user);

            }
            return Ok(user);

        }

        //Delete An User
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {

            if (id == null)
            {
                return BadRequest("User Not Found");
            }

            Task<User> user = _dataAccessLayer.GetUserData(id);

            if (user == null)
            {
                return NotFound();
            }
            _dataAccessLayer.DeleteAUser(id);
            return Ok("Deleted");
        }




    }



}

