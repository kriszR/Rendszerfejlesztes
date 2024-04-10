# **Szerver beállítása:**

1. A ***Szerver*** mappa letöltése
2. ***.sln*** kiterjesztésű fájl betöltése Visual Studio-ba
3. Futtatás

# **Kliens beállítása:**

1. A ***Kliens*** mappa letöltése
2. Mappa megnyitása Visual Studio Code-ban
3. Live Server Extension - login.html  futtatása Live Server-ként (Bejelentkezésnél bármit beírhatunk, be fog engedni a rendszer)

***Frissítve: 2024.09.10***

Jelenleg nincs statikus beégetett adat, minden hallgatót fel kell vinni külön POST-tal, amíg nincsen ORM.
Teszt adatok:

[
{
  "id": 0,
  "username": "Kris",
  "name": "Kristóf",
  "password": "pw123",
  "degrees": [
    1,2,3
  ],
  "myCourses": [
    "Prog", "Digszám", "MI"
  ]
},
{
  "id": 0,
  "username": "Ati",
  "name": "Attila",
  "password": "pw345",
  "degrees": [
    3,4,5
  ],
  "myCourses": [
    "Dimat", "Analizis", "Adatb"
  ]
},
{
  "id": 0,
  "username": "Kris",
  "name": "Kristóf",
  "password": "pw123",
  "degrees": [
    1,2,3
  ],
  "myCourses": [
    "Prog", "Digszám", "MI"
  ]
},
{
  "id": 0,
  "username": "Mate",
  "name": "Máté",
  "password": "pw445",
  "degrees": [
    4,2,1,
  ],
  "myCourses": [
    "Mobilprog", "Dimat", "Halado"
  ]
}
]


**Az oldal jelenleg kilistáz minden hallgatót és a hozzájuk kapcsolódó kurzusokat, a következő beadandóra már javítva lesznek a funkciók**
