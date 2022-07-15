using TravelBooking;


List<PrenotazioneVolo> listaPrenotazioni = new List<PrenotazioneVolo>();

Random randomFlightCode = new Random();
long codiceVolo = randomFlightCode.Next(1000000000);

Random randomPlaneCode = new Random();
long codiceRandomAereo = randomPlaneCode.Next(100000);



// ----------------------------------- Programma ---------------------------------



var clienteNuovo = DatiCliente();

//Cliente userX = new Cliente(clienteNuovo.Nome, clienteNuovo.Cognome, clienteNuovo.CodiceFiscale, clienteNuovo.Email, clienteNuovo.Sesso, clienteNuovo.RecapitoTelefonico, clienteNuovo.Indirizzo);

DescrizioneCliente(clienteNuovo);

Console.WriteLine("Digita 0 per prenotare un volo SOLO ANDATA  -  Digita 1 per prenotare un volo ANDATA E RITORNO");

bool sceltaAndataeRitornoUser = bool.Parse(Console.ReadLine());

if (sceltaAndataeRitornoUser == false)
{
    Aeroporto sceltaAeroportoPartenza = SceltaAeroportoPartenza();
    Aeroporto sceltaAeroportoArrivo = SceltaAeroportoArrivo();

    StampaTratta(sceltaAeroportoPartenza, sceltaAeroportoArrivo);

}
else if (sceltaAndataeRitornoUser == true)
{
    Aeroporto sceltaAeroportoPartenza = SceltaAeroportoPartenza();
    Aeroporto sceltaAeroportoArrivo = SceltaAeroportoArrivo();

    Aeroporto sceltaAeroportoPartenzaRitorno = SceltaAeroportoArrivo();
    Aeroporto sceltaAeroportoArrivoRitorno = SceltaAeroportoPartenza();

    StampaTrattaConRitorno(sceltaAeroportoPartenza, sceltaAeroportoArrivo, sceltaAeroportoPartenzaRitorno, sceltaAeroportoArrivoRitorno);
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
    Console.Write("Scegli il tuo aeroporto di partenza: ");
    string luogoAeroportoDiPartenza = Console.ReadLine();
    Aeroporto aereoportoDiPartenza = new Aeroporto(luogoAeroportoDiPartenza);
    return aereoportoDiPartenza;
}

Aeroporto SceltaAeroportoArrivo()
{
    Console.Write("Scegli il tuo aeroporto di partenza: ");
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

    Console.WriteLine($"Aeroporto di partenza:{aeroportoTakeOff}");
    Console.WriteLine($"Aeroporto di arrivo: {aeroportoLanding}");
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
    Tratta trattaSelezionataRitorno = new Tratta(aeroportoTakeOff, aeroportoLanding);
    double costoTrattaSelezionataRitorno = trattaSelezionataRitorno.CostoTratta;
    int durataTrattaSelezionataRitorno = trattaSelezionataRitorno.durataTratta;

    Console.WriteLine();
    Console.WriteLine("Di seguito puoi trovare la tratta che hai scelto : ");
    Console.WriteLine();
    Console.WriteLine("Andata");
    Console.WriteLine();
    Console.WriteLine($"Aeroporto di partenza:{aeroportoTakeOff}");
    Console.WriteLine($"Aeroporto di arrivo: {aeroportoLanding}");
    Console.WriteLine($"La durata del volo è di: {durataTrattaSelezionata} minuti");
    Console.WriteLine($"Costo tratta : {costoTrattaSelezionata} euro");
    Console.WriteLine();
    Console.WriteLine("Ritorno");
    Console.WriteLine();
    Console.WriteLine($"Aeroporto di partenza:{aeroportoTakeOffBack}");
    Console.WriteLine($"Aeroporto di arrivo: {aeroportoLandingBack}");
    Console.WriteLine($"La durata del volo è di: {durataTrattaSelezionataRitorno} minuti");
    Console.WriteLine($"Costo tratta : {costoTrattaSelezionataRitorno} euro");

    Tratta newTrack = new Tratta(aeroportoTakeOff, aeroportoLanding);

    return newTrack;
}















/*

bool dataCorretta = false;
while (!dataCorretta)
{
    DateTime dataOraAppuntamento = InserisciDataPartenza();
    try
    {
        listaPrenotazioni.Add(new PrenotazioneVolo());
        dataCorretta = true;
    }
    catch (InvalidDataException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

*/













DateTime InserisciDataPartenza()
{
    bool formatoDataCorretto = false;
    DateTime dataOra = DateTime.Now;
    while (!formatoDataCorretto)
    {
        Console.WriteLine("Aggiungi la data e l'ora nella quale vorresti prenotare il tuo volo: [gg/mm/aaaa hh:mm]");

        try
        {
            dataOra = DateTime.Parse(Console.ReadLine());
            formatoDataCorretto = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Il formato della data non è corretto");
        }
    }
    return dataOra;
}