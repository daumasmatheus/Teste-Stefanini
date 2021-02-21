using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> EditPerson(Person person) => await _personRepository.EditPerson(person);

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> FindById(int id) => await _personRepository.FindById(id);

        public async Task<bool> NewPerson(Person person) => await _personRepository.NewPerson(person);

        public async Task<bool> RemovePerson(int id) => await _personRepository.RemovePerson(id);
    }    
}
