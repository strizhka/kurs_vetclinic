using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    class OwnerBase : Base<Owner>
    {
        public OwnerBase() { }

        public OwnerBase(List<Owner> owners) : base(owners) { }

        public override Owner FindByID(int ownerID)
        {
            return _list.Find(owner => owner.OwnerID == ownerID);
        }

    }
}
