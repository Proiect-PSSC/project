**Workflow 1: Preluarea Comenzilor**
Domain Operations:
1. Validarea datelor de intrare.
2. Verificarea existenței produsului: Confirmă că produsul există în baza de date.
3. Verificarea stocului.
4. Calculare pretului total.

Domain Event:
1. Comandă acceptată.
2. Comandă anulată.

**Workflow 2: Facturarea**
Domain Operations:
1. Generarea facturii: Creează o factură cu toate informațiile relevante (produse, cantități, prețuri).
2. Trimiterea facturii.
Domain Event:
1. Facturare realizată cu succes.
2. Facturare anulată: în cazul în care o excepție este aruncată.
3. Arhivarea facturii in baza de date.

**Workflow 3: Expedierea**
Domain Operations:
1. Cerere transport: Inițiază un proces de livrare cu un curier.
2. Expedierea comenzii.
3. Notificarea clientului despre livrare.
Domain Event:
1. Comanda primită.
2. Comandă nelivrată.

Relația dintre Workflow-uri

	1.	Workflow-ul Preluarea Comenzilor finalizează cu un evenimentul comanda acceptata, care declanșează workflow-ul de facturare
	2.	Workflow-ul Facturarea finalizează cu un eveniment facturare realizată cu succes, care permite workflow-ului Expedierea să înceapă.
	3.	Workflow-ul Expedierea finalizează cu evenimentul comanda primită.
