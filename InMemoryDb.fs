module SuaveMusicStore.Db

(* 
 * This is a naive implementation of an in-memory Db.
 * It has been created as a fallback to play with the Suave Music Store app 
 * in case somebody struggles with setting up MsSql server instance or SQLProvider
 *)


open System
open System.Collections.Concurrent

type Album =
    { AlbumId : int
      Title : string
      Price : decimal
      AlbumArtUrl : string
      GenreId : int
      ArtistId : int }

type Artist =
    { ArtistId : int
      Name : string }

type Genre =
    { GenreId : int 
      Name : string }

type User = 
    { UserId : int
      UserName : string 
      Password : string 
      Email : string 
      Role : string }

type Cart =
    { RecordId : int 
      CartId : string 
      AlbumId : int
      Count : int
      DateCreated : DateTime }

type Order =
    { OrderId : int
      OrderDate : DateTime
      UserName : string
      Total : decimal }

type OrderDetails =
    { OrderDetailId : int
      OrderId : int 
      AlbumId : int 
      Quantity : int
      UnitPrice : decimal }

type DbContext = 
    { Albums : ConcurrentDictionary<int, Album>
      Artists : ConcurrentDictionary<int, Artist>
      Genres : ConcurrentDictionary<int, Genre>
      Users : ConcurrentDictionary<int, User>
      Carts : ConcurrentDictionary<int, Cart>
      Orders : ConcurrentDictionary<int, Order>
      OrderDetails : ConcurrentDictionary<int, OrderDetails> }

type AlbumDetails = 
    { AlbumId : int
      Title : string
      Artist : string
      Genre : string
      Price : decimal 
      AlbumArtUrl : string }

type CartDetails =
    { CartId : string 
      AlbumId : int
      Album : string
      AlbumTitle : string
      Count : int
      Price : decimal }

type BestSeller = AlbumDetails

let private ctx = 
    { Albums = 
          ConcurrentDictionary<_, _>([ 
                                        1, { AlbumId = 1; GenreId = 1; ArtistId = 1; Title = "For Those About To Rock We Salute You"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        2, { AlbumId = 2; GenreId = 1; ArtistId = 1; Title = "Let There Be Rock"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        3, { AlbumId = 3; GenreId = 1; ArtistId = 100; Title = "Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        4, { AlbumId = 4; GenreId = 1; ArtistId = 102; Title = "Misplaced Childhood"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        5, { AlbumId = 5; GenreId = 1; ArtistId = 105; Title = "The Best Of Men At Work"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        7, { AlbumId = 7; GenreId = 1; ArtistId = 110; Title = "Nevermind"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        8, { AlbumId = 8; GenreId = 1; ArtistId = 111; Title = "Compositores"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        9, { AlbumId = 9; GenreId = 1; ArtistId = 114; Title = "Bark at the Moon (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        10, { AlbumId = 10; GenreId = 1; ArtistId = 114; Title = "Blizzard of Ozz"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        11, { AlbumId = 11; GenreId = 1; ArtistId = 114; Title = "Diary of a Madman (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        12, { AlbumId = 12; GenreId = 1; ArtistId = 114; Title = "No More Tears (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        13, { AlbumId = 13; GenreId = 1; ArtistId = 114; Title = "Speak of the Devil"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        14, { AlbumId = 14; GenreId = 1; ArtistId = 115; Title = "Walking Into Clarksdale"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        15, { AlbumId = 15; GenreId = 1; ArtistId = 117; Title = "The Beast Live"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        16, { AlbumId = 16; GenreId = 1; ArtistId = 118; Title = "Live On Two Legs [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        17, { AlbumId = 17; GenreId = 1; ArtistId = 118; Title = "Riot Act"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        18, { AlbumId = 18; GenreId = 1; ArtistId = 118; Title = "Ten"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        19, { AlbumId = 19; GenreId = 1; ArtistId = 118; Title = "Vs."; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        20, { AlbumId = 20; GenreId = 1; ArtistId = 120; Title = "Dark Side Of The Moon"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        21, { AlbumId = 21; GenreId = 1; ArtistId = 124; Title = "New Adventures In Hi-Fi"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        22, { AlbumId = 22; GenreId = 1; ArtistId = 126; Title = "Raul Seixas"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        23, { AlbumId = 23; GenreId = 1; ArtistId = 127; Title = "By The Way"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        24, { AlbumId = 24; GenreId = 1; ArtistId = 127; Title = "Californication"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        25, { AlbumId = 25; GenreId = 1; ArtistId = 128; Title = "Retrospective I (1974-1980)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        26, { AlbumId = 26; GenreId = 1; ArtistId = 130; Title = "Maquinarama"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        27, { AlbumId = 27; GenreId = 1; ArtistId = 130; Title = "O Samba Poconé"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        28, { AlbumId = 28; GenreId = 1; ArtistId = 132; Title = "A-Sides"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        29, { AlbumId = 29; GenreId = 1; ArtistId = 134; Title = "Core"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        30, { AlbumId = 30; GenreId = 1; ArtistId = 136; Title = "[1997] Black Light Syndrome"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        31, { AlbumId = 31; GenreId = 1; ArtistId = 139; Title = "Beyond Good And Evil"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        33, { AlbumId = 33; GenreId = 1; ArtistId = 140; Title = "The Doors"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        34, { AlbumId = 34; GenreId = 1; ArtistId = 141; Title = "The Police Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        35, { AlbumId = 35; GenreId = 1; ArtistId = 142; Title = "Hot Rocks, 1964-1971 (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        36, { AlbumId = 36; GenreId = 1; ArtistId = 142; Title = "No Security"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        37, { AlbumId = 37; GenreId = 1; ArtistId = 142; Title = "Voodoo Lounge"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        38, { AlbumId = 38; GenreId = 1; ArtistId = 144; Title = "My Generation - The Very Best Of The Who"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        39, { AlbumId = 39; GenreId = 1; ArtistId = 150; Title = "Achtung Baby"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        40, { AlbumId = 40; GenreId = 1; ArtistId = 150; Title = "B-Sides 1980-1990"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        41, { AlbumId = 41; GenreId = 1; ArtistId = 150; Title = "How To Dismantle An Atomic Bomb"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        42, { AlbumId = 42; GenreId = 1; ArtistId = 150; Title = "Pop"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        43, { AlbumId = 43; GenreId = 1; ArtistId = 150; Title = "Rattle And Hum"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        44, { AlbumId = 44; GenreId = 1; ArtistId = 150; Title = "The Best Of 1980-1990"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        45, { AlbumId = 45; GenreId = 1; ArtistId = 150; Title = "War"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        46, { AlbumId = 46; GenreId = 1; ArtistId = 150; Title = "Zooropa"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        47, { AlbumId = 47; GenreId = 1; ArtistId = 152; Title = "Diver Down"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        48, { AlbumId = 48; GenreId = 1; ArtistId = 152; Title = "The Best Of Van Halen, Vol. I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        49, { AlbumId = 49; GenreId = 1; ArtistId = 152; Title = "Van Halen III"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        50, { AlbumId = 50; GenreId = 1; ArtistId = 152; Title = "Van Halen"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        51, { AlbumId = 51; GenreId = 1; ArtistId = 153; Title = "Contraband"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        52, { AlbumId = 52; GenreId = 1; ArtistId = 157; Title = "Un-Led-Ed"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        54, { AlbumId = 54; GenreId = 1; ArtistId = 2; Title = "Balls to the Wall"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        55, { AlbumId = 55; GenreId = 1; ArtistId = 2; Title = "Restless and Wild"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        56, { AlbumId = 56; GenreId = 1; ArtistId = 200; Title = "Every Kind of Light"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        57, { AlbumId = 57; GenreId = 1; ArtistId = 22; Title = "BBC Sessions [Disc 1] [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        58, { AlbumId = 58; GenreId = 1; ArtistId = 22; Title = "BBC Sessions [Disc 2] [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        59, { AlbumId = 59; GenreId = 1; ArtistId = 22; Title = "Coda"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        60, { AlbumId = 60; GenreId = 1; ArtistId = 22; Title = "Houses Of The Holy"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        61, { AlbumId = 61; GenreId = 1; ArtistId = 22; Title = "In Through The Out Door"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        62, { AlbumId = 62; GenreId = 1; ArtistId = 22; Title = "IV"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        63, { AlbumId = 63; GenreId = 1; ArtistId = 22; Title = "Led Zeppelin I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        64, { AlbumId = 64; GenreId = 1; ArtistId = 22; Title = "Led Zeppelin II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        65, { AlbumId = 65; GenreId = 1; ArtistId = 22; Title = "Led Zeppelin III"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        66, { AlbumId = 66; GenreId = 1; ArtistId = 22; Title = "Physical Graffiti [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        67, { AlbumId = 67; GenreId = 1; ArtistId = 22; Title = "Physical Graffiti [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        68, { AlbumId = 68; GenreId = 1; ArtistId = 22; Title = "Presence"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        69, { AlbumId = 69; GenreId = 1; ArtistId = 22; Title = "The Song Remains The Same (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        70, { AlbumId = 70; GenreId = 1; ArtistId = 22; Title = "The Song Remains The Same (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        71, { AlbumId = 71; GenreId = 1; ArtistId = 23; Title = "Bongo Fury"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        72, { AlbumId = 72; GenreId = 1; ArtistId = 3; Title = "Big Ones"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        73, { AlbumId = 73; GenreId = 1; ArtistId = 4; Title = "Jagged Little Pill"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        74, { AlbumId = 74; GenreId = 1; ArtistId = 5; Title = "Facelift"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        75, { AlbumId = 75; GenreId = 1; ArtistId = 51; Title = "Greatest Hits I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        76, { AlbumId = 76; GenreId = 1; ArtistId = 51; Title = "Greatest Hits II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        77, { AlbumId = 77; GenreId = 1; ArtistId = 51; Title = "News Of The World"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        78, { AlbumId = 78; GenreId = 1; ArtistId = 52; Title = "Greatest Kiss"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        79, { AlbumId = 79; GenreId = 1; ArtistId = 52; Title = "Unplugged [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        80, { AlbumId = 80; GenreId = 1; ArtistId = 55; Title = "Into The Light"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        81, { AlbumId = 81; GenreId = 1; ArtistId = 58; Title = "Come Taste The Band"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        82, { AlbumId = 82; GenreId = 1; ArtistId = 58; Title = "Deep Purple In Rock"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        83, { AlbumId = 83; GenreId = 1; ArtistId = 58; Title = "Fireball"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        84, { AlbumId = 84; GenreId = 1; ArtistId = 58; Title = "Machine Head"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        85, { AlbumId = 85; GenreId = 1; ArtistId = 58; Title = "MK III The Final Concerts [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        86, { AlbumId = 86; GenreId = 1; ArtistId = 58; Title = "Purpendicular"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        87, { AlbumId = 87; GenreId = 1; ArtistId = 58; Title = "Slaves And Masters"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        88, { AlbumId = 88; GenreId = 1; ArtistId = 58; Title = "Stormbringer"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        89, { AlbumId = 89; GenreId = 1; ArtistId = 58; Title = "The Battle Rages On"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        90, { AlbumId = 90; GenreId = 1; ArtistId = 58; Title = "The Final Concerts (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        91, { AlbumId = 91; GenreId = 1; ArtistId = 59; Title = "Santana - As Years Go By"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        92, { AlbumId = 92; GenreId = 1; ArtistId = 59; Title = "Santana Live"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        93, { AlbumId = 93; GenreId = 1; ArtistId = 59; Title = "Supernatural"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        94, { AlbumId = 94; GenreId = 1; ArtistId = 76; Title = "Chronicle, Vol. 1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        95, { AlbumId = 95; GenreId = 1; ArtistId = 76; Title = "Chronicle, Vol. 2"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        96, { AlbumId = 96; GenreId = 1; ArtistId = 8; Title = "Audioslave"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        97, { AlbumId = 97; GenreId = 1; ArtistId = 82; Title = "King For A Day Fool For A Lifetime"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        98, { AlbumId = 98; GenreId = 1; ArtistId = 84; Title = "In Your Honor [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        99, { AlbumId = 99; GenreId = 1; ArtistId = 84; Title = "In Your Honor [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        100, { AlbumId = 100; GenreId = 1; ArtistId = 84; Title = "The Colour And The Shape"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        101, { AlbumId = 101; GenreId = 1; ArtistId = 88; Title = "Appetite for Destruction"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        102, { AlbumId = 102; GenreId = 1; ArtistId = 88; Title = "Use Your Illusion I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        103, { AlbumId = 103; GenreId = 1; ArtistId = 90; Title = "A Matter of Life and Death"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        104, { AlbumId = 104; GenreId = 1; ArtistId = 90; Title = "Brave New World"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        105, { AlbumId = 105; GenreId = 1; ArtistId = 90; Title = "Fear Of The Dark"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        106, { AlbumId = 106; GenreId = 1; ArtistId = 90; Title = "Live At Donington 1992 (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        107, { AlbumId = 107; GenreId = 1; ArtistId = 90; Title = "Live At Donington 1992 (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        108, { AlbumId = 108; GenreId = 1; ArtistId = 90; Title = "Rock In Rio [CD2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        109, { AlbumId = 109; GenreId = 1; ArtistId = 90; Title = "The Number of The Beast"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        110, { AlbumId = 110; GenreId = 1; ArtistId = 90; Title = "The X Factor"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        111, { AlbumId = 111; GenreId = 1; ArtistId = 90; Title = "Virtual XI"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        112, { AlbumId = 112; GenreId = 1; ArtistId = 92; Title = "Emergency On Planet Earth"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        113, { AlbumId = 113; GenreId = 1; ArtistId = 94; Title = "Are You Experienced?"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        114, { AlbumId = 114; GenreId = 1; ArtistId = 95; Title = "Surfing with the Alien (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        115, { AlbumId = 115; GenreId = 10; ArtistId = 203; Title = "The Best of Beethoven"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        119, { AlbumId = 119; GenreId = 10; ArtistId = 208; Title = "Pachelbel: Canon & Gigue"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        122, { AlbumId = 122; GenreId = 10; ArtistId = 211; Title = "Bach: Goldberg Variations"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        123, { AlbumId = 123; GenreId = 10; ArtistId = 212; Title = "Bach: The Cello Suites"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        124, { AlbumId = 124; GenreId = 10; ArtistId = 213; Title = "Handel: The Messiah (Highlights)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        128, { AlbumId = 128; GenreId = 10; ArtistId = 217; Title = "Haydn: Symphonies 99 - 104"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        130, { AlbumId = 130; GenreId = 10; ArtistId = 219; Title = "A Soprano Inspired"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        132, { AlbumId = 132; GenreId = 10; ArtistId = 221; Title = "Wagner: Favourite Overtures"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        134, { AlbumId = 134; GenreId = 10; ArtistId = 223; Title = "Tchaikovsky: The Nutcracker"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        135, { AlbumId = 135; GenreId = 10; ArtistId = 224; Title = "The Last Night of the Proms"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        138, { AlbumId = 138; GenreId = 10; ArtistId = 226; Title = "Respighi:Pines of Rome"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        139, { AlbumId = 139; GenreId = 10; ArtistId = 226; Title = "Strauss: Waltzes"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        140, { AlbumId = 140; GenreId = 10; ArtistId = 229; Title = "Carmina Burana"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        141, { AlbumId = 141; GenreId = 10; ArtistId = 230; Title = "A Copland Celebration, Vol. I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        142, { AlbumId = 142; GenreId = 10; ArtistId = 231; Title = "Bach: Toccata & Fugue in D Minor"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        143, { AlbumId = 143; GenreId = 10; ArtistId = 232; Title = "Prokofiev: Symphony No.1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        144, { AlbumId = 144; GenreId = 10; ArtistId = 233; Title = "Scheherazade"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        145, { AlbumId = 145; GenreId = 10; ArtistId = 234; Title = "Bach: The Brandenburg Concertos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        147, { AlbumId = 147; GenreId = 10; ArtistId = 236; Title = "Mascagni: Cavalleria Rusticana"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        148, { AlbumId = 148; GenreId = 10; ArtistId = 237; Title = "Sibelius: Finlandia"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        152, { AlbumId = 152; GenreId = 10; ArtistId = 242; Title = "Adams, John: The Chairman Dances"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        154, { AlbumId = 154; GenreId = 10; ArtistId = 245; Title = "Berlioz: Symphonie Fantastique"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        155, { AlbumId = 155; GenreId = 10; ArtistId = 245; Title = "Prokofiev: Romeo & Juliet"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        157, { AlbumId = 157; GenreId = 10; ArtistId = 247; Title = "English Renaissance"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        159, { AlbumId = 159; GenreId = 10; ArtistId = 248; Title = "Mozart: Symphonies Nos. 40 & 41"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        161, { AlbumId = 161; GenreId = 10; ArtistId = 250; Title = "SCRIABIN: Vers la flamme"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        163, { AlbumId = 163; GenreId = 10; ArtistId = 255; Title = "Bartok: Violin & Viola Concertos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        166, { AlbumId = 166; GenreId = 10; ArtistId = 259; Title = "South American Getaway"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        167, { AlbumId = 167; GenreId = 10; ArtistId = 260; Title = "Górecki: Symphony No. 3"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        168, { AlbumId = 168; GenreId = 10; ArtistId = 261; Title = "Purcell: The Fairy Queen"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        171, { AlbumId = 171; GenreId = 10; ArtistId = 264; Title = "Weill: The Seven Deadly Sins"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        173, { AlbumId = 173; GenreId = 10; ArtistId = 266; Title = "Szymanowski: Piano Works, Vol. 1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        174, { AlbumId = 174; GenreId = 10; ArtistId = 267; Title = "Nielsen: The Six Symphonies"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        177, { AlbumId = 177; GenreId = 10; ArtistId = 274; Title = "Mozart: Chamber Music"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        178, { AlbumId = 178; GenreId = 2; ArtistId = 10; Title = "The Best Of Billy Cobham"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        179, { AlbumId = 179; GenreId = 2; ArtistId = 197; Title = "Quiet Songs"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        180, { AlbumId = 180; GenreId = 2; ArtistId = 202; Title = "Worlds"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        181, { AlbumId = 181; GenreId = 2; ArtistId = 27; Title = "Quanta Gente Veio ver--Bônus De Carnaval"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        182, { AlbumId = 182; GenreId = 2; ArtistId = 53; Title = "Heart of the Night"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        183, { AlbumId = 183; GenreId = 2; ArtistId = 53; Title = "Morning Dance"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        184, { AlbumId = 184; GenreId = 2; ArtistId = 6; Title = "Warner 25 Anos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        185, { AlbumId = 185; GenreId = 2; ArtistId = 68; Title = "Miles Ahead"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        186, { AlbumId = 186; GenreId = 2; ArtistId = 68; Title = "The Essential Miles Davis [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        187, { AlbumId = 187; GenreId = 2; ArtistId = 68; Title = "The Essential Miles Davis [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        188, { AlbumId = 188; GenreId = 2; ArtistId = 79; Title = "Outbreak"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        189, { AlbumId = 189; GenreId = 2; ArtistId = 89; Title = "Blue Moods"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        190, { AlbumId = 190; GenreId = 3; ArtistId = 100; Title = "Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        191, { AlbumId = 191; GenreId = 3; ArtistId = 106; Title = "Ace Of Spades"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        192, { AlbumId = 192; GenreId = 3; ArtistId = 109; Title = "Motley Crue Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        193, { AlbumId = 193; GenreId = 3; ArtistId = 11; Title = "Alcohol Fueled Brewtality Live! [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        194, { AlbumId = 194; GenreId = 3; ArtistId = 11; Title = "Alcohol Fueled Brewtality Live! [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        195, { AlbumId = 195; GenreId = 3; ArtistId = 114; Title = "Tribute"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        196, { AlbumId = 196; GenreId = 3; ArtistId = 12; Title = "Black Sabbath Vol. 4 (Remaster)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        197, { AlbumId = 197; GenreId = 3; ArtistId = 12; Title = "Black Sabbath"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        198, { AlbumId = 198; GenreId = 3; ArtistId = 135; Title = "Mezmerize"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        199, { AlbumId = 199; GenreId = 3; ArtistId = 14; Title = "Chemical Wedding"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        200, { AlbumId = 200; GenreId = 3; ArtistId = 50; Title = "...And Justice For All"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        201, { AlbumId = 201; GenreId = 3; ArtistId = 50; Title = "Black Album"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        202, { AlbumId = 202; GenreId = 3; ArtistId = 50; Title = "Garage Inc. (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        203, { AlbumId = 203; GenreId = 3; ArtistId = 50; Title = "Garage Inc. (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        204, { AlbumId = 204; GenreId = 3; ArtistId = 50; Title = "Load"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        205, { AlbumId = 205; GenreId = 3; ArtistId = 50; Title = "Master Of Puppets"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        206, { AlbumId = 206; GenreId = 3; ArtistId = 50; Title = "ReLoad"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        207, { AlbumId = 207; GenreId = 3; ArtistId = 50; Title = "Ride The Lightning"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        208, { AlbumId = 208; GenreId = 3; ArtistId = 50; Title = "St. Anger"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        209, { AlbumId = 209; GenreId = 3; ArtistId = 7; Title = "Plays Metallica By Four Cellos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        210, { AlbumId = 210; GenreId = 3; ArtistId = 87; Title = "Faceless"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        211, { AlbumId = 211; GenreId = 3; ArtistId = 88; Title = "Use Your Illusion II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        212, { AlbumId = 212; GenreId = 3; ArtistId = 90; Title = "A Real Dead One"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        213, { AlbumId = 213; GenreId = 3; ArtistId = 90; Title = "A Real Live One"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        214, { AlbumId = 214; GenreId = 3; ArtistId = 90; Title = "Live After Death"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        215, { AlbumId = 215; GenreId = 3; ArtistId = 90; Title = "No Prayer For The Dying"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        216, { AlbumId = 216; GenreId = 3; ArtistId = 90; Title = "Piece Of Mind"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        217, { AlbumId = 217; GenreId = 3; ArtistId = 90; Title = "Powerslave"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        218, { AlbumId = 218; GenreId = 3; ArtistId = 90; Title = "Rock In Rio [CD1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        219, { AlbumId = 219; GenreId = 3; ArtistId = 90; Title = "Rock In Rio [CD2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        220, { AlbumId = 220; GenreId = 3; ArtistId = 90; Title = "Seventh Son of a Seventh Son"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        221, { AlbumId = 221; GenreId = 3; ArtistId = 90; Title = "Somewhere in Time"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        222, { AlbumId = 222; GenreId = 3; ArtistId = 90; Title = "The Number of The Beast"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        223, { AlbumId = 223; GenreId = 3; ArtistId = 98; Title = "Living After Midnight"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        224, { AlbumId = 224; GenreId = 4; ArtistId = 196; Title = "Cake: B-Sides and Rarities"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        225, { AlbumId = 225; GenreId = 4; ArtistId = 204; Title = "Temple of the Dog"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        226, { AlbumId = 226; GenreId = 4; ArtistId = 205; Title = "Carry On"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        227, { AlbumId = 227; GenreId = 4; ArtistId = 253; Title = "Carried to Dust (Bonus Track Version)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        228, { AlbumId = 228; GenreId = 4; ArtistId = 8; Title = "Revelations"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        229, { AlbumId = 229; GenreId = 6; ArtistId = 133; Title = "In Step"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        230, { AlbumId = 230; GenreId = 6; ArtistId = 137; Title = "Live [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        231, { AlbumId = 231; GenreId = 6; ArtistId = 137; Title = "Live [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        233, { AlbumId = 233; GenreId = 6; ArtistId = 81; Title = "The Cream Of Clapton"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        234, { AlbumId = 234; GenreId = 6; ArtistId = 81; Title = "Unplugged"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        235, { AlbumId = 235; GenreId = 6; ArtistId = 90; Title = "Iron Maiden"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        238, { AlbumId = 238; GenreId = 7; ArtistId = 103; Title = "Barulhinho Bom"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        239, { AlbumId = 239; GenreId = 7; ArtistId = 112; Title = "Olodum"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        240, { AlbumId = 240; GenreId = 7; ArtistId = 113; Title = "Acústico MTV"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        241, { AlbumId = 241; GenreId = 7; ArtistId = 113; Title = "Arquivo II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        242, { AlbumId = 242; GenreId = 7; ArtistId = 113; Title = "Arquivo Os Paralamas Do Sucesso"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        243, { AlbumId = 243; GenreId = 7; ArtistId = 145; Title = "Serie Sem Limite (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        244, { AlbumId = 244; GenreId = 7; ArtistId = 145; Title = "Serie Sem Limite (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        245, { AlbumId = 245; GenreId = 7; ArtistId = 155; Title = "Ao Vivo [IMPORT]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        246, { AlbumId = 246; GenreId = 7; ArtistId = 16; Title = "Prenda Minha"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        247, { AlbumId = 247; GenreId = 7; ArtistId = 16; Title = "Sozinho Remix Ao Vivo"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        248, { AlbumId = 248; GenreId = 7; ArtistId = 17; Title = "Minha Historia"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        249, { AlbumId = 249; GenreId = 7; ArtistId = 18; Title = "Afrociberdelia"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        250, { AlbumId = 250; GenreId = 7; ArtistId = 18; Title = "Da Lama Ao Caos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        251, { AlbumId = 251; GenreId = 7; ArtistId = 20; Title = "Na Pista"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        252, { AlbumId = 252; GenreId = 7; ArtistId = 201; Title = "Duos II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        253, { AlbumId = 253; GenreId = 7; ArtistId = 21; Title = "Sambas De Enredo 2001"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        254, { AlbumId = 254; GenreId = 7; ArtistId = 21; Title = "Vozes do MPB"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        255, { AlbumId = 255; GenreId = 7; ArtistId = 24; Title = "Chill: Brazil (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        256, { AlbumId = 256; GenreId = 7; ArtistId = 27; Title = "Quanta Gente Veio Ver (Live)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        257, { AlbumId = 257; GenreId = 7; ArtistId = 37; Title = "The Best of Ed Motta"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        258, { AlbumId = 258; GenreId = 7; ArtistId = 41; Title = "Elis Regina-Minha História"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        259, { AlbumId = 259; GenreId = 7; ArtistId = 42; Title = "Milton Nascimento Ao Vivo"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        260, { AlbumId = 260; GenreId = 7; ArtistId = 42; Title = "Minas"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        261, { AlbumId = 261; GenreId = 7; ArtistId = 46; Title = "Jorge Ben Jor 25 Anos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        262, { AlbumId = 262; GenreId = 7; ArtistId = 56; Title = "Meus Momentos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        263, { AlbumId = 263; GenreId = 7; ArtistId = 6; Title = "Chill: Brazil (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        264, { AlbumId = 264; GenreId = 7; ArtistId = 72; Title = "Vinicius De Moraes"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        266, { AlbumId = 266; GenreId = 7; ArtistId = 77; Title = "Cássia Eller - Sem Limite [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        267, { AlbumId = 267; GenreId = 7; ArtistId = 80; Title = "Djavan Ao Vivo - Vol. 02"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        268, { AlbumId = 268; GenreId = 7; ArtistId = 80; Title = "Djavan Ao Vivo - Vol. 1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        269, { AlbumId = 269; GenreId = 7; ArtistId = 81; Title = "Unplugged"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        270, { AlbumId = 270; GenreId = 7; ArtistId = 83; Title = "Deixa Entrar"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        271, { AlbumId = 271; GenreId = 7; ArtistId = 86; Title = "Roda De Funk"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        272, { AlbumId = 272; GenreId = 7; ArtistId = 96; Title = "Jota Quest-1995"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        274, { AlbumId = 274; GenreId = 7; ArtistId = 99; Title = "Mais Do Mesmo"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        275, { AlbumId = 275; GenreId = 8; ArtistId = 100; Title = "Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        276, { AlbumId = 276; GenreId = 8; ArtistId = 151; Title = "UB40 The Best Of - Volume Two [UK]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        277, { AlbumId = 277; GenreId = 8; ArtistId = 19; Title = "Acústico MTV [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        278, { AlbumId = 278; GenreId = 8; ArtistId = 19; Title = "Cidade Negra - Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        280, { AlbumId = 280; GenreId = 9; ArtistId = 21; Title = "Axé Bahia 2001"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        281, { AlbumId = 281; GenreId = 9; ArtistId = 252; Title = "Frank"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        282, { AlbumId = 282; GenreId = 5; ArtistId = 276; Title = "Le Freak"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        283, { AlbumId = 283; GenreId = 5; ArtistId = 278; Title = "MacArthur Park Suite"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
                                        284, { AlbumId = 284; GenreId = 5; ArtistId = 277; Title = "Ring My Bell"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" } ]
                                     |> dict)
      Artists = 
          ConcurrentDictionary<_, _>([ 1, { ArtistId = 1; Name = "AC/DC" }
                                       2, { ArtistId = 2; Name = "Accept" }
                                       3, { ArtistId = 3; Name = "Aerosmith" }
                                       4, { ArtistId = 4; Name = "Alanis Morissette" }
                                       5, { ArtistId = 5; Name = "Alice In Chains" }
                                       6, { ArtistId = 6; Name = "Antônio Carlos Jobim" }
                                       7, { ArtistId = 7; Name = "Apocalyptica" }
                                       8, { ArtistId = 8; Name = "Audioslave" }
                                       10, { ArtistId = 10; Name = "Billy Cobham" }
                                       11, { ArtistId = 11; Name = "Black Label Society" }
                                       12, { ArtistId = 12; Name = "Black Sabbath" }
                                       14, { ArtistId = 14; Name = "Bruce Dickinson" }
                                       15, { ArtistId = 15; Name = "Buddy Guy" }
                                       16, { ArtistId = 16; Name = "Caetano Veloso" }
                                       17, { ArtistId = 17; Name = "Chico Buarque" }
                                       18, { ArtistId = 18; Name = "Chico Science & Nação Zumbi" }
                                       19, { ArtistId = 19; Name = "Cidade Negra" }
                                       20, { ArtistId = 20; Name = "Cláudio Zoli" }
                                       21, { ArtistId = 21; Name = "Various Artists" }
                                       22, { ArtistId = 22; Name = "Led Zeppelin" }
                                       23, { ArtistId = 23; Name = "Frank Zappa & Captain Beefheart" }
                                       24, { ArtistId = 24; Name = "Marcos Valle" }
                                       27, { ArtistId = 27; Name = "Gilberto Gil" }
                                       37, { ArtistId = 37; Name = "Ed Motta" }
                                       41, { ArtistId = 41; Name = "Elis Regina" }
                                       42, { ArtistId = 42; Name = "Milton Nascimento" }
                                       46, { ArtistId = 46; Name = "Jorge Ben" }
                                       50, { ArtistId = 50; Name = "Metallica" }
                                       51, { ArtistId = 51; Name = "Queen" }
                                       52, { ArtistId = 52; Name = "Kiss" }
                                       53, { ArtistId = 53; Name = "Spyro Gyra" }
                                       55, { ArtistId = 55; Name = "David Coverdale" }
                                       56, { ArtistId = 56; Name = "Gonzaguinha" }
                                       58, { ArtistId = 58; Name = "Deep Purple" }
                                       59, { ArtistId = 59; Name = "Santana" }
                                       68, { ArtistId = 68; Name = "Miles Davis" }
                                       72, { ArtistId = 72; Name = "Vinícius De Moraes" }
                                       76, { ArtistId = 76; Name = "Creedence Clearwater Revival" }
                                       77, { ArtistId = 77; Name = "Cássia Eller" }
                                       79, { ArtistId = 79; Name = "Dennis Chambers" }
                                       80, { ArtistId = 80; Name = "Djavan" }
                                       81, { ArtistId = 81; Name = "Eric Clapton" }
                                       82, { ArtistId = 82; Name = "Faith No More" }
                                       83, { ArtistId = 83; Name = "Falamansa" }
                                       84, { ArtistId = 84; Name = "Foo Fighters" }
                                       86, { ArtistId = 86; Name = "Funk Como Le Gusta" }
                                       87, { ArtistId = 87; Name = "Godsmack" }
                                       88, { ArtistId = 88; Name = "Guns N'' Roses" }
                                       89, { ArtistId = 89; Name = "Incognito" }
                                       90, { ArtistId = 90; Name = "Iron Maiden" }
                                       92, { ArtistId = 92; Name = "Jamiroquai" }
                                       94, { ArtistId = 94; Name = "Jimi Hendrix" }
                                       95, { ArtistId = 95; Name = "Joe Satriani" }
                                       96, { ArtistId = 96; Name = "Jota Quest" }
                                       98, { ArtistId = 98; Name = "Judas Priest" }
                                       99, { ArtistId = 99; Name = "Legião Urbana" }
                                       100, { ArtistId = 100; Name = "Lenny Kravitz" }
                                       101, { ArtistId = 101; Name = "Lulu Santos" }
                                       102, { ArtistId = 102; Name = "Marillion" }
                                       103, { ArtistId = 103; Name = "Marisa Monte" }
                                       105, { ArtistId = 105; Name = "Men At Work" }
                                       106, { ArtistId = 106; Name = "Motörhead" }
                                       109, { ArtistId = 109; Name = "Mötley Crüe" }
                                       110, { ArtistId = 110; Name = "Nirvana" }
                                       111, { ArtistId = 111; Name = "O Terço" }
                                       112, { ArtistId = 112; Name = "Olodum" }
                                       113, { ArtistId = 113; Name = "Os Paralamas Do Sucesso" }
                                       114, { ArtistId = 114; Name = "Ozzy Osbourne" }
                                       115, { ArtistId = 115; Name = "Page & Plant" }
                                       117, { ArtistId = 117; Name = "Paul D''Ianno" }
                                       118, { ArtistId = 118; Name = "Pearl Jam" }
                                       120, { ArtistId = 120; Name = "Pink Floyd" }
                                       124, { ArtistId = 124; Name = "R.E.M." }
                                       126, { ArtistId = 126; Name = "Raul Seixas" }
                                       127, { ArtistId = 127; Name = "Red Hot Chili Peppers" }
                                       128, { ArtistId = 128; Name = "Rush" }
                                       130, { ArtistId = 130; Name = "Skank" }
                                       132, { ArtistId = 132; Name = "Soundgarden" }
                                       133, { ArtistId = 133; Name = "Stevie Ray Vaughan & Double Trouble" }
                                       134, { ArtistId = 134; Name = "Stone Temple Pilots" }
                                       135, { ArtistId = 135; Name = "System Of A Down" }
                                       136, { ArtistId = 136; Name = "Terry Bozzio, Tony Levin & Steve Stevens" }
                                       137, { ArtistId = 137; Name = "The Black Crowes" }
                                       139, { ArtistId = 139; Name = "The Cult" }
                                       140, { ArtistId = 140; Name = "The Doors" }
                                       141, { ArtistId = 141; Name = "The Police" }
                                       142, { ArtistId = 142; Name = "The Rolling Stones" }
                                       144, { ArtistId = 144; Name = "The Who" }
                                       145, { ArtistId = 145; Name = "Tim Maia" }
                                       150, { ArtistId = 150; Name = "U2" }
                                       151, { ArtistId = 151; Name = "UB40" }
                                       152, { ArtistId = 152; Name = "Van Halen" }
                                       153, { ArtistId = 153; Name = "Velvet Revolver" }
                                       155, { ArtistId = 155; Name = "Zeca Pagodinho" }
                                       157, { ArtistId = 157; Name = "Dread Zeppelin" }
                                       179, { ArtistId = 179; Name = "Scorpions" }
                                       196, { ArtistId = 196; Name = "Cake" }
                                       197, { ArtistId = 197; Name = "Aisha Duo" }
                                       200, { ArtistId = 200; Name = "The Posies" }
                                       201, { ArtistId = 201; Name = "Luciana Souza/Romero Lubambo" }
                                       202, { ArtistId = 202; Name = "Aaron Goldberg" }
                                       203, { ArtistId = 203; Name = "Nicolaus Esterhazy Sinfonia" }
                                       204, { ArtistId = 204; Name = "Temple of the Dog" }
                                       205, { ArtistId = 205; Name = "Chris Cornell" }
                                       206, { ArtistId = 206; Name = "Alberto Turco & Nova Schola Gregoriana" }
                                       208, { ArtistId = 208; Name = "English Concert & Trevor Pinnock" }
                                       211, { ArtistId = 211; Name = "Wilhelm Kempff" }
                                       212, { ArtistId = 212; Name = "Yo-Yo Ma" }
                                       213, { ArtistId = 213; Name = "Scholars Baroque Ensemble" }
                                       217, { ArtistId = 217; Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" }
                                       219, { ArtistId = 219; Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" }
                                       221, { ArtistId = 221; Name = "Sir Georg Solti & Wiener Philharmoniker" }
                                       223, { ArtistId = 223; Name = "London Symphony Orchestra & Sir Charles Mackerras" }
                                       224, { ArtistId = 224; Name = "Barry Wordsworth & BBC Concert Orchestra" }
                                       226, { ArtistId = 226; Name = "Eugene Ormandy" }
                                       229, { ArtistId = 229; Name = "Boston Symphony Orchestra & Seiji Ozawa" }
                                       230, { ArtistId = 230; Name = "Aaron Copland & London Symphony Orchestra" }
                                       231, { ArtistId = 231; Name = "Ton Koopman" }
                                       232, { ArtistId = 232; Name = "Sergei Prokofiev & Yuri Temirkanov" }
                                       233, { ArtistId = 233; Name = "Chicago Symphony Orchestra & Fritz Reiner" }
                                       234, { ArtistId = 234; Name = "Orchestra of The Age of Enlightenment" }
                                       236, { ArtistId = 236; Name = "James Levine" }
                                       237, { ArtistId = 237; Name = "Berliner Philharmoniker & Hans Rosbaud" }
                                       238, { ArtistId = 238; Name = "Maurizio Pollini" }
                                       240, { ArtistId = 240; Name = "Gustav Mahler" }
                                       242, { ArtistId = 242; Name = "Edo de Waart & San Francisco Symphony" }
                                       244, { ArtistId = 244; Name = "Choir Of Westminster Abbey & Simon Preston" }
                                       245, { ArtistId = 245; Name = "Michael Tilson Thomas & San Francisco Symphony" }
                                       247, { ArtistId = 247; Name = "The King''s Singers" }
                                       248, { ArtistId = 248; Name = "Berliner Philharmoniker & Herbert Von Karajan" }
                                       250, { ArtistId = 250; Name = "Christopher O''Riley" }
                                       251, { ArtistId = 251; Name = "Fretwork" }
                                       252, { ArtistId = 252; Name = "Amy Winehouse" }
                                       253, { ArtistId = 253; Name = "Calexico" }
                                       255, { ArtistId = 255; Name = "Yehudi Menuhin" }
                                       258, { ArtistId = 258; Name = "Les Arts Florissants & William Christie" }
                                       259, { ArtistId = 259; Name = "The 12 Cellists of The Berlin Philharmonic" }
                                       260, { ArtistId = 260; Name = "Adrian Leaper & Doreen de Feis" }
                                       261, { ArtistId = 261; Name = "Roger Norrington, London Classical Players" }
                                       264, { ArtistId = 264; Name = "Kent Nagano and Orchestre de l''Opéra de Lyon" }
                                       265, { ArtistId = 265; Name = "Julian Bream" }
                                       266, { ArtistId = 266; Name = "Martin Roscoe" }
                                       267, { ArtistId = 267; Name = "Göteborgs Symfoniker & Neeme Järvi" }
                                       270, { ArtistId = 270; Name = "Gerald Moore" }
                                       271, { ArtistId = 271; Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" }
                                       274, { ArtistId = 274; Name = "Nash Ensemble" }
                                       276, { ArtistId = 276; Name = "Chic" }
                                       277, { ArtistId = 277; Name = "Anita Ward" }
                                       278, { ArtistId = 278; Name = "Donna Summer" } ]
                                     |> dict)
      Genres = 
          ConcurrentDictionary<_, _>([ 1,
                                       { GenreId = 1 
                                         Name = "Rock" }
                                       2,
                                       { GenreId = 2 
                                         Name = "Jazz" }
                                       3,
                                       { GenreId = 3 
                                         Name = "Metal" }
                                       4,
                                       { GenreId = 4 
                                         Name = "Alternative" }
                                       5,
                                       { GenreId = 5 
                                         Name = "Disco" }
                                       6,
                                       { GenreId = 6 
                                         Name = "Blues" }
                                       7,
                                       { GenreId = 7 
                                         Name = "Latin" }
                                       8,
                                       { GenreId = 8 
                                         Name = "Reggae" }
                                       9,
                                       { GenreId = 9 
                                         Name = "Pop" }
                                       10,
                                       { GenreId = 10
                                         Name = "Classical" } ]
                                     |> dict)
      Users = 
          ConcurrentDictionary<_, _>([ 1, 
                                       { UserId = 1
                                         UserName = "admin"
                                         Role = "admin"
                                         Password = 
                                             "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"
                                         Email = "admin@example.com" } ]
                                     |> dict)
      Carts = ConcurrentDictionary<_, _>()
      Orders = ConcurrentDictionary<_, _>()
      OrderDetails = ConcurrentDictionary<_, _>() }


let getContext() = ctx

let firstOrNone s = s |> Seq.tryFind (fun _ -> true)

let getGenres (ctx : DbContext) : Genre list = 
    ctx.Genres.Values |> Seq.toList

let getArtists (ctx : DbContext) : Artist list = 
    ctx.Artists.Values |> Seq.toList

let getAlbumsForGenre genreName (ctx : DbContext) : Album list = 
    query { 
        for album in ctx.Albums.Values do
            join genre in ctx.Genres.Values on (album.GenreId = genre.GenreId)
            where (genre.Name = genreName)
            select album
    }
    |> Seq.toList

let getAlbumDetails id (ctx : DbContext) : AlbumDetails option = 
    query { 
        for album in ctx.Albums.Values do
            join genre in ctx.Genres.Values on (album.GenreId = genre.GenreId)
            join artist in ctx.Artists.Values on (album.ArtistId = artist.ArtistId)
            where (album.AlbumId = id)
            select 
                { AlbumId = album.AlbumId
                  Title = album.Title
                  Price = album.Price
                  AlbumArtUrl = album.AlbumArtUrl
                  Genre = genre.Name 
                  Artist = artist.Name }
    } |> firstOrNone

let getAlbumsDetails (ctx : DbContext) : AlbumDetails list = 
    query { 
        for album in ctx.Albums.Values do
            join genre in ctx.Genres.Values on (album.GenreId = genre.GenreId)
            join artist in ctx.Artists.Values on (album.ArtistId = artist.ArtistId)
            select 
                { AlbumId = album.AlbumId
                  Title = album.Title
                  Price = album.Price
                  AlbumArtUrl = album.AlbumArtUrl
                  Genre = genre.Name 
                  Artist = artist.Name }
    } |> Seq.toList

let getBestSellers (ctx : DbContext) : BestSeller list  =
    query { 
        for album in ctx.Albums.Values do
            join genre in ctx.Genres.Values on (album.GenreId = genre.GenreId)
            join artist in ctx.Artists.Values on (album.ArtistId = artist.ArtistId)
            join ods in ctx.OrderDetails.Values on (album.AlbumId = ods.AlbumId)
            take 5
            select 
                { AlbumId = album.AlbumId
                  Title = album.Title
                  Price = album.Price
                  AlbumArtUrl = album.AlbumArtUrl
                  Genre = genre.Name 
                  Artist = artist.Name }
    } |> Seq.toList

let getAlbum id (ctx : DbContext) : Album option = 
    query { 
        for album in ctx.Albums.Values do
            where (album.AlbumId = id)
            select album
    } |> firstOrNone

let validateUser (username, password) (ctx : DbContext) : User option =
    query {
        for user in ctx.Users.Values do
            where (user.UserName = username && user.Password = password)
            select user
    } |> firstOrNone

let getUser username (ctx : DbContext) : User option = 
    query {
        for user in ctx.Users.Values do
        where (user.UserName = username)
        select user
    } |> firstOrNone

let getCart cartId albumId (ctx : DbContext) : Cart option =
    query {
        for cart in ctx.Carts.Values do
            where (cart.CartId = cartId && cart.AlbumId = albumId)
            select cart
    } |> firstOrNone

let getCarts cartId (ctx : DbContext) : Cart list =
    query {
        for cart in ctx.Carts.Values do
            where (cart.CartId = cartId)
            select cart
    } |> Seq.toList

let getCartsDetails cartId (ctx : DbContext) : CartDetails list =
    query {
        for cart in ctx.Carts.Values do
            join album in ctx.Albums.Values on (cart.AlbumId = album.AlbumId)
            where (cart.CartId = cartId)
            select 
                { AlbumId = album.AlbumId
                  Album = album.Title
                  AlbumTitle = album.Title
                  Count = cart.Count
                  CartId = cart.CartId
                  Price = album.Price }
    } |> Seq.toList

let createAlbum (artistId, genreId, price, title) (ctx : DbContext) =
    let id = ctx.Albums.Keys |> Seq.max |> ((+) 1)
    let album = 
        { AlbumId = id
          GenreId = genreId
          ArtistId = artistId
          Price = price
          Title = title
          AlbumArtUrl = "/placeholder.gif" }
    ctx.Albums.GetOrAdd(id, album) |> ignore

let updateAlbum (album : Album) (artistId, genreId, price, title) (ctx : DbContext) =
    let updatedAlbum = 
        { AlbumId = album.AlbumId
          GenreId = genreId
          ArtistId = artistId
          Price = price
          Title = title
          AlbumArtUrl = "/placeholder.gif" }
    ctx.Albums.TryUpdate(album.AlbumId, updatedAlbum, album) |> ignore

let deleteAlbum (album : Album) (ctx : DbContext) = 
    ctx.Albums.TryRemove album.AlbumId |> ignore

let addToCart cartId albumId (ctx : DbContext)  =
    match getCart cartId albumId ctx with
    | Some cart ->
        let updatedCart = {cart with Count = cart.Count + 1}
        ctx.Carts.TryUpdate(cart.RecordId, updatedCart, cart) |> ignore
    | None ->
        let recordId = ctx.Carts.Keys |> Seq.fold max 1
        let newCart = 
            { RecordId = recordId
              CartId = cartId
              AlbumId = albumId
              Count = 1
              DateCreated = DateTime.UtcNow }
        ctx.Carts.TryAdd(recordId, newCart) |> ignore

let removeFromCart (cart : Cart) albumId (ctx : DbContext) = 
    let updatedCart = {cart with Count = cart.Count - 1}
    if updatedCart.Count = 0 then
        ctx.Carts.TryRemove(cart.RecordId) |> ignore
    else
        ctx.Carts.TryUpdate(cart.RecordId, updatedCart, cart) |> ignore

let upgradeCarts (cartId : string, username :string) (ctx : DbContext) =
    for cart in getCarts cartId ctx do
        match getCart username cart.AlbumId ctx with
        | Some existing ->
            let updatedExisting = {existing with Count = existing.Count + cart.Count}
            ctx.Carts.TryUpdate(existing.RecordId, updatedExisting, existing) |> ignore
        | None ->
            let updatedCart = {cart with CartId = username}
            ctx.Carts.TryUpdate(cart.RecordId, updatedCart, cart) |> ignore

let newUser (username, password, email) (ctx : DbContext) =
    let id = ctx.Users.Keys |> Seq.max |> ((+) 1)
    let user =
        { UserId = id
          UserName = username
          Password = password 
          Email = email
          Role = "user" }
    ctx.Users.TryAdd(id, user) |> ignore
    user

let placeOrder (username : string) (ctx : DbContext) =
    let carts = getCartsDetails username ctx
    let total = carts |> List.sumBy (fun c -> (decimal) c.Count * c.Price)
    let orderId = ctx.Orders.Keys |> Seq.fold max 1
    let order = 
        { OrderId = orderId
          OrderDate = DateTime.UtcNow 
          Total = total
          UserName = username }
    ctx.Orders.TryAdd(orderId, order) |> ignore
    for cart in carts do
        let orderDetailId = ctx.OrderDetails.Keys |> Seq.max |> ((+) 1)
        let orderDetails =
            { OrderDetailId = orderDetailId
              OrderId = orderId
              AlbumId = cart.AlbumId
              Quantity = cart.Count
              UnitPrice = cart.Price }
        ctx.OrderDetails.TryAdd(orderDetailId, orderDetails) |> ignore
        getCart cart.CartId cart.AlbumId ctx
        |> Option.iter (fun cart -> ctx.Carts.TryRemove(cart.RecordId) |> ignore)
