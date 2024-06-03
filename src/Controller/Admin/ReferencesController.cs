using FlooAnt.cmn.Enums;
using FlooAnt.Dtos.References;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace FlooAnt.Controllers.Admin
{
    /// <summary>
    /// this is a fluent references controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private IEnumerable<ReferenceDto> FakeDate = new List<ReferenceDto>()
        {
            new ReferenceDto()
            {
                Id = 1,
                Name = "Name1",
                Desc = "desc1",
            }
        };
        /// <summary>
        /// get references by type
        /// </summary>
        [HttpGet("{TypeName}")]
        public ActionResult<IEnumerable<string>> Get(string TypeName)
        {
            try
            {
                return Ok(FakeDate);
            }
            catch
            {
                return BadRequest($"Something went wrong while adding {TypeName}");
            }
        }

        /// <summary>
        /// get references by type and Id 
        /// </summary>
        [HttpPost("{typeName}")]
        public ActionResult<ReferenceDto> Add(string typeName, AddReferenceDto addDto)
        {
            try
            {
                if (!Enum.TryParse(typeof(ReferenceType), typeName, false, out object? type))
                {
                    return NotFound();
                }
                return new ReferenceDto()
                {
                    Id = 1,
                    Name = addDto.Name,
                    Desc = addDto.Desc,
                };
            }
            catch
            {
                return BadRequest($"Something went wrong while adding {typeName}");
            }
        }
        [HttpPut("{typeName}/{referenceId}")]
        public ActionResult<ReferenceDto> Update(string typeName, int referenceId, EditReferenceDto addDto)
        {
            try
            {
                if (!Enum.TryParse(typeof(ReferenceType), typeName, false, out object? type))
                {
                    return NotFound();
                }
                return new ReferenceDto()
                {
                    Id = referenceId,
                    Name = addDto.Name,
                    Desc = addDto.Desc,
                };
            }
            catch
            {
                return BadRequest($"Something went wrong while Editing {typeName} with Id {referenceId}");
            }
        }
        [HttpDelete("{typeName}/{referenceId}")]
        public ActionResult<ReferenceDto> Update(string typeName, int referenceId)
        {
            try
            {
                if (!Enum.TryParse(typeof(ReferenceType), typeName, false, out object? type))
                {
                    return NotFound();
                }
                return Ok();
            }
            catch
            {
                return BadRequest($"Something went wrong while deleting {typeName} with Id {referenceId}");
            }
        }
    }


}