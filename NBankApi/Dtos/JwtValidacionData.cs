using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.myEnums;
namespace NBankApi.Dtos
{
    public class JwtValidacionData
    {
        public int? idUser { get; set; }
        public RolesJwt.rolesJwt? rol { get; set; }
        public bool valitionStatus { get; set; }
        public string msn { get; set; }
        public JwtValidacionData(int? id, RolesJwt.rolesJwt? rolUser, bool validation, string message)
        {
            idUser = id;
            rol = rolUser;
            valitionStatus = validation;
            msn = message;
        }
    }
}
