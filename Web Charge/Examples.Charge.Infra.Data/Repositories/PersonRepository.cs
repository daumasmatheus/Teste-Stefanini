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
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> EditPerson(Person person)
        {
            _context.Entry(await _context.Person.FirstOrDefaultAsync(x => x.BusinessEntityID == person.BusinessEntityID))
                    .CurrentValues.SetValues(person);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Person>> FindAllAsync() 
            => await Task.Run(() => _context.Person.Include(rel => rel.Phones).ThenInclude(rel => rel.PhoneNumberType));

        public async Task<Person> FindById(int id) 
            => await Task.Run(() => _context.Person.Where(x => x.BusinessEntityID == id)
                                                   .Include(rel => rel.Phones)
                                                   .FirstOrDefault());

        public async Task<bool> NewPerson(Person person)
        {
            _context.Person.Add(person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemovePerson(int id)
        {
            var entity = _context.Person.Where(x => x.BusinessEntityID == id).FirstOrDefault();
            _context.Person.Attach(entity);
            _context.Person.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
