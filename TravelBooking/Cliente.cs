using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBooking
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Email { get; set; }
        public string Sesso { get; set; }
        public long RecapitoTelefonico { get; set; }
        public string Indirizzo { get; set; }


        public Cliente(string nome, string cognome, string codiceFiscale, string email, string sesso, long recapitoTelefonico, string indirizzo)
        {
            this.Nome = nome;
            this.Cognome = cognome;

            if (codiceFiscale.Length != 16)
            {
                throw new Exception("Il codice fiscale non contiene l'esatto numero di caratteri");
            }

            this.CodiceFiscale = codiceFiscale;

            this.Email = email;

            this.Sesso = sesso;

            if (RecapitoTelefonico > 9999999999)
            {
                throw new Exception("Il numero di telefono da lei inserito non contiene l'esatto numero di caratteri");
            }

            this.RecapitoTelefonico = recapitoTelefonico;

            this.Indirizzo = indirizzo;
        }

    }
}
