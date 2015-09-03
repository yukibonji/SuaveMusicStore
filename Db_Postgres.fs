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
type BestSeller = { AlbumId : int; Title : string; AlbumArtUrl : string; Count : int }

let getContext() = ()

let firstOrNone s = s |> Seq.tryFind (fun _ -> true)

let getGenres _ : Genre list =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand("SELECT genre_id, name, description FROM genres", connection)
  use reader = command.ExecuteReader()
  let genres =
    [ while reader.Read() do
      yield {
        GenreId = reader.GetInt32(reader.GetOrdinal("genre_id"))
        Name = reader.GetString(reader.GetOrdinal("name"))
        Description = reader.GetString(reader.GetOrdinal("description"))
      }
    ]
  genres

let getArtists _ : Artist list =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand("SELECT artist_id, name FROM artists", connection)
  use reader = command.ExecuteReader()
  let artists =
    [ while reader.Read() do
      yield {
        ArtistId = reader.GetInt32(reader.GetOrdinal("artist_id"))
        Name = reader.GetString(reader.GetOrdinal("name"))
      }
    ]
  artists

let getAlbumsForGenre genreName _ : Album list =
  //todo prevent sql injection
  let sql = sprintf """
SELECT album_id, a.genre_id, artist_id, title, price, album_art_url FROM albums as a
JOIN genres as g
ON a.genre_id = g.genre_id
where g.name = '%s'""" genreName

  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let albums =
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
  albums

let getAlbumDetails id _ : AlbumDetails option =
  let sql = sprintf "SELECT album_id, album_art_url, price, title, artist, genre from albumdetails WHERE album_id = %i" id
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let albumDetails =
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
  albumDetails |> firstOrNone

let getAlbumsDetails _ : AlbumDetails list =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand("SELECT album_id, album_art_url, price, title, artist, genre from albumdetails", connection)
  use reader = command.ExecuteReader()
  let albumDetails =
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
  albumDetails

let getBestSellers _ : BestSeller list  =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand("SELECT album_id, title, album_art_url, count FROM bestsellers", connection)
  use reader = command.ExecuteReader()
  let bestSellers =
    [ while reader.Read() do
      yield {
        AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
        AlbumArtUrl = reader.GetString(reader.GetOrdinal("album_art_url"))
        Title = reader.GetString(reader.GetOrdinal("title"))
        Count = reader.GetInt32(reader.GetOrdinal("count"))
      }
    ]
  bestSellers

let getAlbum id _ : Album option =
  let sql = sprintf "SELECT album_id, genre_id, artist_id, title, price, album_art_url FROM albums WHERE album_id = %i" id
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let albums =
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
  albums |> firstOrNone

let validateUser (username, password) _ : User option =
  let sql = sprintf "SELECT user_id, user_name, email, password, role FROM users
  WHERE user_name = '%s' AND password = '%s'" username password
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let users =
    [ while reader.Read() do
      yield {
        UserId = reader.GetInt32(reader.GetOrdinal("user_id"))
        UserName = reader.GetString(reader.GetOrdinal("user_name"))
        Email = reader.GetString(reader.GetOrdinal("email"))
        Password = reader.GetString(reader.GetOrdinal("password"))
        Role = reader.GetString(reader.GetOrdinal("role"))
      }
    ]
  users |> firstOrNone

let getUser username _ : User option =
  let sql = sprintf "SELECT user_id, user_name, email, password, role FROM users
  WHERE user_name = '%s'" username
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let users =
    [ while reader.Read() do
      yield {
        UserId = reader.GetInt32(reader.GetOrdinal("user_id"))
        UserName = reader.GetString(reader.GetOrdinal("user_name"))
        Email = reader.GetString(reader.GetOrdinal("email"))
        Password = reader.GetString(reader.GetOrdinal("password"))
        Role = reader.GetString(reader.GetOrdinal("role"))
      }
    ]
  users |> firstOrNone

let getCart cartId albumId _ : Cart option =
  let sql = sprintf "SELECT record_id, cart_id, album_id, count, date_created FROM carts
  WHERE cart_id = '%s' AND album_id = %i" cartId albumId
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let carts =
    [ while reader.Read() do
      yield {
        RecordId = reader.GetInt32(reader.GetOrdinal("record_id"))
        CartId = reader.GetString(reader.GetOrdinal("cart_id"))
        AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
        Count = reader.GetInt32(reader.GetOrdinal("count"))
        DateCreated = reader.GetDateTime(reader.GetOrdinal("date_created"))
      }
    ]
  carts |> firstOrNone

let getCarts cartId _ : Cart list =
  let sql = sprintf "SELECT record_id, cart_id, album_id, count, date_created FROM carts
  WHERE cart_id = '%s'" cartId
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let carts =
    [ while reader.Read() do
      yield {
        RecordId = reader.GetInt32(reader.GetOrdinal("record_id"))
        CartId = reader.GetString(reader.GetOrdinal("cart_id"))
        AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
        Count = reader.GetInt32(reader.GetOrdinal("count"))
        DateCreated = reader.GetDateTime(reader.GetOrdinal("date_created"))
      }
    ]
  carts

let getCartsDetails cartId _ : CartDetails list =
  let sql = sprintf "SELECT cart_id, count, album_title, album_id, price FROM cartdetails
  WHERE cart_id = '%s'" cartId
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  use command = new NpgsqlCommand(sql, connection)
  use reader = command.ExecuteReader()
  let cartDetails =
    [ while reader.Read() do
      yield {
        CartId = reader.GetString(reader.GetOrdinal("cart_id"))
        Count = reader.GetInt32(reader.GetOrdinal("count"))
        AlbumTitle = reader.GetString(reader.GetOrdinal("album_title"))
        AlbumId = reader.GetInt32(reader.GetOrdinal("album_id"))
        Price = reader.GetDecimal(reader.GetOrdinal("Price"))
      }
    ]
  cartDetails

let createAlbum (artistId, genreId, price, title) _ =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  let sql = sprintf "INSERT INTO albums (artist_id, genre_id, price, title)
  VALUES (%i, %i, %M, '%s')" artistId genreId price title
  use command = new NpgsqlCommand(sql, connection)
  command.ExecuteNonQuery() |> ignore

let updateAlbum (album : Album) (artistId, genreId, price, title) _ =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  let sql = sprintf "UPDATE albums
  SET artist_id = %i,
  genre_id = %i,
  price = %M,
  title = '%s'
  WHERE album_id = %i" artistId genreId price title album.AlbumId
  use command = new NpgsqlCommand(sql, connection)
  command.ExecuteNonQuery() |> ignore

let deleteAlbum (album : Album) _ =
    //album.Delete()
    //ctx.SubmitUpdates()
  ()

let addToCart cartId albumId _  =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  match getCart cartId albumId () with
  | Some cart ->
    let sql = sprintf "UPDATE carts SET count = count + 1 WHERE record_id = %i" cart.RecordId
    use command = new NpgsqlCommand(sql, connection)
    command.ExecuteNonQuery() |> ignore
  | None ->
    let sql = sprintf "INSERT INTO carts (cart_id, album_id, count, date_created)
    VALUES ('%s', %i, 1, now())" cartId albumId
    use command = new NpgsqlCommand(sql, connection)
    command.ExecuteNonQuery() |> ignore

let removeFromCart (cart : Cart) albumId _ =
  use connection = new NpgsqlConnection("Server=127.0.0.1;User Id=suave; Password=1234;Database=SuaveMusicStore;")
  connection.Open()
  let sql = sprintf "DELETE FROM carts WHERE record_id = %i" cart.RecordId
  use command = new NpgsqlCommand(sql, connection)
  command.ExecuteNonQuery() |> ignore

let upgradeCarts (cartId : string, username :string) _ =
    //for cart in getCarts cartId ctx do
    //    match getCart username cart.AlbumId ctx with
    //    | Some existing ->
    //        existing.Count <- existing.Count +  cart.Count
    //        cart.Delete()
    //    | None ->
    //        cart.CartId <- username
    //ctx.SubmitUpdates()
  ()

let newUser (username, password, email) _ =
    //let user = ctx.``[dbo].[Users]``.Create(email, password, "user", username)
    //ctx.SubmitUpdates()
    //user

  { UserId = 1; UserName = ""; Email = ""; Password = ""; Role = "" }

let placeOrder (username : string) _ =
    //let carts = getCartsDetails username ctx
    //let total = carts |> List.sumBy (fun c -> (decimal) c.Count * c.Price)
    //let order = ctx.``[dbo].[Orders]``.Create(DateTime.UtcNow, total)
    //order.Username <- username
    //ctx.SubmitUpdates()
    //for cart in carts do
    //    let orderDetails = ctx.``[dbo].[OrderDetails]``.Create(cart.AlbumId, order.OrderId, cart.Count, cart.Price)
    //    getCart cart.CartId cart.AlbumId ctx
    //    |> Option.iter (fun cart -> cart.Delete())
    //ctx.SubmitUpdates()
  ()
