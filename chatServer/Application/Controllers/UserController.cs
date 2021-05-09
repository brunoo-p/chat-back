using System;
using System.Threading.Tasks;
using Chat.Infrastructure.Entities;
using Chat.Infrastructure.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Application.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUser _repository;
        public UserController(IUser repository)
        {
            _repository = repository;
        }

        [EnableCors("Client")]
        [HttpPost]
        public ActionResult<User> addUser(User newUser)
        {
            try{

                var user = _repository.addUser(newUser);

                if(user == null){
                    return StatusCode(203, "Este usuário ja está sendo usado.");
                }

                return StatusCode(200, user);

            }catch(Exception err){

                return StatusCode(400, err);
            }
        }

        [EnableCors("Client")]
        [HttpPost]
        [Route("login")]
        public ActionResult<User> login(string nickname, string password)
        {
            try{

                var user =  _repository.login(nickname, password);

                if(user == null){

                    return StatusCode(203, "Usuário não existe.");   
                }
                return StatusCode(200, user);
                
            }catch(Exception err){
                
                return StatusCode(400, err);
            }
        }
    }
}