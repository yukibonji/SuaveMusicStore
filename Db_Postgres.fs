module SuaveMusicStore.Db_Postgres

open System
open Npgsql

type Album = { AlbumId : int; GenreId : int; ArtistId : int; Title : string; Price : Decimal; AlbumArtUrl : string }
type Artist = { ArtistId : int; Name : string}
type Genre = { GenreId : int; Name : string; Description : string }
type AlbumDetails = { AlbumId : int;  AlbumArtUrl : string; Price : Decimal; Title : string; Artist : string; Genre : string }
type User = { UserId : int; UserName : string; Email : string; Password : string; Role : string }
type Cart = { RecordId : int; CartId : int; AlbumId : int; Count : int; DateCreated : System.DateTime }
type CartDetails = { CartId : int; Count : int; AlbumTitle : string; AlbumId : int; Price : Decimal }
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
    //ctx.``[dbo].[BestSellers]`` |> Seq.toList
  []

let getAlbum id _ : Album option =
    //query {
    //    for album in ctx.``[dbo].[Albums]`` do
    //        where (album.AlbumId = id)
    //        select album
    //} |> firstOrNone
  None

let validateUser (username, password) _ : User option =
    //query {
    //    for user in ctx.``[dbo].[Users]`` do
    //        where (user.UserName = username && user.Password = password)
    //        select user
    //} |> firstOrNone
  None

let getUser username _ : User option =
    //query {
    //    for user in ctx.``[dbo].[Users]`` do
    //    where (user.UserName = username)
    //    select user
    //} |> firstOrNone
  None

let getCart cartId albumId _ : Cart option =
    //query {
    //    for cart in ctx.``[dbo].[Carts]`` do
    //        where (cart.CartId = cartId && cart.AlbumId = albumId)
    //        select cart
    //} |> firstOrNone
  None

let getCarts cartId _ : Cart list =
    //query {
    //    for cart in ctx.``[dbo].[Carts]`` do
    //        where (cart.CartId = cartId)
    //        select cart
    //} |> Seq.toList
  []

let getCartsDetails cartId _ : CartDetails list =
    //query {
    //    for cart in ctx.``[dbo].[CartDetails]`` do
    //        where (cart.CartId = cartId)
    //        select cart
    //} |> Seq.toList
  []

let createAlbum (artistId, genreId, price, title) _ =
    //ctx.``[dbo].[Albums]``.Create(artistId, genreId, price, title) |> ignore
    //ctx.SubmitUpdates()
  ()

let updateAlbum (album : Album) (artistId, genreId, price, title) _ =
    //album.ArtistId <- artistId
    //album.GenreId <- genreId
    //album.Price <- price
    //album.Title <- title
    //ctx.SubmitUpdates()
  ()

let deleteAlbum (album : Album) _ =
    //album.Delete()
    //ctx.SubmitUpdates()
  ()

let addToCart cartId albumId _  =
    //match getCart cartId albumId ctx with
    //| Some cart ->
    //    cart.Count <- cart.Count + 1
    //| None ->
    //    ctx.``[dbo].[Carts]``.Create(albumId, cartId, 1, DateTime.UtcNow) |> ignore
    //ctx.SubmitUpdates()
  ()

let removeFromCart (cart : Cart) albumId _ =
    //cart.Count <- cart.Count - 1
    //if cart.Count = 0 then cart.Delete()
    //ctx.SubmitUpdates()
  ()

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
