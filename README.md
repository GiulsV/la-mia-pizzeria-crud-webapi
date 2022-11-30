# la-mia-pizzeria-crud-webapi


30/11/2022

Il rapporto con i clienti è importante…quindi perchè non permettergli di inviarci dei messaggi?

Creiamo il nostro model Message e relativa migration per gestire i seguenti dati
	- Email dell’utente
	- nome dell’utente
	- titolo del messaggio
	- testo del messaggio

Create una nuova pagina di contatto nel vostro GuestController che gestisca la costruzione del form di contatto.

Creiamo un nuovo ApiController per gestire la chiamata post che faremo con axios + js all’interno della pagina di contatto.

Bonus: 
provare a gestire anche la gestione degli errori di validazione sfruttando gli oggetti del model state. (quindi con javascript nella sezione catch di axios)


29/11/2022

La nostra pizzeria è quasi conclusa...ma...come fanno i nostri clienti a trovare una pizza se ne abbiamo tante nel nostro menu?

Dobbiamo dargli la possibilità di ricercarle con un filtro.

Modifichiamo quindi la pagina index di GuestController, aggiungendo un text input di ricerca. 
Ogni volta che viene scritto qualcosa, il sistema deve interrogare le nostre WebApi chiedendo indietro le pizze che contengono nel titolo quello che ha chiesto l’utente, 
e mostriamo in pagina i risultati filtrati.

Al click della card di una pizza, dobbiamo essere portati a una pagina di dettaglio.
 
I dati da mostrare di questa pagina devono essere richiesti alle nostra webapi tramite l’id della pizza e mostrati in pagina usando il javascript.


28/11/2022

Abbiamo studiato cosa sono le WebApi...è il momento di mettere in pratica quello che abbiamo imparato.

Dobbiamo quindi creare un controller Controllers/Api/PizzaController che implementerà le nostre webapi.

	- Deve avere un metodo Get() che restituisca la lista delle pizze che offre la nostra pizzeria

	- Dobbiamo poi modificare la nostra homepage Controller/HomeController (se volete GuestController), 
		che richiamerà utilizzando axios il metodo Get() appena creato e che mostrerà i dati ottenuti tramite codice javascript.




# la-mia-pizzeria-crud-mvc

25/11/22

Il nostro team leader ci ha chiesto di creare un’altra implementazione per gestire le nostre pizze : vogliamo poter scegliere di salvarle in memoria invece di memorizzarle nel db. 
E tramite poche righe di codice deve essere possibile in qualsiasi momento passare dalla gestione su database, a quella su liste in memoria.

Spostiamo quindi tutto il codice che utilizza entity framework in una classe che chiameremo DbPizzaRepository. 
E facciamo in modo che i controller utilizzino quel repository.

Creiamo poi un secondo repository chiamato InMemoryPizzaRepository : in questo caso le pizze saranno salvate in memoria. 
A questo punto facciamo in modo che entrambi i repository implementino un’interfaccia in comune.

Inserite la dependency injection per passare le istanze del repository al sistema

24/11/22

Oggi sviluppiamo un’altra importante funzionalità : aggiungiamo gli ingredienti alle nostre pizze.

Una pizza può avere più ingredienti, e un ingrediente può essere presente in più pizze.

Creiamo quindi il Model necessario e la migration.

Aggiungiamo poi il codice al controller (e alle view) per la gestione degli ingredienti quando creiamo, modifichiamo o visualizziamo una pizza.

Bonus: 
rendete disponibili le CRUD per il backoffice anche per la tabella degli ingredienti, con tutte le accortezze che abbiamo visto per il bonus di ieri.

23/11/22

Oggi sviluppiamo un’importante funzionalità : aggiungiamo una categoria alle nostre pizze (“Pizze classiche”, “Pizze bianche”, “Pizze vegetariane”, “Pizze di mare”, ...).

Dobbiamo quindi predisporre tutto il codice necessario per poter collegare una categoria a una pizza (in una relazione 1 a molti, cioè una pizza può avere una sola categoria, e una categoria può essere collegata a più pizze).

Tramite migration dobbiamo creare la tabella per le categorie. Popoliamola a mano con i valori elencati precedentemente.

Aggiungiamo poi l’informazione della categoria nelle varie pagine :
	- nei dettagli di una singola pizza (nell’admin) mostrare la sua categoria
	- quando si crea/modifica una pizza si deve poter selezionare anche la sua categoria

Bonus:

Realizzare le operazioni di CRUD anche per la nuova entità Categoria.
(attenzione per la parte di delete non abbiamo visto nel dettaglio le problematiche che potrebbero emergere data la relazione esterna)

22/11/22
Completiamo le pagine di gestione delle nostre pizze!

Abbiamo la pagina con la lista di tutte le pizze, quella con i dettagli della singola pizza, quella per crearla...cosa manca?

Dobbiamo realizzare :
	- pagina di modifica di una pizza
	- cancellazione di una pizza cliccando un pulsante presente nella grafica di ogni singolo prodotto mostrato nella lista in homepage


# la-mia-pizzeria-post

22/11/22
Abbiamo la lista delle pizze, abbiamo i dettagli delle pizze...perchè non creare la pagina per la creazione di una nuova pizza?

Aggiungiamo quindi tutto il codice necessario per mostrare il form per la creazione di una nuova pizza e per il salvataggio dei dati nella lista che abbiamo in memoria.

Nella index creiamo ovviamente il bottone “Crea nuova pizza” che ci porta a questa nuova pagina creata.

Ricordiamoci che l’utente potrebbe sbagliare inserendo dei dati : gestiamo quindi la validazione!

Ad esempio verifichiamo che :
	- i dati della pizza siano tutti presenti
	- il campi di testo non superino una certa lunghezza
	- il prezzo abbia un valore valido (ha senso una pizza con prezzo minore o uguale a zero?)

Bonus 
Prevediamo una validazione in più : 
	- vogliamo che la descrizione della pizza contenga almeno 5 parole.


# la-mia-pizzeria-model

21/11/2022
Ciao ragazzi, andiamo avanti con l’applicazione per gestire la nostra pizzeria. Lo scopo di oggi è quello di rendere dinamici i contenuti che abbiamo come html statico nella pagina con la lista delle pizze.
Creiamo prima un nostro controller chiamato PizzaController e utilizziamo lui d’ora in avanti.
L’elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l’html corretto.
Gestiamo anche la possibilità che non ci siano pizze nell’elenco: in quel caso dobbiamo mostrare un messaggio che indichi all’utente che non ci sono pizze presenti nella nostra applicazione.
Ogni pizza dell’elenco avrà un pulsante che se cliccato ci porterà a una pagina che mostrerà i dettagli di quella singola pizza.
Dobbiamo quindi inviare l’id come parametro dell’URL, recuperarlo con la action, caricare i dati della pizza ricercata e passarli come model.
La view a quel punto li mostrerà all’utente con la grafica che preferiamo.
Ps. visto che abbiamo cambiato il controller sul quale lavoriamo, ricordiamoci di cambiare anche il “mapping di default” dei controller...altrimenti quale pagina viene caricata se richiamo l’url “/” della nostra webapp?