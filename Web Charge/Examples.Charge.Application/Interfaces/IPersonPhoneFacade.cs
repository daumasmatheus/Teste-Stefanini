using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindByIdAsync(int id);
        Task<PersonPhoneResponse> NewPersonPhone(PersonPhoneRequest request);
        Task<PersonPhoneResponse> EditPersonPhone(PersonPhoneRequest request);
        Task<PersonPhoneResponse> RemovePersonPhone(PersonPhoneRequest request);
    }
}