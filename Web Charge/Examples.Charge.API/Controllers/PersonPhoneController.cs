using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private readonly IPersonPhoneFacade facade;

        public PersonPhoneController(IPersonPhoneFacade _facade)
        {
            facade = _facade;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PersonPhoneResponse>> GetAll() => Response(await facade.FindAllAsync());

        [HttpGet("GetById")]
        public async Task<ActionResult<PersonPhoneResponse>> GetById(int id) => Response(await facade.FindByIdAsync(id));

        [HttpPost("NewPersonPhone")]
        public async Task<IActionResult> NewPersonPhone(PersonPhoneRequest request) => Response(await facade.NewPersonPhone(request));

        [HttpDelete("RemovePersonPhone")]
        public async Task<IActionResult> RemovePersonPhone(PersonPhoneRequest request) => Response(await facade.RemovePersonPhone(request));

        [HttpPatch("EditPersonPhone")]
        public async Task<IActionResult> EditPersonPhone(PersonPhoneRequest request) => Response(await facade.EditPersonPhone(request));
    }
}
