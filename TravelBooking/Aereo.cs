using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBooking
{
    internal class Aereo
    {
        public string Produttore { get; set; }
        public string Modello { get; set; }

        public string CodiceIdentificativo;

        public string GetCodiceIdentificativo()
        {
            Random random = new Random();
            long codiceRandomAereo = random.Next(100000);
            CodiceIdentificativo = Produttore + " " + Modello + " " + codiceRandomAereo;
            return CodiceIdentificativo;
        }

        public Aereo(string produttore, string modello)
        {
            this.Produttore = produttore;
            this.Modello = modello;
        }

    }
}
