using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IUsersService
    {
        int AddUsers(Users user);
        int ValidateUsers(Users user);
        Users GetUsersByEmail(string email);
    }
}
