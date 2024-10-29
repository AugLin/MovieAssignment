using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IUsersServiceAsync
    {
        Task<int> AddUsersAsync(Users user);
        Task<int> ValidateUsersAsync(Users user);
        Task<Users> GetUsersByEmailAsync(string email);
    }
}
