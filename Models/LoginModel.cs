using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using IPC.Models.IPCEntities;


namespace IPC.Models
{
    public class LoginModel
    {
        private static IConfiguration configuration;
        public LoginModel(IConfiguration config){
            configuration = config;
        }

        public LoginModel()
        {
        }

    }
}
