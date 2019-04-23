using System;
using System.Collections.Generic;
using System.Text;
using UnibetInterfaces;

namespace UnibetDAL
{
    public class UserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public void Add(IUser person)
        {
            _context.Add(person);
        }

        public void Edit(IUser person)
        {
            _context.Edit(person);
        }

        public IEnumerable<IUser> GetAll()
        {
            return _context.GetAll();
        }
    }
}
