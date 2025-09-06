using System;
using perpus.models;
using perpus.penjaga;

namespace manajemenperpus
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = LibraryManager.Instance;

            // Tambah buku contoh
            library.Addbuku(new buku("012345", "tutorial memasak", "caca"));
            library.Addbuku(new buku("12345", "tutorial pbo", "ica"));

            // Tambah pengguna contoh
            library.AddUser(new User(1, "dio"));
            library.AddUser(new User(2, "nugraha"));

            while (true)
            {
                Console.WriteLine("\n=== Sistem Manajemen Perpustakaan ===");
                Console.WriteLine("1. Tampilkan buku tersedia");
                Console.WriteLine("2. Pinjam buku");
                Console.WriteLine("3. Kembalikan buku");
                Console.WriteLine("4. Keluar");
                Console.Write("Pilih menu (1-4): ");

                var input = Console.ReadLine();

                if (input == "1")

                {
                    Console.Clear();
                    bukutersedia(library);
                }
                else if (input == "2")
                {
                    Console.Clear();
                    LoanBook(library);
                }
                else if (input == "3")
                {
                    ReturnBook(library);
                }
                else if (input == "4")
                {
                    Console.WriteLine("Terima kasih telah menggunakan sistem.");
                    return;
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid, coba lagi.");
                }
            }
        }

        static void bukutersedia(LibraryManager perpus2)
        {
            var buku2 = perpus2.GetAvailableBooks();
            if (buku2.Count == 0)
            {
                Console.WriteLine("Tidak ada buku tersedia.");
                return;
            }

            Console.WriteLine("\nBuku tersedia:");
            foreach (var buku in buku2)
            {
                Console.WriteLine($"id buku: {buku.idbuku} | Judul: {buku.judul} | Penulis: {buku.penulis}");
            }
        }

        static void LoanBook(LibraryManager library)
        {
            Console.Write("Masukkan User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("User  ID tidak valid.");
                return;
            }

            Console.Write("Masukkan id buku yang ingin dipinjam: ");
            string idbuku = Console.ReadLine();

            bool success = library.peminjaman(idbuku, userId);
            Console.WriteLine(success ? "Peminjaman berhasil." : "Peminjaman gagal. Pastikan id buku dan User ID benar, dan buku tersedia.");
        }

        static void ReturnBook(LibraryManager library)
        {
            Console.Write("Masukkan User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("User  ID tidak valid.");
                return;
            }

            Console.Write("Masukkan id buku yang ingin dikembalikan: ");
            string idbuku = Console.ReadLine();

            bool success = library.ReturnBook(idbuku, userId);
            Console.WriteLine(success ? "Pengembalian berhasil." : "Pengembalian gagal. Pastikan id buku dan User ID benar, dan buku sedang dipinjam.");
        }
    }
}