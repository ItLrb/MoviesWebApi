using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInfosApi.DbContext;
using UserInfosApi.Model;
using UserInfosApi.Repository;

namespace UserInfosApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public ActionResult GetUsers()
    {
        var users = _userRepository.GetAllUser();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null) return NotFound();
        
        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        _userRepository.AddUser(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] User user)
    {
        user.Id = id;
        _userRepository.UpdateUser(user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _userRepository.DeleteUser(id);
        return Ok();
    }
}