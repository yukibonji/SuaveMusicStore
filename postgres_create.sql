DROP OWNED BY suave;
DROP USER IF EXISTS suave;

DROP TABLE IF EXISTS Genres CASCADE;

CREATE TABLE Genres(
  genre_id SERIAL PRIMARY KEY NOT NULL,
  name varchar(120) NULL,
  description varchar(4000) NULL);

INSERT INTO genres (name, description) VALUES ('Rock', 'Rock and Roll is a form of rock music developed in the 1950s and 1960s. Rock music combines many kinds of music from the United States, such as country music, folk music, church music, work songs, blues and jazz.');
INSERT INTO genres (name, description) VALUES ('Jazz', 'Jazz is a type of music which was invented in the United States. Jazz music combines African-American music with European music. Some common jazz instruments include the saxophone, trumpet, piano, double bass, and drums.');
INSERT INTO genres (name, description) VALUES ('Metal', 'Heavy Metal is a loud, aggressive style of Rock music. The bands who play heavy-metal music usually have one or two guitars, a bass guitar and drums. In some bands, electronic keyboards, organs, or other instruments are used. Heavy metal songs are loud and powerful-sounding, and have strong rhythms that are repeated. There are many different types of Heavy Metal, some of which are described below. Heavy metal bands sometimes dress in jeans, leather jackets, and leather boots, and have long hair. Heavy metal bands sometimes behave in a dramatic way when they play their instruments or sing. However, many heavy metal bands do not like to do this.');
INSERT INTO genres (name, description) VALUES ('Alternative', 'Alternative rock is a type of rock music that became popular in the 1980s and became widely popular in the 1990s. Alternative rock is made up of various subgenres that have come out of the indie music scene since the 1980s, such as grunge, indie rock, Britpop, gothic rock, and indie pop. These genres are sorted by their collective types of punk, which laid the groundwork for alternative music in the 1970s.');
INSERT INTO genres (name, description) VALUES ('Disco', 'Disco is a style of pop music that was popular in the mid-1970s. Disco music has a strong beat that people can dance to. People usually dance to disco music at bars called disco clubs. The word "disco" is also used to refer to the style of dancing that people do to disco music, or to the style of clothes that people wear to go disco dancing. Disco was at its most popular in the United States and Europe in the 1970s and early 1980s. Disco was brought into the mainstream by the hit movie Saturday Night Fever, which was released in 1977. This movie, which starred John Travolta, showed people doing disco dancing. Many radio stations played disco in the late 1970s.');
INSERT INTO genres (name, description) VALUES ('Blues', 'The blues is a form of music that started in the United States during the start of the 20th century. It was started by former African slaves from spirituals, praise songs, and chants. The first blues songs were called Delta blues. These songs came from the area near the mouth of the Mississippi River.');
INSERT INTO genres (name, description) VALUES ('Latin', 'Latin American music is the music of all countries in Latin America (and the Caribbean) and comes in many varieties. Latin America is home to musical styles such as the simple, rural conjunto music of northern Mexico, the sophisticated habanera of Cuba, the rhythmic sounds of the Puerto Rican plena, the symphonies of Heitor Villa-Lobos, and the simple and moving Andean flute. Music has played an important part recently in Latin America''s politics, the nueva canción movement being a prime example. Latin music is very diverse, with the only truly unifying thread being the use of Latin-derived languages, predominantly the Spanish language, the Portuguese language in Brazil, and to a lesser extent, Latin-derived creole languages, such as those found in Haiti.');
INSERT INTO genres (name, description) VALUES ('Reggae', 'Reggae is a music genre first developed in Jamaica in the late 1960s. While sometimes used in a broader sense to refer to most types of Jamaican music, the term reggae more properly denotes a particular music style that originated following on the development of ska and rocksteady.');
INSERT INTO genres (name, description) VALUES ('Pop', 'Pop music is a music genre that developed from the mid-1950s as a softer alternative to rock ''n'' roll and later to rock music. It has a focus on commercial recording, often oriented towards a youth market, usually through the medium of relatively short and simple love songs. While these basic elements of the genre have remained fairly constant, pop music has absorbed influences from most other forms of popular music, particularly borrowing from the development of rock music, and utilizing key technological innovations to produce new variations on existing themes.');
INSERT INTO genres (name, description) VALUES ('Classical', 'Classical music is a very general term which normally refers to the standard music of countries in the Western world. It is music that has been composed by musicians who are trained in the art of writing music (composing) and written down in music notation so that other musicians can play it. Classical music can also be described as "art music" because great art (skill) is needed to compose it and to perform it well. Classical music differs from pop music because it is not made just in order to be popular for a short time or just to be a commercial success.');

DROP TABLE IF EXISTS Orders;

CREATE TABLE Orders(
	order_id SERIAL PRIMARY KEY NOT NULL,
	order_date timestamptz NOT NULL,
	user_name varchar(256) NULL,
	first_name varchar(160) NULL,
	last_name varchar(160) NULL,
	address varchar(70) NULL,
	city varchar(40) NULL,
	state varchar(40) NULL,
	postal_code varchar(10) NULL,
	country varchar(40) NULL,
	phone varchar(24) NULL,
	email varchar(160) NULL,
	total numeric(10, 2) NOT NULL);

DROP TABLE IF EXISTS Artists;

CREATE TABLE Artists(
	artist_id SERIAL PRIMARY KEY NOT NULL,
	name varchar(120) NULL);

INSERT INTO Artists (name) VALUES ('AC/DC');
INSERT INTO Artists (name) VALUES ('Accept');
INSERT INTO Artists (name) VALUES ('Aerosmith');
INSERT INTO Artists (name) VALUES ('Alanis Morissette');
INSERT INTO Artists (name) VALUES ('Alice In Chains');
INSERT INTO Artists (name) VALUES ('Antônio Carlos Jobim');
INSERT INTO Artists (name) VALUES ('Apocalyptica');
INSERT INTO Artists (name) VALUES ('Audioslave');
INSERT INTO Artists (name) VALUES ('Billy Cobham');
INSERT INTO Artists (name) VALUES ('Black Label Society');
INSERT INTO Artists (name) VALUES ('Black Sabbath');
INSERT INTO Artists (name) VALUES ('Bruce Dickinson');
INSERT INTO Artists (name) VALUES ('Buddy Guy');
INSERT INTO Artists (name) VALUES ('Caetano Veloso');
INSERT INTO Artists (name) VALUES ('Chico Buarque');
INSERT INTO Artists (name) VALUES ('Chico Science & Nação Zumbi');
INSERT INTO Artists (name) VALUES ('Cidade Negra');
INSERT INTO Artists (name) VALUES ('Cláudio Zoli');
INSERT INTO Artists (name) VALUES ('Various Artists');
INSERT INTO Artists (name) VALUES ('Led Zeppelin');
INSERT INTO Artists (name) VALUES ('Frank Zappa & Captain Beefheart');
INSERT INTO Artists (name) VALUES ('Marcos Valle');
INSERT INTO Artists (name) VALUES ('Gilberto Gil');
INSERT INTO Artists (name) VALUES ('Ed Motta');
INSERT INTO Artists (name) VALUES ('Elis Regina');
INSERT INTO Artists (name) VALUES ('Milton Nascimento');
INSERT INTO Artists (name) VALUES ('Jorge Ben');
INSERT INTO Artists (name) VALUES ('Metallica');
INSERT INTO Artists (name) VALUES ('Queen');
INSERT INTO Artists (name) VALUES ('Kiss');
INSERT INTO Artists (name) VALUES ('Spyro Gyra');
INSERT INTO Artists (name) VALUES ('David Coverdale');
INSERT INTO Artists (name) VALUES ('Gonzaguinha');
INSERT INTO Artists (name) VALUES ('Deep Purple');
INSERT INTO Artists (name) VALUES ('Santana');
INSERT INTO Artists (name) VALUES ('Miles Davis');
INSERT INTO Artists (name) VALUES ('Vinícius De Moraes');
INSERT INTO Artists (name) VALUES ('Creedence Clearwater Revival');
INSERT INTO Artists (name) VALUES ('Cássia Eller');
INSERT INTO Artists (name) VALUES ('Dennis Chambers');
INSERT INTO Artists (name) VALUES ('Djavan');
INSERT INTO Artists (name) VALUES ('Eric Clapton');
INSERT INTO Artists (name) VALUES ('Faith No More');
INSERT INTO Artists (name) VALUES ('Falamansa');
INSERT INTO Artists (name) VALUES ('Foo Fighters');
INSERT INTO Artists (name) VALUES ('Funk Como Le Gusta');
INSERT INTO Artists (name) VALUES ('Godsmack');
INSERT INTO Artists (name) VALUES ('Guns '' Roses');
INSERT INTO Artists (name) VALUES ('Incognito');
INSERT INTO Artists (name) VALUES ('Iron Maiden');
INSERT INTO Artists (name) VALUES ('Jamiroquai');
INSERT INTO Artists (name) VALUES ('Jimi Hendrix');
INSERT INTO Artists (name) VALUES ('Joe Satriani');
INSERT INTO Artists (name) VALUES ('Jota Quest');
INSERT INTO Artists (name) VALUES ('Judas Priest');
INSERT INTO Artists (name) VALUES ('Legião Urbana');
INSERT INTO Artists (name) VALUES ('Lenny Kravitz');
INSERT INTO Artists (name) VALUES ('Lulu Santos');
INSERT INTO Artists (name) VALUES ('Marillion');
INSERT INTO Artists (name) VALUES ('Marisa Monte');
INSERT INTO Artists (name) VALUES ('Men At Work');
INSERT INTO Artists (name) VALUES ('Motörhead');
INSERT INTO Artists (name) VALUES ('Mötley Crüe');
INSERT INTO Artists (name) VALUES ('Nirvana');
INSERT INTO Artists (name) VALUES ('O Terço');
INSERT INTO Artists (name) VALUES ('Olodum');
INSERT INTO Artists (name) VALUES ('Os Paralamas Do Sucesso');
INSERT INTO Artists (name) VALUES ('Ozzy Osbourne');
INSERT INTO Artists (name) VALUES ('Page & Plant');
INSERT INTO Artists (name) VALUES ('Paul D''Ianno');
INSERT INTO Artists (name) VALUES ('Pearl Jam');
INSERT INTO Artists (name) VALUES ('Pink Floyd');
INSERT INTO Artists (name) VALUES ('R.E.M.');
INSERT INTO Artists (name) VALUES ('Raul Seixas');
INSERT INTO Artists (name) VALUES ('Red Hot Chili Peppers');
INSERT INTO Artists (name) VALUES ('Rush');
INSERT INTO Artists (name) VALUES ('Skank');
INSERT INTO Artists (name) VALUES ('Soundgarden');
INSERT INTO Artists (name) VALUES ('Stevie Ray Vaughan & Double Trouble');
INSERT INTO Artists (name) VALUES ('Stone Temple Pilots');
INSERT INTO Artists (name) VALUES ('System Of A Down');
INSERT INTO Artists (name) VALUES ('Terry Bozzio, Tony Levin & Steve Stevens');
INSERT INTO Artists (name) VALUES ('The Black Crowes');
INSERT INTO Artists (name) VALUES ('The Cult');
INSERT INTO Artists (name) VALUES ('The Doors');
INSERT INTO Artists (name) VALUES ('The Police');
INSERT INTO Artists (name) VALUES ('The Rolling Stones');
INSERT INTO Artists (name) VALUES ('The Who');
INSERT INTO Artists (name) VALUES ('Tim Maia');
INSERT INTO Artists (name) VALUES ('U2');
INSERT INTO Artists (name) VALUES ('UB40');
INSERT INTO Artists (name) VALUES ('Van Halen');
INSERT INTO Artists (name) VALUES ('Velvet Revolver');
INSERT INTO Artists (name) VALUES ('Zeca Pagodinho');
INSERT INTO Artists (name) VALUES ('Dread Zeppelin');
INSERT INTO Artists (name) VALUES ('Scorpions');
INSERT INTO Artists (name) VALUES ('Cake');
INSERT INTO Artists (name) VALUES ('Aisha Duo');
INSERT INTO Artists (name) VALUES ('The Posies');
INSERT INTO Artists (name) VALUES ('Luciana Souza/Romero Lubambo');
INSERT INTO Artists (name) VALUES ('Aaron Goldberg');
INSERT INTO Artists (name) VALUES ('Nicolaus Esterhazy Sinfonia');
INSERT INTO Artists (name) VALUES ('Temple of the Dog');
INSERT INTO Artists (name) VALUES ('Chris Cornell');
INSERT INTO Artists (name) VALUES ('Alberto Turco & Nova Schola Gregoriana');
INSERT INTO Artists (name) VALUES ('English Concert & Trevor Pinnock');
INSERT INTO Artists (name) VALUES ('Wilhelm Kempff');
INSERT INTO Artists (name) VALUES ('Yo-Yo Ma');
INSERT INTO Artists (name) VALUES ('Scholars Baroque Ensemble');
INSERT INTO Artists (name) VALUES ('Royal Philharmonic Orchestra & Sir Thomas Beecham');
INSERT INTO Artists (name) VALUES ('Britten Sinfonia, Ivor Bolton & Lesley Garrett');
INSERT INTO Artists (name) VALUES ('Sir Georg Solti & Wiener Philharmoniker');
INSERT INTO Artists (name) VALUES ('London Symphony Orchestra & Sir Charles Mackerras');
INSERT INTO Artists (name) VALUES ('Barry Wordsworth & BBC Concert Orchestra');
INSERT INTO Artists (name) VALUES ('Eugene Ormandy');
INSERT INTO Artists (name) VALUES ('Boston Symphony Orchestra & Seiji Ozawa');
INSERT INTO Artists (name) VALUES ('Aaron Copland & London Symphony Orchestra');
INSERT INTO Artists (name) VALUES ('Ton Koopman');
INSERT INTO Artists (name) VALUES ('Sergei Prokofiev & Yuri Temirkanov');
INSERT INTO Artists (name) VALUES ('Chicago Symphony Orchestra & Fritz Reiner');
INSERT INTO Artists (name) VALUES ('Orchestra of The Age of Enlightenment');
INSERT INTO Artists (name) VALUES ('James Levine');
INSERT INTO Artists (name) VALUES ('Berliner Philharmoniker & Hans Rosbaud');
INSERT INTO Artists (name) VALUES ('Maurizio Pollini');
INSERT INTO Artists (name) VALUES ('Gustav Mahler');
INSERT INTO Artists (name) VALUES ('Edo de Waart & San Francisco Symphony');
INSERT INTO Artists (name) VALUES ('Choir Of Westminster Abbey & Simon Preston');
INSERT INTO Artists (name) VALUES ('Michael Tilson Thomas & San Francisco Symphony');
INSERT INTO Artists (name) VALUES ('The King''s Singers');
INSERT INTO Artists (name) VALUES ('Berliner Philharmoniker & Herbert Von Karajan');
INSERT INTO Artists (name) VALUES ('Christopher O''Riley');
INSERT INTO Artists (name) VALUES ('Fretwork');
INSERT INTO Artists (name) VALUES ('Amy Winehouse');
INSERT INTO Artists (name) VALUES ('Calexico');
INSERT INTO Artists (name) VALUES ('Yehudi Menuhin');
INSERT INTO Artists (name) VALUES ('Les Arts Florissants & William Christie');
INSERT INTO Artists (name) VALUES ('The 12 Cellists of The Berlin Philharmonic');
INSERT INTO Artists (name) VALUES ('Adrian Leaper & Doreen de Feis');
INSERT INTO Artists (name) VALUES ('Roger Norrington, London Classical Players');
INSERT INTO Artists (name) VALUES ('Kent Nagano and Orchestre de l''Opéra de Lyon');
INSERT INTO Artists (name) VALUES ('Julian Bream');
INSERT INTO Artists (name) VALUES ('Martin Roscoe');
INSERT INTO Artists (name) VALUES ('Göteborgs Symfoniker & Neeme Järvi');
INSERT INTO Artists (name) VALUES ('Gerald Moore');
INSERT INTO Artists (name) VALUES ('Mela Tenenbaum, Pro Musica Prague & Richard Kapp');
INSERT INTO Artists (name) VALUES ('Nash Ensemble');
INSERT INTO Artists (name) VALUES ('Chic');
INSERT INTO Artists (name) VALUES ('Anita Ward');
INSERT INTO Artists (name) VALUES ('Donna Summer');

DROP TABLE IF EXISTS Albums CASCADE;

CREATE TABLE Albums(
	album_id SERIAL PRIMARY KEY NOT NULL,
	genre_id int NOT NULL,
	artist_id int NOT NULL,
	title varchar(160) NOT NULL,
	price numeric(10, 2) NOT NULL,
	album_art_url varchar(1024) NULL CONSTRAINT DF_Album_album_art_url  DEFAULT ('/placeholder.gif'));

INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 1, 'For Those About To Rock We Salute You', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 1, 'Let There Be Rock', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 100, 'Greatest Hits', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 102, 'Misplaced Childhood', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 105, 'The Best Of Men At Work', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 110, 'Nevermind', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 111, 'Compositores', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 114, 'Bark at the Moon (Remastered)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 114, 'Blizzard of Ozz', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 114, 'Diary of a Madman (Remastered)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 114, 'No More Tears (Remastered)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 114, 'Speak of the Devil', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 115, 'Walking Into Clarksdale', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 117, 'The Beast Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 118, 'Live On Two Legs Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 118, 'Riot Act', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 118, 'Ten', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 118, 'Vs.', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 120, 'Dark Side Of The Moon', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 124, 'New Adventures In Hi-Fi', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 126, 'Raul Seixas', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 127, 'By The Way', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 127, 'Californication', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 128, 'Retrospective I (1974-1980)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 130, 'Maquinarama', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 130, 'O Samba Poconé', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 132, 'A-Sides', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 134, 'Core', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 136, '1997 Black Light Syndrome', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 139, 'Beyond Good And Evil', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 140, 'The Doors', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 141, 'The Police Greatest Hits', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 142, 'Hot Rocks, 1964-1971 (Disc 1)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 142, 'No Security', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 142, 'Voodoo Lounge', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 144, 'My Generation - The Very Best Of The Who', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'Achtung Baby', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'B-Sides 1980-1990', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'How To Dismantle An Atomic Bomb', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'Pop', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'Rattle And Hum', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'The Best Of 1980-1990', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'War', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 150, 'Zooropa', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 152, 'Diver Down', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 152, 'The Best Of Van Halen, Vol. I', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 152, 'Van Halen III', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 152, 'Van Halen', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 153, 'Contraband', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 157, 'Un-Led-Ed', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 2, 'Balls to the Wall', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 2, 'Restless and Wild', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 200, 'Every Kind of Light', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'BBC Sessions Disc 1 Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'BBC Sessions Disc 2 Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Coda', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Houses Of The Holy', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'In Through The Out Door', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'IV', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Led Zeppelin I', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Led Zeppelin II', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Led Zeppelin III', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Physical Graffiti Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Physical Graffiti Disc 2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'Presence', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'The Song Remains The Same (Disc 1)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 22, 'The Song Remains The Same (Disc 2)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 23, 'Bongo Fury', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 3, 'Big Ones', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 4, 'Jagged Little Pill', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 5, 'Facelift', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 51, 'Greatest Hits I', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 51, 'Greatest Hits II', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 51, 'News Of The World', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 52, 'Greatest Kiss', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 52, 'Unplugged Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 55, 'Into The Light', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Come Taste The Band', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Deep Purple In Rock', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Fireball', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Machine Head', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'MK III The Final Concerts Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Purpendicular', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Slaves And Masters', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'Stormbringer', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'The Battle Rages On', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 58, 'The Final Concerts (Disc 2)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 59, 'Santana - As Years Go By', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 59, 'Santana Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 59, 'Supernatural', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 76, 'Chronicle, Vol. 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 76, 'Chronicle, Vol. 2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 8, 'Audioslave', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 82, 'King For A Day Fool For A Lifetime', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 84, 'In Your Honor Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 84, 'In Your Honor Disc 2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 84, 'The Colour And The Shape', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 88, 'Appetite for Destruction', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 88, 'Use Your Illusion I', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'A Matter of Life and Death', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'Brave New World', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'Fear Of The Dark', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'Live At Donington 1992 (Disc 1)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'Live At Donington 1992 (Disc 2)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'Rock In Rio CD2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'The Number of The Beast', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'The X Factor', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 90, 'Virtual XI', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 92, 'Emergency On Planet Earth', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 94, 'Are You Experienced?', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (1, 95, 'Surfing with the Alien (Remastered)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 203, 'The Best of Beethoven', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 208, 'Pachelbel: Canon & Gigue', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 211, 'Bach: Goldberg Variations', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 212, 'Bach: The Cello Suites', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 213, 'Handel: The Messiah (Highlights)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 217, 'Haydn: Symphonies 99 - 104', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 219, 'A Soprano Inspired', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 221, 'Wagner: Favourite Overtures', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 223, 'Tchaikovsky: The Nutcracker', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 224, 'The Last Night of the Proms', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 226, 'Respighi:Pines of Rome', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 226, 'Strauss: Waltzes', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 229, 'Carmina Burana', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 230, 'A Copland Celebration, Vol. I', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 231, 'Bach: Toccata & Fugue in D Minor', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 232, 'Prokofiev: Symphony No.1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 233, 'Scheherazade', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 234, 'Bach: The Brandenburg Concertos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 236, 'Mascagni: Cavalleria Rusticana', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 237, 'Sibelius: Finlandia', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 242, 'Adams, John: The Chairman Dances', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 245, 'Berlioz: Symphonie Fantastique', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 245, 'Prokofiev: Romeo & Juliet', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 247, 'English Renaissance', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 248, 'Mozart: Symphonies Nos. 40 & 41', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 250, 'SCRIABIN: Vers la flamme', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 255, 'Bartok: Violin & Viola Concertos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 259, 'South American Getaway', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 260, 'Górecki: Symphony No. 3', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 261, 'Purcell: The Fairy Queen', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 264, 'Weill: The Seven Deadly Sins', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 266, 'Szymanowski: Piano Works, Vol. 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 267, 'Nielsen: The Six Symphonies', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (10, 274, 'Mozart: Chamber Music', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 10, 'The Best Of Billy Cobham', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 197, 'Quiet Songs', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 202, 'Worlds', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 27, 'Quanta Gente Veio ver--Bônus De Carnaval', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 53, 'Heart of the Night', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 53, 'Morning Dance', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 6, 'Warner 25 Anos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 68, 'Miles Ahead', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 68, 'The Essential Miles Davis Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 68, 'The Essential Miles Davis Disc 2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 79, 'Outbreak', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (2, 89, 'Blue Moods', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 100, 'Greatest Hits', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 106, 'Ace Of Spades', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 109, 'Motley Crue Greatest Hits', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 11, 'Alcohol Fueled Brewtality Live! Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 11, 'Alcohol Fueled Brewtality Live! Disc 2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 114, 'Tribute', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 12, 'Black Sabbath Vol. 4 (Remaster)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 12, 'Black Sabbath', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 135, 'Mezmerize', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 14, 'Chemical Wedding', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, '...And Justice For All', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'Black Album', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'Garage Inc. (Disc 1)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'Garage Inc. (Disc 2)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'Load', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'Master Of Puppets', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'ReLoad', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'Ride The Lightning', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 50, 'St. Anger', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 7, 'Plays Metallica By Four Cellos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 87, 'Faceless', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 88, 'Use Your Illusion II', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'A Real Dead One', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'A Real Live One', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Live After Death', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'No Prayer For The Dying', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Piece Of Mind', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Powerslave', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Rock In Rio CD1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Rock In Rio CD2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Seventh Son of a Seventh Son', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'Somewhere in Time', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 90, 'The Number of The Beast', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (3, 98, 'Living After Midnight', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (4, 196, 'Cake: B-Sides and Rarities', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (4, 204, 'Temple of the Dog', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (4, 205, 'Carry On', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (4, 253, 'Carried to Dust (Bonus Track Version)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (4, 8, 'Revelations', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (6, 133, 'In Step', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (6, 137, 'Live Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (6, 137, 'Live Disc 2', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (6, 81, 'The Cream Of Clapton', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (6, 81, 'Unplugged', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (6, 90, 'Iron Maiden', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 103, 'Barulhinho Bom', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 112, 'Olodum', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 113, 'Acústico MTV', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 113, 'Arquivo II', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 113, 'Arquivo Os Paralamas Do Sucesso', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 145, 'Serie Sem Limite (Disc 1)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 145, 'Serie Sem Limite (Disc 2)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 155, 'Ao Vivo IMPORT', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 16, 'Prenda Minha', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 16, 'Sozinho Remix Ao Vivo', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 17, 'Minha Historia', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 18, 'Afrociberdelia', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 18, 'Da Lama Ao Caos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 20, 'Na Pista', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 201, 'Duos II', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 21, 'Sambas De Enredo 2001', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 21, 'Vozes do MPB', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 24, 'Chill: Brazil (Disc 1)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 27, 'Quanta Gente Veio Ver (Live)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 37, 'The Best of Ed Motta', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 41, 'Elis Regina-Minha História', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 42, 'Milton Nascimento Ao Vivo', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 42, 'Minas', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 46, 'Jorge Ben Jor 25 Anos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 56, 'Meus Momentos', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 6, 'Chill: Brazil (Disc 2)', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 72, 'Vinicius De Moraes', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 77, 'Cássia Eller - Sem Limite Disc 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 80, 'Djavan Ao Vivo - Vol. 02', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 80, 'Djavan Ao Vivo - Vol. 1', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 81, 'Unplugged', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 83, 'Deixa Entrar', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 86, 'Roda De Funk', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 96, 'Jota Quest-1995', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (7, 99, 'Mais Do Mesmo', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (8, 100, 'Greatest Hits', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (8, 151, 'UB40 The Best Of - Volume Two UK', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (8, 19, 'Acústico MTV Live', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (8, 19, 'Cidade Negra - Hits', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (9, 21, 'Axé Bahia 2001', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (9, 252, 'Frank', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (5, 276, 'Le Freak', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (5, 278, 'MacArthur Park Suite', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');
INSERT INTO Albums (genre_id, artist_id, title, price, album_art_url) VALUES (5, 277, 'Ring My Bell', CAST(8.99 AS Numeric(10, 2)), '/placeholder.gif');

DROP TABLE IF EXISTS OrderDetails;

CREATE TABLE OrderDetails(
	order_detail_id SERIAL PRIMARY KEY NOT NULL,
	order_id int NOT NULL,
	album_id int NOT NULL,
	quantity int NOT NULL,
	unit_price numeric(10, 2) NOT NULL);

DROP TABLE IF EXISTS Carts;

CREATE TABLE Carts(
	record_id SERIAL PRIMARY KEY NOT NULL,
	cart_id varchar(50) NOT NULL,
	album_id int NOT NULL,
	count int NOT NULL,
	date_created timestamptz NOT NULL);

DROP TABLE IF EXISTS Users;

CREATE TABLE Users(
	user_id SERIAL PRIMARY KEY NOT NULL,
	user_name varchar(200) NOT NULL,
	email varchar(200) NOT NULL,
	password varchar(200) NOT NULL,
	role varchar(50) NOT NULL);

INSERT INTO Users (user_name, email, password, role) VALUES ('admin', 'admin@example@com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin');

CREATE VIEW AlbumDetails
as
select a.album_id, a.album_art_url, a.price, a.title, at.name as artist, g.name as genre
from Albums a
join Artists at on at.artist_id = a.artist_id
join Genres g on g.genre_id = a.genre_id;

CREATE VIEW CartDetails
as
select c.cart_id, c.count, a.title as album_title, a.album_id as album_id, a.price
from Carts c
join Albums a on c.album_id = a.album_id;

CREATE VIEW BestSellers
as
select a.album_id, a.title, a.album_art_url, count(*) as Count
from Albums as a
inner join OrderDetails as o on a.album_id = o.album_id
group by a.album_id, a.title, a.album_art_url
order by Count DESC
LIMIT 5;

CREATE USER suave WITH ENCRYPTED PASSWORD '1234';
GRANT USAGE ON SCHEMA public to suave;
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT SELECT ON TABLES TO suave;

GRANT CONNECT ON DATABASE "SuaveMusicStore" to suave;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO suave;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO suave;
