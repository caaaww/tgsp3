using perpus.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpus.penjaga
{
    public sealed class LibraryManager
    {
        private static readonly LibraryManager _instance = new LibraryManager();
        private readonly List<buku> _books = new List<buku>();
        private readonly List<User> _users = new List<User>();
        private readonly List<pinjaman> _loans = new List<pinjaman>();
        // Private constructor untuk mencegah instansiasi luar
        private LibraryManager() { }
        public static LibraryManager Instance => _instance;
        // Tambah buku baru
        public void Addbuku(buku buku)
        {
            _books.Add(buku
                );
        }
        // Tambah pengguna baru
        public void AddUser(User user)
        {
            _users.Add(user);
        }
        // Proses peminjaman buku
        public bool peminjaman(string Idbuku, int userId)
        {
            var buku = _books.FirstOrDefault(b => b.idbuku == Idbuku && b.IsAvailable);
            var user = _users.FirstOrDefault(u => u.Iduser == userId);
            if (buku == null || user == null)
                return false;
            buku.IsAvailable = false;
            var loan = new pinjaman(buku, user);
            _loans.Add(loan);
            return true;
        }
        // Proses pengembalian buku
        public bool ReturnBook(string Idbuku, int userId)
        {
            var loan = _loans.FirstOrDefault(l => l.buku.idbuku == Idbuku && l.User.Iduser == userId && l.ReturnDate == null);
            if (loan == null)
                return false;
            loan.ReturnBook();
            return true;
        }
        // Mendapatkan daftar buku yang tersedia
        public List<buku> GetAvailableBooks()
        {
            return _books.Where(b => b.IsAvailable).ToList();
        }
        // Mendapatkan daftar semua pengguna
        public List<User> GetUsers()
        {
            return _users.ToList();
        }
    }
}

