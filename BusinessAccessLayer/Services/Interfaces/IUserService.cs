using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
    }
}
