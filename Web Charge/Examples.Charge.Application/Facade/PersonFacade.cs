using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }        

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();

            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));

            return response;
        }

        public async Task<PersonResponse> FindByIdAsync(int id)
        {
            var result = await _personService.FindById(id);

            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.Add(_mapper.Map<PersonDto>(result));

            return response;
        }

        public async Task<PersonResponse> NewPerson(PersonRequest request)
        {
            var result = await _personService.NewPerson(_mapper.Map<Person>(request.Person));

            var response = new PersonResponse();
            response.PersonObjects.Add(result ? request.Person : null);
            response.Success = result;

            return response;
        }

        public async Task<PersonResponse> RemovePerson(int id)
        {
            var result = await _personService.RemovePerson(id);

            var response = new PersonResponse();
            response.Success = result;

            return response;
        }

        public async Task<PersonResponse> EditPerson(PersonRequest request)
        {
            var result = await _personService.EditPerson(_mapper.Map<Person>(request.Person));

            var response = new PersonResponse();
            response.PersonObjects.Add(result ? request.Person : null);
            response.Success = result;

            return response;
        }
    }    
}
