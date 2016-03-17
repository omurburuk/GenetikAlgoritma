using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenetikAlgoritmaOrnek
{
    public class Kromozom
    {
       public  Gen[] genlistesi = new Gen[Form1.KromozomSayisi];
     
        public double uygunluk;
        public int eklenen=0;
        public void genLisekle(Gen gen)
        {
            genlistesi[eklenen] = gen;
            eklenen++;

        }

        

       
       
    }
}
