using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpus.models
{
    public class User
    {
        public int Iduser { get; }
        public string Nama { get; }
        public User(int IdUser, string nama)
        {
            Iduser = IdUser;
            Nama = nama;
        }
    }
}
