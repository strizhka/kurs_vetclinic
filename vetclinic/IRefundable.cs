using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    interface IRefundable
    {
        public string GetInfo()
        {
            return "Информации не найдено";
        }
    }
}
