using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBooking
{
    internal class Pagamento
    {
        public Tratta TrattaSceltaDalCliente { get; set; }
        public string IBANcarta { get; set; }

        private int CvcCarta;

        public Cliente ClienteX;

        public int GetCvc()
        {
            this.CvcCarta = 234;
            return CvcCarta;
        }

        public Pagamento(string IBAN, int cvc, Cliente cliente, Tratta trattaSceltaDalCliente)
        {

            if (IBAN.Length != 26)
            {
                throw new Exception("L'IBAN non contiene l'esatto numero di caratteri");
            }

            this.IBANcarta = IBAN;

            if (cvc != 234)
            {
                throw new Exception("Il cvc non è corretto");
            }
            this.CvcCarta = cvc;

            this.ClienteX = cliente;

            this.TrattaSceltaDalCliente = trattaSceltaDalCliente;

        }

    }
}
