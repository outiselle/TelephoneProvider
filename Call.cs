using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telprov
{
   class Call
    {
        string _number;
        int _minutes;

        public Call(string number, int minutes)
        {
            _number = number;
            _minutes = minutes;
        }


        
        public string Number 
        { 
          get => _number; 
        }
        
        public int Minutes
        {
            get => _minutes;
        }
       
    }
}

