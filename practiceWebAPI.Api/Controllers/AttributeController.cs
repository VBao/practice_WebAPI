using CustomerManagement.Api.Repository;
using CustomerManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeRepository attributeRepository;
        public AttributeController(IAttributeRepository attributeRepository)
        {
            this.attributeRepository = attributeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAttributes()
        {
            try
            {
                return Ok(await attributeRepository.GetAttributes());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{code:string}")]
        public async Task<ActionResult<Attribute>> GetAttribute(string code)
        {
            try
            {
                var result = await attributeRepository.GetAttribute(code);

                if (result == null) return NotFound();

                return result;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Attribute>> CreateAttribute(Attribute attribute)
        {
            try
            {
                if (attribute == null)
                    return BadRequest();

                var createdAttribute = await attributeRepository.AddAttribute(attribute);

                return CreatedAtAction(nameof(GetAttribute),
                    new { code = createdAttribute.Code }, createdAttribute);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new 'attribute' record");
            }
        }

        [HttpPut("{code:string}")]
        public async Task<ActionResult<Attribute>> UpdateEmployee(string code, Attribute attribute)
        {
            try
            {
                if (code != attribute.Code)
                    return BadRequest("AttributeID mismatch");

                var attributeToUpdate = await attributeRepository.GetAttribute(code);

                if (attributeToUpdate == null)
                    return NotFound($"'Attribute' with code = {code} not found");

                return await attributeRepository.UpdateAttribute(attribute);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{code:string}")]
        public async Task<ActionResult<Attribute>> DeleteEmployee(string code)
        {
            try
            {
                var attributeToDelete = await attributeRepository.GetAttribute(code);

                if (attributeToDelete == null)
                {
                    return NotFound($"'Attribute' with code = {code} not found");
                }

                return await attributeRepository.DeleteAttribut(code);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Attribute>>> Search(string code)
        {
            try
            {
                var result = await attributeRepository.Search(code);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
