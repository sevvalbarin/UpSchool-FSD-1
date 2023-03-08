using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Wasm.Memento
{
    public class PasswordCareTaker
    { 
        public List<PasswordMemento> Memento;

        public PasswordCareTaker()
        {
            Memento = new List<PasswordMemento>();
        }
        public void RemoveLastIndex()
        {
            Memento.RemoveAt(Memento.Count - 1);
        }
        
    }

}

