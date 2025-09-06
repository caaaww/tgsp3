using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpus.models
{
    public class buku
    {
        public string idbuku { get; }
        public string judul { get; }
        public string penulis { get; }
        public bool IsAvailable { get; set; }
        public buku(string Idbuku, string judul, string penulis)
        {
            idbuku = Idbuku;
            judul = judul;
            penulis = penulis;
            IsAvailable = true;
        }
    }
}
