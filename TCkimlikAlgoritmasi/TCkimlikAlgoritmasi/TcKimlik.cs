using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCkimlikAlgoritmasi
{
    class TCKimlik
    {
                
        int onuncuSayi = 0;int SonSayi = 0;
        string tc = "";
        public void TekCift(string TCNumarasi)
        {
            
            int tekToplam = 0; int ciftToplam = 0;
            for (int i = 0; i < 9; i += 2)
            { // 1,3,5,7,9 haneleri toplar
                tekToplam += Convert.ToInt32(TCNumarasi[i].ToString());
            }

            for (int i = 1; i < 9; i += 2)
            { // 2,4,6,8 haneleri toplar
                ciftToplam += Convert.ToInt32(TCNumarasi[i].ToString());
            }

            onuncuSayi = ((tekToplam * 7) - ciftToplam) % 10; // 10.Sırada ki Sayıyı buldum
            SonSayi = (tekToplam + ciftToplam + onuncuSayi) % 10;// 11.Sırada ki sayıyı buldum
        }


        public string Dogrula(string TCNumarasi)
        {
            if (TCNumarasi.Length == 11 && Convert.ToInt32(TCNumarasi[0].ToString()) != 0)
            {
                if (Convert.ToInt32(TCNumarasi[9].ToString()) == onuncuSayi && Convert.ToInt32(TCNumarasi[10].ToString()) == SonSayi)
                // 10. ve 11. sırada ki sayıları karşılaştırır.
                {
                    MessageBox.Show("Geçerli TC Kimlik Numarası");
                    //return true;    
                }
                else
                {
                    MessageBox.Show("Geçersiz TC Kimlik Numarası");
                    //return false;
                }
            }
            else
            {
                MessageBox.Show(" TC Kimlik Numarası Sıfırdan Farklı Bir Sayıyla Başlamalıdır. " +
                    "\n TC Kimlik 11 Haneden oluşmalıdır.");
                //return false;
            }
            return TCNumarasi;

        }
        public string Olustur()
        {
            
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                tc += Convert.ToString(random.Next(1, 9));
            }
             TekCift(tc);
             string olusanTC = tc + onuncuSayi.ToString() + SonSayi.ToString();
             return Dogrula(olusanTC);

        }     
    }
}
