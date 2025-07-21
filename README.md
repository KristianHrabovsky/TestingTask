# TestingTask
Forecast .Net Console App

Jedna se o konzolovou aplikaci, ktera pri spusteni z dane url adresy ziska xml soubor, ktery je nasledne preveden do formatu Json.
Soubor Json je nasledne zpracovan a hodnoty jsou ulozeny do databaze SQLite v pravidelnych hodinovych intervalech.

V projektu jsou pouzity tyto balicky:
1) Microsoft.EntityFrameworkCore.Sqlite - pro ukladani dat do SQLite databaze
2) Newtonsoft.Json - pro praci s Json souborem

Tento projekt byl vytvoren ve IDE Visual Studio a tedy obsahuje soubor .sln pro jednodussi spusteni.

Pro spusteni staci tento projekt otevrit a spustit ve Visual Studiu

Databaze SQLite se uklada do slozky bin/debug/net.8.0/
