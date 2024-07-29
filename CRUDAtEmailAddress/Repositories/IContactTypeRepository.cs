using Amazon.DynamoDBv2.Model;
using CRUDAtEmailAddress.CustomModel;
using CRUDAtEmailAddress.Models;

namespace CRUDAtEmailAddress.Repositories
{
    public interface IContactTypeRepository
    {


        Task<IEnumerable<ContactType>> Get();

        Task<ContactType> Get(int id);

        Task<ContactType> Create(ContactTypeDto e);

        Task Update(ContactTypeDto e);

        Task Delete(int id);
        
    }
}
