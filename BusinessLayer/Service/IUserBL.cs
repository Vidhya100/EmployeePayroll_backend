using ModelLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public interface IUserBL
    {
        public UserModel UserRegi(UserModel userModel);
        public UserModel Login(UserModel userModel);
    }
}
