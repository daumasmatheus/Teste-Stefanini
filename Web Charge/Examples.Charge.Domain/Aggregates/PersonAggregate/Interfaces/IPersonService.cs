using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<Person> FindById(int id);
        Task<bool> NewPerson(Person person);
        Task<bool> EditPerson(Person person);
        Task<bool> RemovePerson(int id);
    }
}
