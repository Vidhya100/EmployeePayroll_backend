using ModelLayer.Service;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }

        public UserModel UserRegi(UserModel userModel)
        {
            try
            {
                return iuserRL.UserRegi(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserModel Login(UserModel userModel)
        {
            try
            {
                return iuserRL.Login(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
     }
}
