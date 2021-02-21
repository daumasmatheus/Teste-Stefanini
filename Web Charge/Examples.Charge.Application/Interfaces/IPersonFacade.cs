﻿using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonResponse> FindByIdAsync(int id);
        Task<PersonResponse> NewPerson(PersonRequest request);
        Task<PersonResponse> EditPerson(PersonRequest request);
        Task<PersonResponse> RemovePerson(int id);
    }
}