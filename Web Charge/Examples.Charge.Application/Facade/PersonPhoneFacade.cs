using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService personPhoneService;
        private readonly IMapper mapper;

        public PersonPhoneFacade(IPersonPhoneService _personPhoneService, IMapper _mapper)
        {
            personPhoneService = _personPhoneService;
            mapper = _mapper;
        }

        public async Task<PersonPhoneResponse> EditPersonPhone(PersonPhoneRequest request)
        {
            var result = await personPhoneService.EditPersonPhone(mapper.Map<PersonPhone>(request.PersonPhone),
                                                                  mapper.Map<PersonPhone>(request.Extra));

            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects.Add(result ? request.PersonPhone : null);
            response.Success = result;

            return response;
        }

        public async Task<PersonPhoneResponse> FindAllAsync()
        {
            var result = await personPhoneService.FindAllAsync();

            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<Dtos.PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => mapper.Map<PersonPhoneDto>(x)));

            return response;
        }

        public async Task<PersonPhoneResponse> FindByIdAsync(int id)
        {
            var result = await personPhoneService.FindById(id);

            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.Add(mapper.Map<PersonPhoneDto>(result));

            return response;
        }

        public async Task<PersonPhoneResponse> NewPersonPhone(PersonPhoneRequest request)
        {
            var result = await personPhoneService.NewPersonPhone(mapper.Map<PersonPhone>(request.PersonPhone));

            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();

            response.PersonPhoneObjects.Add(result ? request.PersonPhone : null);
            response.Success = result;

            return response;
        }

        public async Task<PersonPhoneResponse> RemovePersonPhone(PersonPhoneRequest request)
        {
            request.PersonPhone.PhoneNumberType = null;            

            var result = await personPhoneService.RemovePersonPhone(mapper.Map<PersonPhone>(request.PersonPhone));

            var response = new PersonPhoneResponse();
            response.Success = result;

            return response;
        }
    }
}
