using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL  : IUserRL
    {
        private readonly IConfiguration iconfiguration;

        public UserRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

    }
}
