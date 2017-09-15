using KullaniciGiris.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciGiris.ORM.Facade
{
    public class Kullanicilar
    {
        public static bool KullaniciDenetim(Kullanici kullanici)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = Tools.Baglanti;
            komut.CommandText = "exec sp_KullaniciDenetim @KullaniciAd, @KullaniciSifre";
            komut.Parameters.AddWithValue("@KullaniciAd", kullanici.KullaniciAd);
            komut.Parameters.AddWithValue("@KullaniciSifre", kullanici.KullaniciSifre);

            return Tools.ExecuteReader(komut);
        }

        public static DataTable Select()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("exec sp_KullaniciGoruntule", Tools.Baglanti);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }

        public static bool Insert(Kullanici kullanici)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "exec sp_KullaniciEkle @KAdi, @KSifre";
            komut.Parameters.AddWithValue("@KAdi", kullanici.KullaniciAd);
            komut.Parameters.AddWithValue("KSifre", kullanici.KullaniciSifre);
            komut.Connection = Tools.Baglanti;

            return Tools.ExecuteNonQuery(komut); 
        }

        public static bool Delete(Kullanici kullanici)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = Tools.Baglanti;
            komut.CommandText = "exec sp_KullaniciSil @Kid";
            komut.Parameters.AddWithValue("Kid", kullanici.KullaniciID);

            return Tools.ExecuteNonQuery(komut);
        }

        public static bool Update(Kullanici kullanici)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "exec sp_KullaniciDuzenle @Kid, @Kad, @Ksifre";
            komut.Parameters.AddWithValue("@Kid", kullanici.KullaniciID);
            komut.Parameters.AddWithValue("@Kad", kullanici.KullaniciAd);
            komut.Parameters.AddWithValue("@Ksifre", kullanici.KullaniciSifre);
            komut.Connection = Tools.Baglanti;

            return Tools.ExecuteNonQuery(komut);
        }
    }
}
