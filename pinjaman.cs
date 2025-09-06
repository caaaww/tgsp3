using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpus.models
{
    public class pinjaman
    {
        public buku buku { get; }
        public User User { get; }
        public DateTime tanggalpinjam { get; }
        public DateTime? ReturnDate { get; private set; }
        public pinjaman(buku buku2, User user)
        {
            buku = buku2;
            User = user;
            tanggalpinjam = DateTime.Now;
            ReturnDate = null;
        }
        public void ReturnBook()
        {
            ReturnDate = DateTime.Now;
            buku.IsAvailable = true;
        }
    }
}
