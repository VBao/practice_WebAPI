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
    public class SettingController : ControllerBase
    {

        private readonly ISettingRepository settingRepository;
        public SettingController(ISettingRepository settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSettings()
        {
            try
            {
                return Ok(await settingRepository.GetSettings());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{attributeId:string}")]
        public async Task<ActionResult<Setting>> GetSetting(string attributeID)
        {
            try
            {
                var result = await settingRepository.GetSetting(attributeID);

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
        public async Task<ActionResult<Setting>> CreateSetting(Setting Setting)
        {
            try
            {
                if (Setting == null)
                    return BadRequest();

                var createdSetting = await settingRepository.AddSetting(Setting);

                return CreatedAtAction(nameof(GetSetting),
                    new { code = createdSetting.AttributeId }, createdSetting);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new 'Setting' record");
            }
        }

        [HttpPut("{attributeId:string}")]
        public async Task<ActionResult<Setting>> UpdateEmployee(string attributeID, Setting Setting)
        {
            try
            {
                if (attributeID != Setting.AttributeId)
                    return BadRequest("SettingID mismatch");

                var SettingToUpdate = await settingRepository.GetSetting(attributeID);

                if (SettingToUpdate == null)
                    return NotFound($"'Setting' with attributeID = {attributeID} not found");

                return await settingRepository.UpdateSetting(Setting);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{attributeId:string}")]
        public async Task<ActionResult<Setting>> DeleteEmployee(string attributeID)
        {
            try
            {
                var SettingToDelete = await settingRepository.GetSetting(attributeID);

                if (SettingToDelete == null)
                {
                    return NotFound($"'Setting' with code = {attributeID} not found");
                }

                return await settingRepository.DeleteSetting(attributeID);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Setting>>> Search(string attributeID)
        {
            try
            {
                var result = await settingRepository.Search(attributeID);

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
