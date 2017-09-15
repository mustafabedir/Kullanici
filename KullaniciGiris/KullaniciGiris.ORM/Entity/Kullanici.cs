using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciGiris.ORM.Entity
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSifre { get; set; }
    }
}
