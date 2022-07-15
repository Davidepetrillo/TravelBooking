using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBooking
{
    internal class PrenotazioneVolo
    {
        public string CodicePrenotazione;
        public Cliente ClienteX { get; set; }
        public Tratta NewTrack { get; set; }       
        public DateTime DataPartenza { get; set; }
        public Tratta NewTrackBack { get; set; }
        public DateTime DataRitorno { get; set; }
        public double CostoTratta { get; set; }
        public Pagamento PagamentoX { get; set; }


        public long GetCodicePrenotazione()
        {
            Random random = new Random();
            long codice = random.Next(1000000000);
            return codice;
        }
        public PrenotazioneVolo(Cliente clienteX, Tratta newTrack,  DateTime dataPartenza, double costoTratta, Pagamento pagamentoX)
        {

            this.ClienteX = clienteX;

            this.NewTrack = newTrack;

            /*
             * if (DataPartenza < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }
            */

            this.DataPartenza = dataPartenza;
        
            this.CostoTratta = costoTratta;

            this.PagamentoX = pagamentoX;
        }

        public PrenotazioneVolo(Cliente clienteX, Tratta newTrack, Tratta newTrackBack, DateTime dataPartenza, DateTime dataRitorno, double costoTratta, Pagamento pagamentoX)
        {

            this.ClienteX = clienteX;


            if (DataPartenza < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }

            this.DataPartenza = dataPartenza;

            DateTime intervalloMinimoPerRitorno = dataPartenza.AddHours(3);

            if (DataRitorno < (intervalloMinimoPerRitorno))
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }

            this.DataRitorno = dataRitorno;

            this.CostoTratta = costoTratta;

            this.PagamentoX = pagamentoX;


        }

    }
}
