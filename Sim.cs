using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telprov
{
    class Sim
    {
        private string _number;
        private float _credit;
        private List<Call> _calls;
        const float creditForMinute = 0.01f ;

        public Sim(string number, float credit)
        {
            _number = number;
            _credit = credit;
            _calls = new List<Call>();
        }

        public float? addCall(string dest, int min) 
        {
            float? costo = min * creditForMinute;

            if (costo <= _credit)
            {
                Call call = new Call(dest, min);
                _calls.Add(call);
                _credit = (float)(_credit - costo);
            }
            else
            {
                costo = null;
            }
            return costo;
        }


        public float addCredit(float credit)
        {
            _credit = _credit + credit;
            return _credit;
        }

        public int getTotalMinutes()
        {
            int totMin = 0;
            foreach (Call c in _calls)
            {
                totMin += c.Minutes;
            }
            return totMin;
        }

        public int getMinutesFromNumber(string number)
        {
            int i = 0;
            int minutes = 0;
            foreach (Call c in _calls)
            {
                if (number == c.Number)
                {
                    i++;
                    minutes += c.Minutes;
                    Console.WriteLine($" Chiamata numero: {i} | Verso: {number} | Durata: {minutes} minuti");

                }
            }
            return minutes;

            

        }

        public int getCallsFromNumber(string number)
        {
            int n= 0;
            foreach (Call c in _calls)
            {
                if(number == c.Number)
                {
                    n++;
                }
            }
            return n;
        }

        public void printSimInfo()
        {
            Console.WriteLine($"il numero di telefono è {_number}");
            Console.WriteLine($"il credito disponibile è {_credit} euro");
            Console.WriteLine($"l'elenco delle telefonate effettuate è: ");
            foreach (Call c in _calls)
            {
                Console.WriteLine($" - destinario [{c.Number}] durata [{c.Minutes}minuti]");
            }

        }

        /*
        public string Number
        {
            get => _number;
            set => _number = value;
        }
        public float Credit 
        { 
            get => _credit; 
            set => _credit = value; 
        }
        internal List<Call> Calls 
        { 
            get => _calls; 
            set => _calls = value; 
        }
        */
    }
}
