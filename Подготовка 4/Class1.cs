using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Подготовка_4
{
    internal class Class1
    {
        public static People Id;
        private static peopleEntities context;
        public static peopleEntities Getcontext()
        {
            if (context == null) context = new peopleEntities();
            return context;
             
        }
    }
}
