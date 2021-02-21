using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> EditPersonPhone(PersonPhone personPhone, PersonPhone extra)
        {
            var entity = await _context.PersonPhone.FirstOrDefaultAsync(x => x.BusinessEntityID == extra.BusinessEntityID &&
                                                                               x.PhoneNumber == extra.PhoneNumber &&
                                                                               x.PhoneNumberTypeID == extra.PhoneNumberTypeID);
            entity.BusinessEntityID = personPhone.BusinessEntityID;
            entity.PhoneNumber = personPhone.PhoneNumber;
            entity.PhoneNumberTypeID = personPhone.PhoneNumberTypeID;

            _context.PersonPhone.Add(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync()
            => await Task.Run(() => _context.PersonPhone.Include(rel => rel.Person)
                                                        .Include(rel => rel.PhoneNumberType));

        public async Task<PersonPhone> FindById(int id)
            => await Task.Run(() => _context.PersonPhone.Where(x => x.BusinessEntityID == id)
                                                        .Include(rel => rel.Person)
                                                        .Include(rel => rel.PhoneNumberType)
                                                        .FirstOrDefault());

        public async Task<bool> NewPersonPhone(PersonPhone personPhone)
        {
            _context.PersonPhone.Add(personPhone);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemovePersonPhone(PersonPhone personPhone)
        {
            var entity = _context.PersonPhone.Where(x => x.BusinessEntityID == personPhone.BusinessEntityID &&
                                                         x.PhoneNumber == personPhone.PhoneNumber &&
                                                         x.PhoneNumberTypeID == personPhone.PhoneNumberTypeID).FirstOrDefault();
            _context.PersonPhone.Attach(entity);
            _context.PersonPhone.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
