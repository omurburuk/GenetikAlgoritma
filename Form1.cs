using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GenetikAlgoritmaOrnek
{
    public partial class Form1 : Form
    {
        int k_x3, k_x2, k_x, k_;
        Caprazlama c = new Caprazlama();
        Mutasyon m = new Mutasyon();

        Popülasyon po = new Popülasyon();
        Fonksiyon fo = new Fonksiyon();
        int uygun = 0;   
        public static int KromozomSayisi=100;
        public static int GenSayisi = 2;
        public static List<string> mesaj;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rasgeleOlustur();
        }
     
    
        public void rasgeleOlustur()
        {

            Random r = new Random();

            for (int i = 0; i < KromozomSayisi; i++)
            {
                Kromozom k = new Kromozom();
                for (int j = 0; j < GenSayisi; j++)
                {
                    double he= r.NextDouble()*9-4.5;
                       Gen gen=new  Gen(he);
                       k.genLisekle(gen);
                       listBox2.Items.Add((i+1)+". Birey "+(j+1)+". Gen Oluşturuldu" + gen.gen);
                      
                }
                fo.uygunlukhesapla(k);
                po.popülasyonaBireyEkle(k);

            }
            listBox1.Items.Add("Popülasyon üretildi");
            uygunbul();
        }
        double uygunluk = 1000.0;
        double uygunluk2 = 1000.0;
        List<Kromozom> enuyguKisicocuklari;
        public Kromozom uygunlukdegerienuygun()
        {
            Kromozom enuygun=po.popülasyon[0];
            for (int i = 0; i < po.popülasyon.Count-1; i++)
            {
                if (uygunluk >= po.popülasyon[i].uygunluk)
                {
                    enuygun = po.popülasyon[i];
                    uygunluk = enuygun.uygunluk;
                }
            }
          
            Kromozom enuygun2 = po.popülasyon[0];
            for (int i = 0; i < po.popülasyon.Count - 1; i++)
            {
                if (uygunluk2 >= po.popülasyon[i].uygunluk & po.popülasyon[i]!=enuygun)
                {
                    enuygun2 = po.popülasyon[i];
                    uygunluk2 = enuygun2.uygunluk;
                }
            }
             
            enuyguKisicocuklari=c.OrtadanCaprazla(enuygun, enuygun2);
            fo.uygunlukhesapla(enuyguKisicocuklari[0]);
            fo.uygunlukhesapla(enuyguKisicocuklari[1]);
            if (enuyguKisicocuklari[0].uygunluk < uygunluk)
            {
                listBox3.Items.Add("Daha iyi bir çocuk üretildi" + enuyguKisicocuklari[0].genlistesi[0].gen);
                listBox3.Items.Add("Daha iyi bir çocuk üretildi" + enuyguKisicocuklari[0].genlistesi[1].gen);
                po.popülasyon.Add(enuyguKisicocuklari[0]);
            }
            else
            {
                listBox4.Items.Add("Yaramaz Cocuk 1. gen" + enuyguKisicocuklari[0].genlistesi[0].gen);
                listBox4.Items.Add("Yaramaz Cocuk 2. gen" + enuyguKisicocuklari[0].genlistesi[1].gen);
            }
            if (enuyguKisicocuklari[1].uygunluk < uygunluk2)
            {
                listBox3.Items.Add("Daha iyi bir 2. çocuk üretildi" + enuyguKisicocuklari[1].genlistesi[0].gen);
                listBox3.Items.Add("Daha iyi bir 2. çocuk üretildi" + enuyguKisicocuklari[1].genlistesi[1].gen);
            }
            else
            {
                listBox4.Items.Add("Yaramaz Cocuk 1. gen" + enuyguKisicocuklari[1].genlistesi[0].gen);
                listBox4.Items.Add("Yaramaz Cocuk 2. gen" + enuyguKisicocuklari[1].genlistesi[1].gen);
            }
            enuygun = po.popülasyon[0];
            for (int i = 0; i < po.popülasyon.Count - 1; i++)
            {
                if (uygunluk >= po.popülasyon[i].uygunluk)
                {
                    enuygun = po.popülasyon[i];
                    uygunluk = enuygun.uygunluk;
                }
            }
            uygunluk = 1000.0;
            enuygun2 = po.popülasyon[0];
            for (int i = 0; i < po.popülasyon.Count - 1; i++)
            {
                if (uygunluk2 >= po.popülasyon[i].uygunluk & po.popülasyon[i] != enuygun)
                {
                    enuygun2 = po.popülasyon[i];
                    uygunluk2 = enuygun2.uygunluk;
                }
            }
            uygunluk2 = 1000.0;
            m.MutasyonYap(enuygun);
            listBox3.Items.Add("Mutasyonlu Genler 1. cocuk "+enuygun.genlistesi[0].gen+" "+enuygun.genlistesi[1].gen);
            m.MutasyonYap(enuygun2);
            listBox3.Items.Add("Mutasyonlu Genler 2. cocuk" + enuygun2.genlistesi[0].gen + " " + enuygun2.genlistesi[1].gen);
           
            return enuygun;
        }
        public void uygunbul()
        {
            int k=0;
            int ge=0;
            while (k<10000)
            {
                k++;
                ge++;
                Random r = new Random();
                int rand = r.Next(0, po.popülasyon.Count);
                List<Kromozom> cocuklar;
                Kromozom uyd1 = po.popülasyon[rand];
                rand = r.Next(0, po.popülasyon.Count);
                Kromozom uyd2 = po.popülasyon[rand];
                cocuklar = c.OrtadanCaprazla(uyd1, uyd2);
                fo.uygunlukhesapla(cocuklar[0]);
                fo.uygunlukhesapla(cocuklar[1]);
                if (cocuklar[0].uygunluk > uyd1.uygunluk)
                {
                    listBox1.Items.Add("1. Cocuk Yaramaz Üretildi");
                  
                }
                else
                {
                    listBox1.Items.Add("1. Uygun Cocuk Üretildi  Popülasyona Eklendi");
                    po.popülasyon.Add(cocuklar[0]);
                   
                  
                }
                if (cocuklar[1].uygunluk > uyd2.uygunluk)
                {  
                   
                    listBox1.Items.Add("2. Cocuk Yaramaz Üretildi");
                }
                else
                {
                    listBox1.Items.Add("2. Uygun Cocuk Üretildi Popülasyona Eklendi");
                    po.popülasyon.Add(cocuklar[1]);
                
                }
                if (ge == 30)
                {
                    ge = 0;
                    uygunlukdegerienuygun();
                }
                if (k == 2500)
                {
                    int a = po.popülasyon.Count;
                    string ver = "";
                }
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
        
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            uygunluk = 1000;
            uygunluk2 = 1000;
            Kromozom enuygun = po.popülasyon[0];
            for (int i = 0; i < po.popülasyon.Count - 1; i++)
            {
                if (uygunluk >= po.popülasyon[i].uygunluk)
                {
                    enuygun = po.popülasyon[i];
                    uygunluk = enuygun.uygunluk;
                }
            }
            uygunluk = 1000.0;
            Kromozom enuygun2 = po.popülasyon[0];
            for (int i = 0; i < po.popülasyon.Count - 1; i++)
            {
                if (uygunluk2 >= po.popülasyon[i].uygunluk & po.popülasyon[i] != enuygun)
                {
                    enuygun2 = po.popülasyon[i];
                    uygunluk2 = enuygun2.uygunluk;
                }
            }
            MessageBox.Show("En uygun 1. birey " + enuygun.genlistesi[0].gen + " " + enuygun.genlistesi[1].gen + " uygunluk "+ enuygun.uygunluk);
            MessageBox.Show("En uygun 2. birey " + enuygun2.genlistesi[0].gen + " " + enuygun2.genlistesi[1].gen + " uygunluk " + enuygun2.uygunluk);
   
        }

    }
}
