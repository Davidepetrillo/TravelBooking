using TravelBooking;


List<PrenotazioneVolo> listaPrenotazioni = new List<PrenotazioneVolo>();

Random randomFlightCode = new Random();
long codiceVolo = randomFlightCode.Next(1000000000);

Random randomPlaneCode = new Random();
long codiceRandomAereo = randomPlaneCode.Next(100000);



// ----------------------------------- Programma ---------------------------------



Cliente clienteNuovo = DatiCliente();
DescrizioneCliente(clienteNuovo);

DateTime dataPartenza = InserisciData();

Console.WriteLine("Digita 0 per prenotare un volo SOLO ANDATA  -  Digita 1 per prenotare un volo ANDATA E RITORNO");
string sceltaAndataeRitornoUser = Console.ReadLine();


if (sceltaAndataeRitornoUser == "0")
{

    Aeroporto sceltaAeroportoPartenza = SceltaAeroportoPartenza();
    Aeroporto sceltaAeroportoArrivo = SceltaAeroportoArrivo();

    Tratta trattaSceltaDalCliente = StampaTratta(sceltaAeroportoPartenza, sceltaAeroportoArrivo);
    Console.WriteLine($"Giorno e ora della partenza: {dataPartenza}");

    Console.WriteLine($"Procedere con l'acquisto [Si/No] ?");
    string avanzamentoAlPagamento = Console.ReadLine();

    if (avanzamentoAlPagamento == "Si")
    {
        Pagamento pagamentoX = inserimentoPagamento(clienteNuovo, trattaSceltaDalCliente);
        PrenotazioneVolo prenotazioneEffettuata = new PrenotazioneVolo(clienteNuovo, trattaSceltaDalCliente, dataPartenza, trattaSceltaDalCliente.CostoTratta, pagamentoX);
        FatturaPrenotazione(prenotazioneEffettuata);

    }
    else if (avanzamentoAlPagamento == "No")
    {
        Console.WriteLine("La ringraziamo per il suo tempo dedicato a noi. Speriamo di rivederla presto");
    }


}
else if (sceltaAndataeRitornoUser == "1")
{
    Aeroporto sceltaAeroportoPartenza = SceltaAeroportoPartenza();
    Aeroporto sceltaAeroportoArrivo = SceltaAeroportoArrivo();

    Tratta trattaSceltaDalCliente = StampaTrattaConRitorno(sceltaAeroportoPartenza, sceltaAeroportoArrivo, sceltaAeroportoArrivo, sceltaAeroportoPartenza);
    Console.WriteLine($"Giorno e ora della partenza: {dataPartenza}");

    Console.WriteLine($"Procedere con l'acquisto [Si/No] ?");
    string avanzamentoAlPagamento = Console.ReadLine();

    if (avanzamentoAlPagamento == "Si")
    {
        inserimentoPagamento(clienteNuovo, trattaSceltaDalCliente);
    }
    else if (avanzamentoAlPagamento == "No")
    {
        Console.WriteLine("La ringraziamo per il suo tempo dedicato a noi. Speriamo di rivederla presto");
    }
}




// ------------------------------------------- Funzioni --------------------------------------



Cliente DatiCliente()
{
    Console.WriteLine("---------- Benvenuto nella nostra agenzia Viaggi! ----------");
    Console.WriteLine();
    Console.WriteLine("Per usufruire dei nostri servizi è necessario autentificarsi.");
    Console.WriteLine();
    Console.Write("Inserisci il tuo nome: ");
    string nomeNuovoCliente = Console.ReadLine();
    Console.Write("Inserisci il tuo cognome: ");
    string cognomeNuovoCliente = Console.ReadLine();
    Console.Write("Inserisci il tuo codice fiscale: ");
    string codiceFiscaleNuovoCliente = Console.ReadLine();
    Console.Write("Inserisci la tua email: ");
    string emailNuovoCliente = Console.ReadLine();
    Console.Write("Inserisci il tuo sesso: ");
    string sessoNuovoCliente = Console.ReadLine();
    Console.Write("Inserisci il tuo numero di telefono: ");
    long numeroTelefonoNuovoCliente = long.Parse(Console.ReadLine());
    Console.Write("Inserisci il tuo indirizzo: ");
    string indirizzoNuovoCliente = Console.ReadLine();
    Console.WriteLine();


    Cliente clienteNuovo = new Cliente(nomeNuovoCliente, cognomeNuovoCliente, codiceFiscaleNuovoCliente, emailNuovoCliente, sessoNuovoCliente, numeroTelefonoNuovoCliente, indirizzoNuovoCliente);
    return clienteNuovo;
}


void DescrizioneCliente(Cliente clienteX)
{
    Console.WriteLine();
    Console.WriteLine("----- I tuoi dati -------");
    Console.WriteLine("Nome: " + clienteX.Nome);
    Console.WriteLine("Cognome: " + clienteX.Cognome);
    Console.WriteLine("Codice Fiscale: " + clienteX.CodiceFiscale);
    Console.WriteLine($"Email: {clienteX.Email}");
    Console.WriteLine($"Sesso: {clienteX.Sesso}");
    Console.WriteLine($"Recapito telefonico: {clienteX.RecapitoTelefonico}");
    Console.WriteLine($"Indirizzo: {clienteX.Indirizzo}");
    Console.WriteLine("------------------");
    Console.WriteLine();
}




Aeroporto SceltaAeroportoPartenza()
{
    Console.Write("Scegli il tuo aeroporto di partenza [Napoli - Roma - Milano] : ");
    string luogoAeroportoDiPartenza = Console.ReadLine();
    Aeroporto aereoportoDiPartenza = new Aeroporto(luogoAeroportoDiPartenza);
    return aereoportoDiPartenza;
}

Aeroporto SceltaAeroportoArrivo()
{
    Console.Write("Scegli il tuo aeroporto di arrivo [Napoli - Roma - Milano] : ");
    string luogoAeroportoDiArrivo = Console.ReadLine();
    Aeroporto aereoportoDiArrivo = new Aeroporto(luogoAeroportoDiArrivo);
    return aereoportoDiArrivo;
}


Tratta StampaTratta(Aeroporto aeroportoTakeOff, Aeroporto aeroportoLanding)
{
    Tratta trattaSelezionata = new Tratta(aeroportoTakeOff, aeroportoLanding);
    double costoTrattaSelezionata = trattaSelezionata.CostoTratta;
    int durataTrattaSelezionata = trattaSelezionata.durataTratta;
    Console.WriteLine();
    Console.WriteLine("Di seguito puoi trovare la tratta che hai scelto : ");
    Console.WriteLine();

    Console.WriteLine($"Aeroporto di partenza:{aeroportoTakeOff.LuogoDellAeroporto}");
    Console.WriteLine($"Aeroporto di arrivo: {aeroportoLanding.LuogoDellAeroporto}");
    Console.WriteLine($"La durata del volo è di: {durataTrattaSelezionata} minuti");
    Console.WriteLine($"Costo tratta : {costoTrattaSelezionata} euro");

    Tratta newTrack = new Tratta(aeroportoTakeOff, aeroportoLanding);

    return newTrack;
}

Tratta StampaTrattaConRitorno(Aeroporto aeroportoTakeOff, Aeroporto aeroportoLanding, Aeroporto aeroportoTakeOffBack, Aeroporto aeroportoLandingBack)
{
    Tratta trattaSelezionataAndata = new Tratta(aeroportoTakeOff, aeroportoLanding);
    double costoTrattaSelezionata = trattaSelezionataAndata.CostoTratta;
    int durataTrattaSelezionata = trattaSelezionataAndata.durataTratta;
    aeroportoTakeOffBack = aeroportoLanding;
    aeroportoLandingBack = aeroportoTakeOff;

    Tratta trattaSelezionataRitorno = new Tratta(aeroportoTakeOffBack, aeroportoLandingBack);
    double costoTrattaSelezionataRitorno = trattaSelezionataRitorno.CostoTratta;
    int durataTrattaSelezionataRitorno = trattaSelezionataRitorno.durataTratta;

    Console.WriteLine();
    Console.WriteLine("Di seguito puoi trovare la tratta che hai scelto : ");
    Console.WriteLine();
    Console.WriteLine("Andata");
    Console.WriteLine();
    Console.WriteLine($"Aeroporto di partenza:{aeroportoTakeOff.LuogoDellAeroporto}");
    Console.WriteLine($"Aeroporto di arrivo: {aeroportoLanding.LuogoDellAeroporto}");
    Console.WriteLine($"La durata del volo è di: {durataTrattaSelezionata} minuti");
    Console.WriteLine($"Costo tratta : {costoTrattaSelezionata} euro");
    Console.WriteLine();
    Console.WriteLine("Ritorno");
    Console.WriteLine();
    Console.WriteLine($"Aeroporto di partenza:{aeroportoTakeOffBack.LuogoDellAeroporto}");
    Console.WriteLine($"Aeroporto di arrivo: {aeroportoLandingBack.LuogoDellAeroporto}");
    Console.WriteLine($"La durata del volo è di: {durataTrattaSelezionataRitorno} minuti");
    Console.WriteLine($"Costo tratta : {costoTrattaSelezionataRitorno} euro");
    Console.WriteLine();

    Console.WriteLine($"Costo totale: {costoTrattaSelezionata + costoTrattaSelezionataRitorno} euro");

    Tratta newTrack = new Tratta(aeroportoTakeOff, aeroportoLanding, aeroportoTakeOffBack, aeroportoLandingBack);

    return newTrack;
}



Pagamento inserimentoPagamento(Cliente clienteX, Tratta trattaSceltaDalCliente)
{

    Console.WriteLine("Inserire i suoi dati per il pagamento:");
    Console.WriteLine();
    Console.WriteLine("Nome sulla carta: " + clienteX.Nome);
    Console.WriteLine("Cognome sulla carta: " + clienteX.Cognome);
    Console.WriteLine($"Indirizzo di fatturazione: {clienteX.Indirizzo}");
    Console.Write($"Inserire l'IBAN: ");
    string ibanClienteX = Console.ReadLine();
    Console.Write($"Inserire il CVC: ");
    int cvcClienteX = int.Parse(Console.ReadLine());

    Console.WriteLine("Pagamento effettuato correttamente! Grazie per aver scelto il nostro servizio!");

    Pagamento pagamentoEffettuato = new Pagamento(ibanClienteX, cvcClienteX, clienteX, trattaSceltaDalCliente);
    return pagamentoEffettuato;

}

DateTime InserisciData()
{
    bool formatoDataCorretto = false;
    DateTime dataVolo = DateTime.Now;
    while (!formatoDataCorretto)
    {
        Console.WriteLine("Aggiungi la data nella quale vorresti prenotare il tuo volo: [gg/mm/aaaa hh:mm]");

        try
        {
            dataVolo = DateTime.Parse(Console.ReadLine());
            formatoDataCorretto = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Il formato della data non è corretto");
        }
    }
    return dataVolo;
}


void FatturaPrenotazione(PrenotazioneVolo prenotazioneX)
{
    Console.WriteLine("------------------------- Prenotazione -------------------------");
    Console.WriteLine();
    Console.WriteLine("Nome: " + prenotazioneX.ClienteX.Nome);
    Console.WriteLine("Cognome: " + prenotazioneX.ClienteX.Cognome);
    Console.WriteLine("Codice Fiscale: " + prenotazioneX.ClienteX.CodiceFiscale);
    Console.WriteLine($"Email: {prenotazioneX.ClienteX.Email}");
    Console.WriteLine($"Sesso: {prenotazioneX.ClienteX.Sesso}");
    Console.WriteLine($"Recapito telefonico: {prenotazioneX.ClienteX.RecapitoTelefonico}");
    Console.WriteLine($"Indirizzo: {prenotazioneX.ClienteX.Indirizzo}");
    Console.WriteLine();

}