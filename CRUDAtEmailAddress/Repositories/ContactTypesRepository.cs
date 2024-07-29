using CRUDAtEmailAddress.CustomModel;
using CRUDAtEmailAddress.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDAtEmailAddress.Repositories
{
    public class ContactTypesRepository : IContactTypeRepository
    {
        private readonly AdventureWorks2022Context _AdventureWorks2022Context;
        public ContactTypesRepository(AdventureWorks2022Context context)
        {
            _AdventureWorks2022Context = context;
        }



        public async Task<IEnumerable<ContactType>> Get()
        {
            return await _AdventureWorks2022Context.ContactTypes.ToListAsync();
        }


        
        public async Task<ContactType?> Get(int id)
        {
            return await _AdventureWorks2022Context.ContactTypes.Include(x => x.BusinessEntityContacts).FirstOrDefaultAsync(x=>x.ContactTypeId==id);
        }


        
        public async Task<ContactType> Create(ContactTypeDto b)
        {
            var contact = new ContactType
            {
               ContactTypeId = b.ContactTypeId,
               Name = b.Name,
               ModifiedDate = DateTime.Now,
            };
            _AdventureWorks2022Context.ContactTypes.Add(contact);
            await _AdventureWorks2022Context.SaveChangesAsync();
            return contact;
        }



        public async Task Update(ContactTypeDto b)
        {
            var contact = new ContactType
            {
                ContactTypeId = b.ContactTypeId,
                Name = b.Name,
                ModifiedDate = DateTime.Now,
            };
            _AdventureWorks2022Context.ContactTypes.Update(contact);
            await _AdventureWorks2022Context.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var EmployeeToDelete = await _AdventureWorks2022Context.ContactTypes.FindAsync(id);
            _AdventureWorks2022Context.ContactTypes.Remove(EmployeeToDelete);
            await _AdventureWorks2022Context.SaveChangesAsync();
        }

    }
}
