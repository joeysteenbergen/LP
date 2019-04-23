using System;
using System.Collections.Generic;
using System.Text;
using UnibetInterfaces;

namespace UnibetDAL
{
    public interface IUserContext
    {
        void Add(IUser person);
        void Edit(IUser person);
        IEnumerable<IUser> GetAll();
    }
}
