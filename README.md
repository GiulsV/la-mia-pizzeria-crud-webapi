# la-mia-pizzeria-crud-mvc

25/11/22

Il nostro team leader ci ha chiesto di creare un�altra implementazione per gestire le nostre pizze : vogliamo poter scegliere di salvarle in memoria invece di memorizzarle nel db. 
E tramite poche righe di codice deve essere possibile in qualsiasi momento passare dalla gestione su database, a quella su liste in memoria.

Spostiamo quindi tutto il codice che utilizza entity framework in una classe che chiameremo DbPizzaRepository. 
E facciamo in modo che i controller utilizzino quel repository.

Creiamo poi un secondo repository chiamato InMemoryPizzaRepository : in questo caso le pizze saranno salvate in memoria. 
A questo punto facciamo in modo che entrambi i repository implementino un�interfaccia in comune.

Inserite la dependency injection per passare le istanze del repository al sistema

24/11/22

Oggi sviluppiamo un�altra importante funzionalit� : aggiungiamo gli ingredienti alle nostre pizze.

Una pizza pu� avere pi� ingredienti, e un ingrediente pu� essere presente in pi� pizze.

Creiamo quindi il Model necessario e la migration.

Aggiungiamo poi il codice al controller (e alle view) per la gestione degli ingredienti quando creiamo, modifichiamo o visualizziamo una pizza.

Bonus: 
rendete disponibili le CRUD per il backoffice anche per la tabella degli ingredienti, con tutte le accortezze che abbiamo visto per il bonus di ieri.

23/11/22

Oggi sviluppiamo un�importante funzionalit� : aggiungiamo una categoria alle nostre pizze (�Pizze classiche�, �Pizze bianche�, �Pizze vegetariane�, �Pizze di mare�, ...).

Dobbiamo quindi predisporre tutto il codice necessario per poter collegare una categoria a una pizza (in una relazione 1 a molti, cio� una pizza pu� avere una sola categoria, e una categoria pu� essere collegata a pi� pizze).

Tramite migration dobbiamo creare la tabella per le categorie. Popoliamola a mano con i valori elencati precedentemente.

Aggiungiamo poi l�informazione della categoria nelle varie pagine :
	- nei dettagli di una singola pizza (nell�admin) mostrare la sua categoria
	- quando si crea/modifica una pizza si deve poter selezionare anche la sua categoria

Bonus:

Realizzare le operazioni di CRUD anche per la nuova entit� Categoria.
(attenzione per la parte di delete non abbiamo visto nel dettaglio le problematiche che potrebbero emergere data la relazione esterna)

22/11/22
Completiamo le pagine di gestione delle nostre pizze!

Abbiamo la pagina con la lista di tutte le pizze, quella con i dettagli della singola pizza, quella per crearla...cosa manca?

Dobbiamo realizzare :
	- pagina di modifica di una pizza
	- cancellazione di una pizza cliccando un pulsante presente nella grafica di ogni singolo prodotto mostrato nella lista in homepage


# la-mia-pizzeria-post

22/11/22
Abbiamo la lista delle pizze, abbiamo i dettagli delle pizze...perch� non creare la pagina per la creazione di una nuova pizza?

Aggiungiamo quindi tutto il codice necessario per mostrare il form per la creazione di una nuova pizza e per il salvataggio dei dati nella lista che abbiamo in memoria.

Nella index creiamo ovviamente il bottone �Crea nuova pizza� che ci porta a questa nuova pagina creata.

Ricordiamoci che l�utente potrebbe sbagliare inserendo dei dati : gestiamo quindi la validazione!

Ad esempio verifichiamo che :
	- i dati della pizza siano tutti presenti
	- il campi di testo non superino una certa lunghezza
	- il prezzo abbia un valore valido (ha senso una pizza con prezzo minore o uguale a zero?)

Bonus 
Prevediamo una validazione in pi� : 
	- vogliamo che la descrizione della pizza contenga almeno 5 parole.


# la-mia-pizzeria-model

21/11/2022
Ciao ragazzi, andiamo avanti con l�applicazione per gestire la nostra pizzeria. Lo scopo di oggi � quello di rendere dinamici i contenuti che abbiamo come html statico nella pagina con la lista delle pizze.
Creiamo prima un nostro controller chiamato PizzaController e utilizziamo lui d�ora in avanti.
L�elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l�html corretto.
Gestiamo anche la possibilit� che non ci siano pizze nell�elenco: in quel caso dobbiamo mostrare un messaggio che indichi all�utente che non ci sono pizze presenti nella nostra applicazione.
Ogni pizza dell�elenco avr� un pulsante che se cliccato ci porter� a una pagina che mostrer� i dettagli di quella singola pizza.
Dobbiamo quindi inviare l�id come parametro dell�URL, recuperarlo con la action, caricare i dati della pizza ricercata e passarli come model.
La view a quel punto li mostrer� all�utente con la grafica che preferiamo.
Ps. visto che abbiamo cambiato il controller sul quale lavoriamo, ricordiamoci di cambiare anche il �mapping di default� dei controller...altrimenti quale pagina viene caricata se richiamo l�url �/� della nostra webapp?