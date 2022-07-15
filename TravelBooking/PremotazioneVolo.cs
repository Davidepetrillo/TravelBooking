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
        public string AeroportoPartenza { get; set; }
        public string AeroportoArrivo { get; set; }
        public DateTime DataPartenza { get; set; }
        public DateTime OrarioPartenza { get; set; }
        public DateTime OrarioArrivo { get; set; }
        public Tratta NewTrackBack { get; set; }
        public DateTime DataRitorno { get; set; }
        public DateTime OrarioPartenzaRitorno { get; set; }
        public DateTime OrarioArrivoRitorno { get; set; }
        public string AeroportoPartenzaRitorno { get; set; }
        public string AeroportoArrivoRitorno { get; set; }
        public int NumeroPostiDisponibili { get; set; }
        public int NumeroPostiPrenotati { get; set; }
        public double CostoTrattaAndata { get; set; }
        public double CostoTrattaRitorno { get; set; }


        public long GetCodicePrenotazione()
        {
            Random random = new Random();
            long codice = random.Next(1000000000);
            return codice;
        }
        public PrenotazioneVolo(string codicePrenotazione, Cliente clienteX, Tratta newTrack, string aeroportoPartenza, string aeroportoArrivo, DateTime dataPartenza, DateTime orarioPartenza, DateTime orarioArrivo, int numeroPostDisponibili, int numeroPostiPrenotati, double costoTratta)
        {
            this.CodicePrenotazione = codicePrenotazione;

            this.ClienteX = clienteX;

            this.NewTrack = newTrack;

            this.AeroportoPartenza = aeroportoPartenza;

            this.AeroportoArrivo = aeroportoArrivo;

            if (DataPartenza < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }

            this.DataPartenza = dataPartenza;

            this.OrarioPartenza = orarioPartenza;

            this.OrarioArrivo = orarioArrivo;

            this.NumeroPostiDisponibili = numeroPostDisponibili;

            if (numeroPostiPrenotati > numeroPostDisponibili)
            {
                throw new Exception("Non è possibile prenotare il numero di posti da lei selezionato per questo volo");
            }
            this.NumeroPostiPrenotati = numeroPostiPrenotati;

            this.CostoTrattaAndata = costoTratta;
        }

        public PrenotazioneVolo(string codicePrenotazione, Cliente clienteX, Tratta newTrack, Tratta newTrackBack, string aeroportoPartenza, string aeroportoArrivo, string aeroportoPartenzaRitorno, string aeroportoArrivoRitorno, DateTime dataPartenza, DateTime dataRitorno, DateTime orarioPartenza, DateTime orarioArrivo, DateTime orarioPartenzaRitorno, DateTime orarioArrivoRitorno, int numeroPostiDisponibili, int numeroPostiPrenotati, double costoTrattaAndata, double costoTrattaRitorno)
        {
            this.CodicePrenotazione = codicePrenotazione;

            this.ClienteX = clienteX;

            this.AeroportoPartenza = aeroportoPartenza;

            this.AeroportoPartenzaRitorno = aeroportoPartenzaRitorno;

            this.AeroportoArrivo = aeroportoArrivo;

            this.AeroportoArrivoRitorno = aeroportoArrivoRitorno;

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

            this.OrarioPartenzaRitorno = orarioPartenzaRitorno;

            this.OrarioArrivoRitorno = orarioArrivoRitorno;

            this.NumeroPostiDisponibili = numeroPostiDisponibili;

            if (numeroPostiPrenotati > numeroPostiDisponibili)
            {
                throw new Exception("Non è possibile prenotare il numero di posti da lei selezionato per questo volo");
            }
            this.NumeroPostiPrenotati = numeroPostiPrenotati;

            this.CostoTrattaAndata = costoTrattaAndata;

            this.CostoTrattaRitorno = costoTrattaRitorno;

        }

    }
}
