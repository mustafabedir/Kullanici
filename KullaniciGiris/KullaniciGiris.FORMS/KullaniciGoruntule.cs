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
    public partial class KullaniciGoruntule : Form
    {
        public KullaniciGoruntule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Kullanicilar.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAd = textBox1.Text;
            kullanici.KullaniciSifre = textBox2.Text;

            Kullanicilar.Insert(kullanici);
            dataGridView1.DataSource = Kullanicilar.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);

            if (Kullanicilar.Delete(kullanici))
            {
                MessageBox.Show("Kullanıcı Silindi");
                dataGridView1.DataSource = Kullanicilar.Select();
            }

            else
                MessageBox.Show("Silme İşleminde Hata Oldu");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);
            kullanici.KullaniciAd = textBox1.Text;
            kullanici.KullaniciSifre = textBox2.Text;

            if (Kullanicilar.Update(kullanici))
            {
                MessageBox.Show("Düzenleme Başarılı");
                dataGridView1.DataSource = Kullanicilar.Select();
            }
            else
                MessageBox.Show("Düzenleme İşleminde Hata Oldu");
        }
    }
}
