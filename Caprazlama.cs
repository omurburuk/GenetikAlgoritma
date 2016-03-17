using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenetikAlgoritmaOrnek
{
    class Caprazlama
    {
        List<Kromozom> cocuklar =new  List<Kromozom>();

        public List<Kromozom> OrtadanCaprazla(Kromozom kro1, Kromozom kro2)
        {
            cocuklar = new List<Kromozom>();
            Kromozom cocuk1 = new Kromozom( );
            cocuk1.genlistesi[0] = kro1.genlistesi[0];
            cocuk1.genlistesi[1] = kro2.genlistesi[1];
            Kromozom cocuk2 = new Kromozom();
            cocuk2.genlistesi[0]= kro2.genlistesi[0];
            cocuk2.genlistesi[1] = kro1.genlistesi[1];
            cocuklar.Add(cocuk1);
            cocuklar.Add(cocuk2);
            
            return cocuklar;
            
        }
       
        
    }
}
