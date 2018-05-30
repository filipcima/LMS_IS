# Learning management system
- Moodle-like system
- .NET, SQL Server
LMS_IS is a school project which demonstrates functionality of .NET Windows Forms and database access at DAIS course.


## Assignment requirements (czech):

- IS musí obsahovat minimálně 7 tabulek (minimálně 4 nebudou číselníky) a 5 netriviálních funkcí. Minimálně 3 funkce budou napsány jako uložené procedury.
- Mezi těmito 5 funkcemi mohou být pouze 2 netriviální dotazy, ostatní budou transakce. Netriviální funkce není CRUD operace.
- Black list funkcí: kaskádové mazání záznamů.
- Implementace (funkce, formuláře atd.) bude odpovídat analýze.
- Architektura bude vrstvová, datová vrstva bude obsahovat objektově-relační mapování (ORM).
- Implementace bude v ASP.NET nebo J2EE (v případě webové aplikace) resp. .NET nebo Java (v případě desktopové aplikace).
- ORM bude implementováno s důrazen na minimalizaci počtu operací zasílaných na databázi a minimalizaci objemu dat přenášených z/do databáze (viz 11. přednáška).
- ORM bude podporovat transakce (stačí úroveň izolace SERIALIZABLE).
- V rámci ORM se bude odevzdávat testovací projekt, který bude obsahovat volání všech metod ORM.
- V databázi budou vytvořeny základní indexy.
- Z aplikace budou vytvořeny dva netriviální formuláře (tedy ne formuláře pro CRUD operace), které budou vybrány cvičícím. Na prezentační vrstvě budou podporovány základní validace vstupů.
- Odevzdávat se bude kompletní dokumentace, SQL skripty a implementace.
