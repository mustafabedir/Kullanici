using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciGiris.ORM
{
    public class Tools
    {
        private static SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=KullaniciGiris;Integrated Security=True");
        public static SqlConnection Baglanti
        {
            get
            {
                return baglanti;
            }
            set
            {
                baglanti = value;
            }
        }
        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                    return komut.ExecuteNonQuery() > 0;
                }
                else
                    return komut.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if(komut.Connection.State!=ConnectionState.Closed)
                {
                    komut.Connection.Close();
                }
            }
        }

        public static bool ExecuteReader(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    SqlDataReader reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception)
            {
                return false;
            }

            finally
            {
                if(komut.Connection.State != ConnectionState.Closed)
                {
                    komut.Connection.Close();
                }
            }
        }

    }
}
