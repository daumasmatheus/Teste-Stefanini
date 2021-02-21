using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<PersonPhone> FindById(int id);
        Task<bool> NewPersonPhone(PersonPhone personPhone);
        Task<bool> EditPersonPhone(PersonPhone personPhone, PersonPhone extra);
        Task<bool> RemovePersonPhone(PersonPhone personPhone);
    }
}
