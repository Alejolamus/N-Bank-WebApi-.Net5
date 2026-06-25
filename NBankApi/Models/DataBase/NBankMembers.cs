using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.myEnums;

namespace NBankApi.Models.DataBase
{
    public class NBankMembers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string hassPass { get; set; }
        public nBankMembersRoles.roles rol { get; set; }
        public typedocument.typedocu typeDoc { get; set; }
        public int documentNum { get; set; }
    }
}
