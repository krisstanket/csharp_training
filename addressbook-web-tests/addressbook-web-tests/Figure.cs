using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Figure
    {
        private bool coloured = false;

        public bool Coloured
        {
            get
            {
                return coloured;
            }
            set
            {
                coloured = value;
            }
        }
    }
}
