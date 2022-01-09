using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectMobil.Models
{
    public class Programari
    {
        [PrimaryKey, AutoIncrement]
        public int Id_programare { get; set; }
        public string Nume_client { get; set; }
        public string Serviciu { get; set; }
        public DateTime Data_programare { get; set; }
        public int Ora_Programare { get; set; }
        public int Telefon { get; set; }

        public int Id_salon { get; set; }

    }
}
