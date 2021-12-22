using Microsoft.AspNetCore.Mvc;

namespace SoloVova.Delivery.Backend.WebApi.Controllers{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController : BaseController{
        // 
        // GET: /Test/

        public string Index(){
            return "This is my default action...";
        }

        // 
        // GET: /Test/Welcome/ 

        // public string Welcome(){
        //     return "This is the Welcome action method...";
        // }
    }
}