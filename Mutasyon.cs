using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenetikAlgoritmaOrnek
{
    class Mutasyon
    {
        public double mutasyonKatsayısı = 0.1;
        Random r = new Random();
        public Mutasyon()
        {

        }
        public void MutasyonYap(Kromozom kro)
        {
            int rasgele = r.Next(0, 2);
            if (rasgele == 0)
            {
                MToplama(kro);
            }
            if (rasgele == 1)
            {
                MCikarma(kro);
            }
           /* if (rasgele == 2)
            {
                MCarpma(kro);
            }
            if (rasgele == 3)
            {
                MBolme(kro);
            }*/
          
        }
        public void MToplama(Kromozom kro)
        {
            int rand=r.Next(0,2);
            kro.genlistesi[rand].gen += mutasyonKatsayısı;
        }
        public void MCikarma(Kromozom kro)
        {
            int rand = r.Next(0, 2);
            kro.genlistesi[rand].gen -= mutasyonKatsayısı;
        }
        public void MCarpma(Kromozom kro)
        {
            int rand = r.Next(0, 2);
            kro.genlistesi[rand].gen *= mutasyonKatsayısı;
        }
        public void MBolme(Kromozom kro)
        {
            int rand = r.Next(0, 2);
            kro.genlistesi[rand].gen /= mutasyonKatsayısı;
        }

    }
}
