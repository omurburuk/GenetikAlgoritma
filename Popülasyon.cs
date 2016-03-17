using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenetikAlgoritmaOrnek
{
    class Popülasyon
    {
        public List<Kromozom> popülasyon=new List<Kromozom>();
        public void popülasyonaBireyEkle(Kromozom k)
        {
            popülasyon.Add(k);
        }
    }
}
