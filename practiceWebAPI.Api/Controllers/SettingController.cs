using CustomerManagement.Api.Repository;
using CustomerManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Setting")]
    public class SettingController : ControllerBase
    {

        private readonly ISettingRepository settingRepository;
        public SettingController(ISettingRepository settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        [HttpGet("index")]
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

        [HttpGet("id/{attributeId}")]
        public async Task<ActionResult<Setting>> GetSetting(String attributeId)
        {
            try
            {
                var result = await settingRepository.GetSetting(attributeId);

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

        [HttpPut("id/{attributeId}")]
        public async Task<ActionResult<Setting>> UpdateEmployee(String attributeId, Setting Setting)
        {
            try
            {
                if (attributeId != Setting.AttributeId)
                    return BadRequest("SettingID mismatch");

                var SettingToUpdate = await settingRepository.GetSetting(attributeId);

                if (SettingToUpdate == null)
                    return NotFound($"'Setting' with attributeID = {attributeId} not found");

                return await settingRepository.UpdateSetting(Setting);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("id/{attributeId}")]
        public async Task<ActionResult<Setting>> DeleteEmployee(String attributeId)
        {
            try
            {
                var SettingToDelete = await settingRepository.GetSetting(attributeId);

                if (SettingToDelete == null)
                {
                    return NotFound($"'Setting' with code = {attributeId} not found");
                }

                return await settingRepository.DeleteSetting(attributeId);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpGet("search/{search}")]
        public async Task<ActionResult<IEnumerable<Setting>>> Search(String search)
        {
            try
            {
                var result = await settingRepository.Search(search);

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
