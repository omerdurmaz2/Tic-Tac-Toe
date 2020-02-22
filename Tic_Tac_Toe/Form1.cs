using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Değişkenler
        public string[,] dizi = new string[3, 3];
        public static string makine = "";
        public static string sira = "";
        public static int sayac = 0;
        public bool bitti = false;


        //Form Göründüğünde Kullanıcıya X ya da O seçilmesi İsteniyor
        private void Form1_Shown(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            DialogResult cvp = f3.ShowDialog();
            if (cvp != DialogResult.OK) { this.Close(); }
            lblsoyuncu.Text = sira;
        }


        //Formda bulunan Yeni Oyun, Çıkış, Yardım butonları yapacakları belirleniyor
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resetle();
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        //Yeni Oyun Butonuna Tıklandığında Form Resetleniyor
        public void Resetle()
        {
            dizi = new string[3, 3];
            sira = "";
            sayac = 0;
            bitti = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            button1.BackColor = Color.CadetBlue;
            button2.BackColor = Color.CadetBlue;
            button3.BackColor = Color.CadetBlue;
            button4.BackColor = Color.CadetBlue;
            button5.BackColor = Color.CadetBlue;
            button6.BackColor = Color.CadetBlue;
            button7.BackColor = Color.CadetBlue;
            button8.BackColor = Color.CadetBlue;
            button9.BackColor = Color.CadetBlue;

            Form3 f3 = new Form3();
            DialogResult cvp = f3.ShowDialog();
            if (cvp != DialogResult.OK) { this.Close(); }
            lblsoyuncu.Text = sira;

        }

        //Her Buton Tıklandığında dizi kontrol edilip kazanan olup olmadığı bakılıyor
        public void Kontrol()
        {
            sayac++;
            if (dizi[0, 0] == dizi[0, 1] && dizi[0, 0] == dizi[0, 2] && (dizi[0, 0] == "O" || dizi[0, 0] == "X")) { Bitir(1); }
            else if (dizi[1, 0] == dizi[1, 1] && dizi[1, 0] == dizi[1, 2] && (dizi[1, 0] == "O" || dizi[1, 0] == "X")) { Bitir(2); }
            else if (dizi[2, 0] == dizi[2, 1] && dizi[2, 0] == dizi[2, 2] && (dizi[2, 0] == "O" || dizi[2, 0] == "X")) { Bitir(3); }
            else if (dizi[0, 0] == dizi[1, 0] && dizi[0, 0] == dizi[2, 0] && (dizi[0, 0] == "O" || dizi[0, 0] == "X")) { Bitir(4); }
            else if (dizi[0, 1] == dizi[1, 1] && dizi[0, 1] == dizi[2, 1] && (dizi[0, 1] == "O" || dizi[0, 1] == "X")) { Bitir(5); }
            else if (dizi[0, 2] == dizi[1, 2] && dizi[0, 2] == dizi[2, 2] && (dizi[0, 2] == "O" || dizi[0, 2] == "X")) { Bitir(6); }
            else if (dizi[0, 0] == dizi[1, 1] && dizi[0, 0] == dizi[2, 2] && (dizi[0, 0] == "O" || dizi[0, 0] == "X")) { Bitir(7); }
            else if (dizi[2, 0] == dizi[1, 1] && dizi[2, 0] == dizi[0, 2] && (dizi[2, 0] == "O" || dizi[2, 0] == "X")) { Bitir(8); }
            else if (sayac == 9) { MessageBox.Show("Berabere"); }
            else if (sayac % 2 == 1) // Eğer sıra bilgisayardaysa yapılacaklar
            {
                timer1.Start();//sıra bilgisayara geldiğinde timer başlatılıyor
            }
        }
        //Kullanıcı seçimini yaptıktan 300ms sonra bu fonksiyon çağırılıyor
        public void Yapay_Zeka()
        {
            if (!bitti)
            {
                int cevap = -1;
                cevap = Bitirme();
                if (cevap == -1) cevap = Karsi_Hamle();
                if (cevap == -1)
                {
                    if (kare(5) == null) { cevap = 5; goto devam; }

                    if (kare(1) == null) { cevap = 1; goto devam; }
                    else
                        if (kare(1) == makine && kare(9) == null) { cevap = 9; goto devam; }
                    else
                            if (kare(1) == makine && kare(9) == makine && kare(3) == null) { cevap = 3; goto devam; }
                    else
                                if (kare(1) == makine && kare(9) == makine && kare(7) == null) { cevap = 7; goto devam; }
                    if (kare(3) == null) { cevap = 3; goto devam; }
                    else
                        if (kare(3) == makine && kare(7) == null) { cevap = 7; goto devam; }
                    else
                            if (kare(3) == makine && kare(7) == makine && kare(9) == null) { cevap = 9; goto devam; }
                    else
                                if (kare(1) == makine && kare(9) == makine && kare(7) == null) { cevap = 1; goto devam; }

                    if (kare(1) == null) cevap = 1;
                    if (kare(2) == null) cevap = 2;
                    if (kare(3) == null) cevap = 3;
                    if (kare(4) == null) cevap = 4;
                    if (kare(5) == null) cevap = 5;
                    if (kare(6) == null) cevap = 6;
                    if (kare(7) == null) cevap = 7;
                    if (kare(8) == null) cevap = 8;
                    if (kare(9) == null) cevap = 9;
                }

            devam:
                switch (cevap)
                {
                    case 1: button1.PerformClick(); break;
                    case 2: button2.PerformClick(); break;
                    case 3: button3.PerformClick(); break;
                    case 4: button4.PerformClick(); break;
                    case 5: button5.PerformClick(); break;
                    case 6: button6.PerformClick(); break;
                    case 7: button7.PerformClick(); break;
                    case 8: button8.PerformClick(); break;
                    case 9: button9.PerformClick(); break;
                }

            }

            /*
             OYUN KURAMI ve YAPAY ZEKA HAREKET PLANI
            oyunu kendi kendine bolca ister bilgisayara karşı, ister arkadaşına karşı oynayanlar bilirki oyuna ilk başlamak önemli bir avantajdır. oyunun merkez karesine simgeni koymak önemlidir. ardından köşeleri ele geçirmek, rakip peş peşe iki simge koymuşsa bunu engellemek, gereklidir.

            eldeki bilgi ve deneyimle  kurallarımızı alt alta yazalım ve hamla düşünüş sırasını bilgisayara nasıl programlayacağımıza bakalım. tabi önceliklerimizi de düşünerek.

            1) eğer bilgisayar kazanma durumunda ise ozaman kazanacak hamleyi yapmalısın
            2) eğer oyuncu kazanma durumunda ise, bilgisayar o  durumu bozmalıdır.
            3) eğer orta kare boşsa ozaman ortaya yerleş.
            4) eger 4 köşeden biri boşsa ozaman birine yerleş.
               -eğer oyuncu bir köşeye yerleşmişse o zaman tam karşısındaki kareye yerleş.
            5) eğer tüm köşeleri kaptırmışsan, o zaman kenarlardan boş bir yere yerleş.(aptallığına doyma, anca beraberlik için çalış)

            kuracağımız yapay zekamızın oyuna ait kuramını yaptığımıza göre,  bunları nasıl programlarız neye göre karar aldıracağız

            PUANLAMA
            Böyle board oyunlarında bordu kordinatlarız, yada bordun her karesine bir numara veririz, yada bordun her karesine önemine göre puan veririz. yadaları geçelim sırayla html'in verdiği imkanlar kadar şu tabloları yazalım.

            aklıma ilk gelen tablo numaralandırma her hücreye bir numara vermek oldu.
            1   2   3   
            4   5   6   
            7   8   9   


            2   1   2
            1   3   1
            2   1   2

            sonra tablo hücrelerini önem sırasına göre puanlamak geldi. yukarıdaki gibi puanladım. sonra kazanma durumunu nasıl anlaya bilirim diye düşünüyordum, aslında başından beri düşünüyorum.

            x   .   o
            .   x   o
            x   o   .

            hani olmaz ya böyle saçma bir durumda  her x gördüğüm yere hüçre puanını yazarım, her o gördüğüm yerede hüçre buanını negatif yazarım. sonra yatayda, dikeyde, çaprazlarda toplamına bakarım.

             */
        }
        public int Bitirme()
        {
            //Yatay Sorgu
            if (kare(1) == kare(2) && (kare(1) != null) && (kare(1) == makine) && (kare(3) == null)) return 3; //1=2 >3
            else if (kare(1) == kare(3) && (kare(1) != null) && (kare(1) == makine) && (kare(2) == null)) return 2;//1=3 >2
            else if (kare(2) == kare(3) && (kare(2) != null) && (kare(2) == makine) && (kare(1) == null)) return 1;//2=3 >1
            else if (kare(4) == kare(5) && (kare(4) != null) && (kare(4) == makine) && (kare(6) == null)) return 6;//4=5 >6
            else if (kare(4) == kare(6) && (kare(4) != null) && (kare(4) == makine) && (kare(5) == null)) return 5;//4=6 >5
            else if (kare(5) == kare(6) && (kare(5) != null) && (kare(5) == makine) && (kare(4) == null)) return 4;//5=6 >4
            else if (kare(7) == kare(8) && (kare(7) != null) && (kare(7) == makine) && (kare(9) == null)) return 9;//7=8 >9
            else if (kare(7) == kare(9) && (kare(7) != null) && (kare(7) == makine) && (kare(8) == null)) return 8;//7=9 >8
            else if (kare(8) == kare(9) && (kare(8) != null) && (kare(8) == makine) && (kare(7) == null)) return 7;//8=9 >7
            //Dikey Sorgu
            else if (kare(1) == kare(4) && (kare(1) != null) && (kare(1) == makine) && (kare(7) == null)) return 7;//1=4 >7
            else if (kare(1) == kare(7) && (kare(1) != null) && (kare(1) == makine) && (kare(4) == null)) return 4;//1=7 >4
            else if (kare(4) == kare(7) && (kare(4) != null) && (kare(4) == makine) && (kare(1) == null)) return 1;//4=7 >1
            else if (kare(2) == kare(5) && (kare(2) != null) && (kare(2) == makine) && (kare(8) == null)) return 8;//2=5 >8
            else if (kare(2) == kare(8) && (kare(2) != null) && (kare(2) == makine) && (kare(5) == null)) return 5;//2=8 >5
            else if (kare(5) == kare(8) && (kare(5) != null) && (kare(5) == makine) && (kare(2) == null)) return 2;//5=8 >2
            else if (kare(3) == kare(6) && (kare(3) != null) && (kare(3) == makine) && (kare(9) == null)) return 9;//3=6 >9
            else if (kare(3) == kare(9) && (kare(3) != null) && (kare(3) == makine) && (kare(6) == null)) return 6;//3=9 >6
            else if (kare(6) == kare(9) && (kare(6) != null) && (kare(6) == makine) && (kare(3) == null)) return 3;//6=9 >3
            //Çarpraz Sorgu
            else if (kare(1) == kare(5) && (kare(1) != null) && (kare(1) == makine) && (kare(9) == null)) return 9;//1=5 >9
            else if (kare(1) == kare(9) && (kare(1) != null) && (kare(1) == makine) && (kare(5) == null)) return 5;//1=9 >5
            else if (kare(5) == kare(9) && (kare(5) != null) && (kare(5) == makine) && (kare(1) == null)) return 1;//5=9 >1
            else if (kare(3) == kare(5) && (kare(3) != null) && (kare(3) == makine) && (kare(7) == null)) return 7;//3=5 >7
            else if (kare(3) == kare(7) && (kare(3) != null) && (kare(3) == makine) && (kare(5) == null)) return 5;//3=7 >5
            else if (kare(5) == kare(7) && (kare(5) != null) && (kare(5) == makine) && (kare(3) == null)) return 3;//5=7 >3

            else { return -1; } // Hiçbiri Olmuyorsa

        }
        public int Karsi_Hamle()
        {


            //Yatay Sorgu
            if (kare(1) == kare(2) && (kare(1) != null) && (kare(3) == null)) return 3; //1=2 >3
            else if (kare(1) == kare(3) && (kare(1) != null) && (kare(2) == null)) return 2;//1=3 >2
            else if (kare(2) == kare(3) && (kare(2) != null) && (kare(1) == null)) return 1;//2=3 >1
            else if (kare(4) == kare(5) && (kare(4) != null) && (kare(6) == null)) return 6;//4=5 >6
            else if (kare(4) == kare(6) && (kare(4) != null) && (kare(5) == null)) return 5;//4=6 >5
            else if (kare(5) == kare(6) && (kare(5) != null) && (kare(4) == null)) return 4;//5=6 >4
            else if (kare(7) == kare(8) && (kare(7) != null) && (kare(9) == null)) return 9;//7=8 >9
            else if (kare(7) == kare(9) && (kare(7) != null) && (kare(8) == null)) return 8;//7=9 >8
            else if (kare(8) == kare(9) && (kare(8) != null) && (kare(7) == null)) return 7;//8=9 >7
            //Dikey Sorgu
            else if (kare(1) == kare(4) && (kare(1) != null) && (kare(7) == null)) return 7;//1=4 >7
            else if (kare(1) == kare(7) && (kare(1) != null) && (kare(4) == null)) return 4;//1=7 >4
            else if (kare(4) == kare(7) && (kare(4) != null) && (kare(1) == null)) return 1;//4=7 >1
            else if (kare(2) == kare(5) && (kare(2) != null) && (kare(8) == null)) return 8;//2=5 >8
            else if (kare(2) == kare(8) && (kare(2) != null) && (kare(5) == null)) return 5;//2=8 >5
            else if (kare(5) == kare(8) && (kare(5) != null) && (kare(2) == null)) return 2;//5=8 >2
            else if (kare(3) == kare(6) && (kare(3) != null) && (kare(9) == null)) return 9;//3=6 >9
            else if (kare(3) == kare(9) && (kare(3) != null) && (kare(6) == null)) return 6;//3=9 >6
            else if (kare(6) == kare(9) && (kare(6) != null) && (kare(3) == null)) return 3;//6=9 >3
            //Çarpraz Sorgu
            else if (kare(1) == kare(5) && (kare(1) != null) && (kare(9) == null)) return 9;//1=5 >9
            else if (kare(1) == kare(9) && (kare(1) != null) && (kare(5) == null)) return 5;//1=9 >5
            else if (kare(5) == kare(9) && (kare(5) != null) && (kare(1) == null)) return 1;//5=9 >1
            else if (kare(3) == kare(5) && (kare(3) != null) && (kare(7) == null)) return 7;//3=5 >7
            else if (kare(3) == kare(7) && (kare(3) != null) && (kare(5) == null)) return 5;//3=7 >5
            else if (kare(5) == kare(7) && (kare(5) != null) && (kare(3) == null)) return 3;//5=7 >3

            else { return -1; } // Hiçbiri Olmuyorsa

        }
        public string kare(int n)
        {
            switch (n)
            {
                case 1: return dizi[0, 0];
                case 2: return dizi[0, 1];
                case 3: return dizi[0, 2];
                case 4: return dizi[1, 0];
                case 5: return dizi[1, 1];
                case 6: return dizi[1, 2];
                case 7: return dizi[2, 0];
                case 8: return dizi[2, 1];
                case 9: return dizi[2, 2];
            }
            return "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Yapay_Zeka();
            timer1.Stop();
        }
        public void Bitir(int yol)
        {
            bitti = true;
            switch (yol)
            {
                case 1:
                    button1.BackColor = Color.SteelBlue;
                    button2.BackColor = Color.SteelBlue;
                    button3.BackColor = Color.SteelBlue;
                    break;
                case 2:
                    button4.BackColor = Color.SteelBlue;
                    button5.BackColor = Color.SteelBlue;
                    button6.BackColor = Color.SteelBlue;
                    break;
                case 3:
                    button7.BackColor = Color.SteelBlue;
                    button8.BackColor = Color.SteelBlue;
                    button9.BackColor = Color.SteelBlue;
                    break;
                case 4:
                    button1.BackColor = Color.SteelBlue;
                    button4.BackColor = Color.SteelBlue;
                    button7.BackColor = Color.SteelBlue;
                    break;
                case 5:
                    button2.BackColor = Color.SteelBlue;
                    button5.BackColor = Color.SteelBlue;
                    button8.BackColor = Color.SteelBlue;
                    break;
                case 6:
                    button3.BackColor = Color.SteelBlue;
                    button6.BackColor = Color.SteelBlue;
                    button9.BackColor = Color.SteelBlue;
                    break;
                case 7:
                    button1.BackColor = Color.SteelBlue;
                    button5.BackColor = Color.SteelBlue;
                    button9.BackColor = Color.SteelBlue;
                    break;
                case 8:
                    button3.BackColor = Color.SteelBlue;
                    button5.BackColor = Color.SteelBlue;
                    button7.BackColor = Color.SteelBlue;
                    break;
            }
            MessageBox.Show(sira + " - Kazandı!");
            Engelle();
        }
        public void Degis()
        {
            if (sira == "X") sira = "O";
            else sira = "X";

            if (bitti) lblsoyuncu.Text = "-";
            else lblsoyuncu.Text = sira;
        }
        public void Engelle()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = sira;
            dizi[0, 0] = sira;
            Kontrol();
            Degis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Text = sira;
            dizi[0, 1] = sira;
            Kontrol();
            Degis();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button3.Text = sira;
            dizi[0, 2] = sira;
            Kontrol();
            Degis();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button4.Text = sira;
            dizi[1, 0] = sira;
            Kontrol();
            Degis();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button5.Text = sira;
            dizi[1, 1] = sira;
            Kontrol();
            Degis();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button6.Text = sira;
            dizi[1, 2] = sira;
            Kontrol();
            Degis();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button7.Text = sira;
            dizi[2, 0] = sira;
            Kontrol();
            Degis();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button8.Text = sira;
            dizi[2, 1] = sira;
            Kontrol();
            Degis();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Enabled = false;
            button9.Text = sira;
            dizi[2, 2] = sira;
            Kontrol();
            Degis();
        }


    }
}
