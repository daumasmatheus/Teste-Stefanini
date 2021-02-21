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
    public class PersonController : BaseController
    {
        private IPersonFacade facade;

        public PersonController(IPersonFacade _facade)
        {
            facade = _facade;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PersonResponse>> GetAll() => Response(await facade.FindAllAsync());

        [HttpGet("GetById")]
        public async Task<ActionResult<PersonResponse>> GetById(int id) => Response(await facade.FindByIdAsync(id));

        [HttpPost("NewPerson")]
        public async Task<IActionResult> NewPerson(PersonRequest request) => Response(await facade.NewPerson(request));

        [HttpDelete("RemovePerson")]
        public async Task<IActionResult> RemovePerson(int id) => Response(await facade.RemovePerson(id));

        [HttpPatch("EditPerson")]
        public async Task<IActionResult> EditPerson(PersonRequest request) => Response(await facade.EditPerson(request));
    }
}
