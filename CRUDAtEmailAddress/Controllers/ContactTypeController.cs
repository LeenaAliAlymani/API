using CRUDAtEmailAddress.CustomModel;
using CRUDAtEmailAddress.Models;
using CRUDAtEmailAddress.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAtEmailAddress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {

        private readonly IContactTypeRepository _ContactTypesRepository;

        public ContactTypeController(IContactTypeRepository ContactTypesRepository)
        {
          _ContactTypesRepository = ContactTypesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactType>> GetContactTypes()
        {
            return await _ContactTypesRepository.Get();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ContactType>> GetContactTypes(int id)
        {
            return await _ContactTypesRepository.Get(id);
        }


        //اضافه
        [HttpPost]
        public async Task<ActionResult<ContactType>> PostContactType([FromBody] ContactTypeDto e)
        {
            
            var newContact = await _ContactTypesRepository.Create(e);
            return CreatedAtAction(nameof(GetContactTypes), new { id = newContact.ContactTypeId }, newContact);
        }


        //تعديل
        [HttpPut]
        public async Task<ActionResult> PutContactType([FromBody] ContactTypeDto e)
        {
            await _ContactTypesRepository.Update(e);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var ContactTypeToDelete = await _ContactTypesRepository.Get(id);
                if (ContactTypeToDelete == null)
                {
                    return NotFound();
                }

                await _ContactTypesRepository.Delete(ContactTypeToDelete.ContactTypeId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
