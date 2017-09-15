using KullaniciGiris.ORM.Entity;
using KullaniciGiris.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KullaniciGiris.FORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAd = textBox1.Text;
            kullanici.KullaniciSifre = textBox2.Text;

            if (Kullanicilar.KullaniciDenetim(kullanici) == true)
            {
                MessageBox.Show("Giriş Başarılı");
                KullaniciGoruntule kg = new KullaniciGoruntule();
                kg.Show();
            }

            else
            {
                MessageBox.Show("Hata Alındı");
            }

        }
    }
}
