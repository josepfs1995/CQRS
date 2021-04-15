using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.WebAPI.Applications.Interfaces;
using CQRS.WebAPI.Applications.ViewModels.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonAppService _personAppService;
        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        /// <summary>
        /// Get People.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPersonViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
           var response = await _personAppService.GetAll();
           return Ok(response);
        }
        /// <summary>
        /// Create a Person.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreatePersonViewModel model)
        {
           var response = await _personAppService.Create(model);
           if(!response) return BadRequest();
           return Ok();
        }
    }
}
