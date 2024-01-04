using Microsoft.AspNetCore.Mvc;
using PruebaProgreso2.BO;

namespace PruebaProgreso2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MundoEnTusManosController : ControllerBase
    {
        [HttpGet]
        [Route("GetUsuarioGeorreferenciacion")]
        public async Task<IActionResult> GetUserLocation([FromQuery] string userName)
        {
            MundoEnTusManosBO bo = new MundoEnTusManosBO();
            var result = await bo.GetUsuarioGeorreferenciacion(userName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
