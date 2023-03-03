using ModelLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public interface IUserRL
    {
        public UserModel UserRegi(UserModel userModel);
        public UserModel Login(UserModel userModel);
    }
}
