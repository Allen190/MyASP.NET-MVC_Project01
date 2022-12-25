using System.Collections.Generic;

namespace Allen190Prj01.Models
{
    public abstract class DBmanagerBase
    {
        public abstract List<AdoMember> GetAdoMembers();
    }
}