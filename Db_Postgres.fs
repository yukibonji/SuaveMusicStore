module SuaveMusicStore.Db_Postgres

open System
open Npgsql

type Album = { AlbumId : int; GenreId : int; ArtistId : int; Title : string; Price : Decimal; AlbumArtUrl : string }
type Artist = { ArtistId : int; Name : string}
type Genre = { GenreId : int; Name : string; Description : string }
type AlbumDetails = { AlbumId : int;  AlbumArtUrl : string; Price : Decimal; Title : string; Artist : string; Genre : string }
type User = { UserId : int; UserName : string; Email : string; Password : string; Role : string }
type Cart = { RecordId : int; CartId : string; AlbumId : int; Count : int; DateCreated : System.DateTime }
type CartDetails = { CartId : string; Count : int; AlbumTitle : string; AlbumId : int; Price : Decimal }
type BestSeller = { AlbumId : int; Title : string; AlbumArtUrl : string; Count : int64 }

let getContext() = ()

let firstOrNone s = s |> Seq.tryFind (fun _ -> true)

let read toFunc sql =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  toFunc reader

let nonQuery sql =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  command.ExecuteNonQuery() |> ignore

let toGenres (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      GenreId = reader.GetInt32(reader.GetOrdinal("genre_id"))
      Name = reader.GetString(reader.GetOrdinal("name"))
      Description = reader.GetString(reader.GetOrdinal("description"))
    }
  ]

let toArtists (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      ArtistId = reader.GetInt32(reader.GetOrdinal("artist_id"))
      Name = reader.GetString(reader.GetOrdinal("name"))
    }
  ]

let toAlbums (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
      GenreId = reader.GetInt32(reader.GetOrdinal("genre_id"))
      ArtistId = reader.GetInt32(reader.GetOrdinal("artist_id"))
      Title = reader.GetString(reader.GetOrdinal("title"))
      Price = reader.GetDecimal(reader.GetOrdinal("price"))
      AlbumArtUrl = reader.GetString(reader.GetOrdinal("album_art_url"))
    }
  ]

let toAlbumDetails (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
      AlbumArtUrl = reader.GetString(reader.GetOrdinal("album_art_url"))
      Price = reader.GetDecimal(reader.GetOrdinal("price"))
      Title = reader.GetString(reader.GetOrdinal("title"))
      Artist = reader.GetString(reader.GetOrdinal("artist"))
      Genre = reader.GetString(reader.GetOrdinal("genre"))
    }
  ]

let toBestSellers (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
      AlbumArtUrl = reader.GetString(reader.GetOrdinal("album_art_url"))
      Title = reader.GetString(reader.GetOrdinal("title"))
      Count = reader.GetInt64(reader.GetOrdinal("count"))
    }
  ]

let toUsers (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      UserId = reader.GetInt32(reader.GetOrdinal("user_id"))
      UserName = reader.GetString(reader.GetOrdinal("user_name"))
      Email = reader.GetString(reader.GetOrdinal("email"))
      Password = reader.GetString(reader.GetOrdinal("password"))
      Role = reader.GetString(reader.GetOrdinal("role"))
    }
  ]

let toCarts (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      RecordId = reader.GetInt32(reader.GetOrdinal("record_id"))
      CartId = reader.GetString(reader.GetOrdinal("cart_id"))
      AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
      Count = reader.GetInt32(reader.GetOrdinal("count"))
      DateCreated = reader.GetDateTime(reader.GetOrdinal("date_created"))
    }
  ]

let toCartDetails (reader : NpgsqlDataReader) =
  [ while reader.Read() do
    yield {
      CartId = reader.GetString(reader.GetOrdinal("cart_id"))
      Count = reader.GetInt32(reader.GetOrdinal("count"))
      AlbumTitle = reader.GetString(reader.GetOrdinal("album_title"))
      AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
      Price = reader.GetDecimal(reader.GetOrdinal("Price"))
    }
  ]

let getGenres _ : Genre list = read toGenres "SELECT genre_id, name, description FROM genres"

let getArtists _ : Artist list = read toArtists "SELECT artist_id, name FROM artists"

let getAlbumsForGenre genreName _ : Album list =
  //todo prevent sql injection
  sprintf """
SELECT album_id, a.genre_id, artist_id, title, price, album_art_url FROM albums as a
JOIN genres as g
ON a.genre_id = g.genre_id
where g.name = '%s'""" genreName
  |> read toAlbums

let getAlbumDetails id _ : AlbumDetails option =
  sprintf "SELECT album_id, album_art_url, price, title, artist, genre from albumdetails WHERE album_id = %i" id
  |> read toAlbumDetails
  |> firstOrNone

let getAlbumsDetails _ : AlbumDetails list = read toAlbumDetails "SELECT album_id, album_art_url, price, title, artist, genre from albumdetails"

let getBestSellers _ : BestSeller list = read toBestSellers "SELECT album_id, title, album_art_url, count FROM bestsellers"

let getAlbum id _ : Album option =
  sprintf "SELECT album_id, genre_id, artist_id, title, price, album_art_url FROM albums WHERE album_id = %i" id
  |> read toAlbums
  |> firstOrNone

let validateUser (username, password) _ : User option =
  sprintf "SELECT user_id, user_name, email, password, role FROM users
  WHERE user_name = '%s' AND password = '%s'" username password
  |> read toUsers
  |> firstOrNone

let getUser username _ : User option =
  sprintf "SELECT user_id, user_name, email, password, role FROM users
  WHERE user_name = '%s'" username
  |> read toUsers
  |> firstOrNone

let getCart cartId albumId _ : Cart option =
  sprintf "SELECT record_id, cart_id, album_id, count, date_created FROM carts
  WHERE cart_id = '%s' AND album_id = %i" cartId albumId
  |> read toCarts
  |> firstOrNone

let getCarts cartId _ : Cart list =
  sprintf "SELECT record_id, cart_id, album_id, count, date_created FROM carts
  WHERE cart_id = '%s'" cartId
  |> read toCarts

let getCartsDetails cartId _ : CartDetails list =
  sprintf "SELECT cart_id, count, album_title, album_id, price FROM cartdetails
  WHERE cart_id = '%s'" cartId
  |> read toCartDetails

let createAlbum (artistId, genreId, price, title) _ =
  sprintf "INSERT INTO albums (artist_id, genre_id, price, title)
  VALUES (%i, %i, %M, '%s')" artistId genreId price title
  |> nonQuery

let updateAlbum (album : Album) (artistId, genreId, price, title) _ =
  sprintf "UPDATE albums
  SET artist_id = %i,
  genre_id = %i,
  price = %M,
  title = '%s'
  WHERE album_id = %i" artistId genreId price title album.AlbumId
  |> nonQuery

let deleteAlbum (album : Album) _ =
  sprintf "DELETE FROM albums where album_id = %i" album.AlbumId
  |> nonQuery

let addToCart cartId albumId _  =
  match getCart cartId albumId () with
  | Some cart ->
    sprintf "UPDATE carts SET count = count + 1 WHERE record_id = %i" cart.RecordId
    |> nonQuery
  | None ->
    sprintf "INSERT INTO carts (cart_id, album_id, count, date_created)
    VALUES ('%s', %i, 1, now())" cartId albumId
    |> nonQuery

let removeFromCart (cart : Cart) albumId _ =
  sprintf "DELETE FROM carts WHERE record_id = %i" cart.RecordId
  |> nonQuery

let upgradeCarts (cartId : string, username :string) _ =
  for cart in getCarts cartId () do
    match getCart username cart.AlbumId () with
    | Some existing ->
        sprintf "UPDATE carts SET count = count + 1 WHERE record_id = %i;
        DELETE FROM carts WHERE record_id = %i;" existing.RecordId cart.RecordId
        |> nonQuery
    | None ->
        sprintf "UPDATE carts SET cart_id = '%s' WHERE record_id = %i;" username cart.RecordId
        |> nonQuery

let newUser (username, password, email) _ =
  sprintf "INSERT INTO users (user_name, email, password, role)
  VALUES ('%s', '%s', '%s', '%s')" username email password "user"
  |> nonQuery

  (getUser username ()).Value

let placeOrder (username : string) _ =
  let carts = getCartsDetails username ()
  let total = carts |> List.sumBy (fun c -> (decimal) c.Count * c.Price)
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  let sql = sprintf "INSERT INTO orders (order_date, user_name, total)
  VALUES ((SELECT CURRENT_TIMESTAMP AT TIME ZONE 'UTC'), '%s', %M)
  RETURNING order_id" username total
  use command = new NpgsqlCommand(sql, connection)
  let orderId = command.ExecuteScalar() :?> int

  for cart in carts do
    let sql = sprintf "INSERT INTO orderdetails (order_id, album_id, quantity, unit_price)
    VALUES (%A, %i, %i, %M)" orderId cart.AlbumId cart.Count cart.Price
    use command = new NpgsqlCommand(sql, connection)
    command.ExecuteNonQuery() |> ignore

    getCart cart.CartId cart.AlbumId ()
    |> Option.iter (fun cart ->
         let sql = sprintf "DELETE FROM carts where record_id = %i" cart.RecordId
         use command = new NpgsqlCommand(sql, connection)
         command.ExecuteNonQuery() |> ignore)
