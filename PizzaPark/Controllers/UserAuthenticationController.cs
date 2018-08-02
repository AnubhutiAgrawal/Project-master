using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaPark.PizzaHub.UserAuthentication.Authentication.BusinessLayer;
using PizzaPark.PizzaHub.UserAuthentication.Authentication.Model;

namespace PizzaPark.Controllers
{
    [Produces("application/json")]
    [Route("api/UserAuthentication")]
    public class UserAuthenticationController : Controller
    {

        [Route("login")]
        [HttpPost]
        public Boolean Login([FromBody]AuthenticationRequest request)
        {
            CreateUser obj = new CreateUser();
            return obj.CheckUser(request.UserName, request.Password);

        }

       // [HttpGet("user/{username}")]
      
       // public IActionResult GetByUserName([FromRoute] string username)
       // {


       //CreateUser obj = new CreateUser();

       // }



        [Route("DisplayList")]
        [HttpGet]
        public IActionResult Get()
        {
            CreateUser obj = new CreateUser();
            var userList = obj.GetList();
            var response = JsonConvert.SerializeObject(userList);
            return Ok(response);
        }


        [HttpGet("{name}/by-name")]

        public IActionResult Get(string name)
        {
            CreateUser obj = new CreateUser();
            var nameList = obj.GetUserName(name);
        
            if (nameList.Count!=0)
            {
                var response = JsonConvert.SerializeObject(nameList);
                return Ok(response);

            }
            return NotFound();
        }



        [HttpGet("{email}/by-email")]
        public IActionResult GetE(string email)
        {
            CreateUser objc = new CreateUser();
            var emailByObject = objc.GetUserEmail(email);
            if (emailByObject != null)
            {
                var result = JsonConvert.SerializeObject(emailByObject);
                return Ok(result);

            }
            return NotFound();



        }






        //[Route("logout")]
        //[HttpGet] 


        //public void Logout() 
        //{
        //    HttpContext.Session.Remove("username");
        //    HttpContext.Session.Remove("Password");
        //    HttpContext.Response.StatusCode = 200;
        //    return;

        //}

    }
}
