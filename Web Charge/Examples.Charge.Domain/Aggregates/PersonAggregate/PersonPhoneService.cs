using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<bool> EditPersonPhone(PersonPhone personPhone, PersonPhone extra) => await _personPhoneRepository.EditPersonPhone(personPhone, extra);

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<PersonPhone> FindById(int id) => await _personPhoneRepository.FindById(id);

        public async Task<bool> NewPersonPhone(PersonPhone personPhone) => await _personPhoneRepository.NewPersonPhone(personPhone);

        public async Task<bool> RemovePersonPhone(PersonPhone personPhone) => await _personPhoneRepository.RemovePersonPhone(personPhone);
    }
}
