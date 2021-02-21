using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        Task<PersonAggregate.PersonPhone> FindById(int id);
        Task<bool> NewPersonPhone(PersonAggregate.PersonPhone personPhone);
        Task<bool> EditPersonPhone(PersonAggregate.PersonPhone personPhone, PersonAggregate.PersonPhone extra);
        Task<bool> RemovePersonPhone(PersonAggregate.PersonPhone personPhone);
    }
}
