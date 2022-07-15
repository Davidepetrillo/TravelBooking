using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBooking
{
    /*
    internal class Movimenti
    {
        public PrenotazioneVolo voloPrenotato { get; set; }
        public Cliente clienteX { get; set; }

        public Movimenti(PrenotazioneVolo voloPrenotato, Cliente clienteX)
        {
            this.voloPrenotato = voloPrenotato;
            this.clienteX = clienteX;
        }

        public int Acquisto(PrenotazioneVolo voloPrenotato, Cliente clienteX)
        {
            if ((voloPrenotato.NumeroPostiDisponibili < 0) || (voloPrenotato.NumeroPostiPrenotati > voloPrenotato.NumeroPostiDisponibili))
            {
                throw new Exception("Mi dispiace ma l'operazione non è disponibile");
            }
            else
            {
                voloPrenotato.NumeroPostiDisponibili = voloPrenotato.NumeroPostiDisponibili - voloPrenotato.NumeroPostiPrenotati;
            }

            return voloPrenotato.NumeroPostiDisponibili;
        }
    }
     */
}
