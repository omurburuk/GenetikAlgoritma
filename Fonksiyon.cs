using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenetikAlgoritmaOrnek
{
	public class Fonksiyon
	{
		double sonuc;
		double eniyisonuc=0.0;

		public double fxy;

		public void uygunlukhesapla(Kromozom k)
		{
		   
			for (int i = 0; i < Form1.GenSayisi; i++)
			{ 
				double x= k.genlistesi[i].gen;
				i++;
                double y = k.genlistesi[i].gen;
              
				 fxy = Math.Pow((1.5 - x + x * y), 2) + Math.Pow((2.25 - x + x * y * y), 2) + Math.Pow((2.625 - x + x * y * y * y), 2);
			}
		 

			k.uygunluk = fxy;
		}


		public void eniyisonucumuz(int k1, int k2, int k3, int k4)
		{
			eniyisonuc = k1 * 3*3*3+ k2 *3*3+ k3 * 3 + k4;
		}



		/*public void UygunlukFonksiyonEniyi(Kromozom birey,int k1,int k2,int k3,int k4)
		{
			double fonsonucu = 0;
			int deger = 0;
			for (int i = 0; i < birey.gen.Length; i++)
			{
				 int k = Convert.ToInt16(birey.gen[i].ToString());
				 if (i == 0)
					 deger += k;
				 else deger += k * 2;
			}
			
			fonsonucu += deger * deger * deger * k1;
			deger = 0;
			for (int i = 0; i < birey.gen1.Length; i++)
			{
				int k = Convert.ToInt16(birey.gen1[i].ToString());
				if (i == 0)
					deger += k;
				else deger += k * 2;
			}
			fonsonucu += deger * deger *  k2;
			deger = 0;
			for (int i = 0; i < birey.gen2.Length; i++)
			{
				int k = Convert.ToInt16(birey.gen2[i].ToString());
				if (i == 0)
					deger += k;
				else deger += k * 2;
			}
			fonsonucu += deger * k3;
			deger = 0;
			for (int i = 0; i < birey.gen2.Length; i++)
			{
				int k = Convert.ToInt16(birey.gen2[i].ToString());
				if (i == 0)
					deger += k;
				else deger += k * 2;
			}
			fonsonucu += k4;
			birey.uygunluk = fonsonucu / eniyisonuc;
			
		}*/
	}
}
