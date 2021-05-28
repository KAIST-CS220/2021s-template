module CS220.Library // This line declares Library module.

type LoggerBuilder () =
  member __.Bind (m, f) =
    failwith "implement"

  member __.Return (m) =
    failwith "implement"

let logger = LoggerBuilder ()

/// This function splits the given string into an array of words.
let splitWords (str: string) =
  System.Text.RegularExpressions.Regex.Split(str, @"\s+")

let parser = ParserBuilder ()

let andThen p1 p2 =
  parser {
    let! a = p1
    let! b = p2
    return (a, b)
  }

let (.>>.) = andThen

let map f parser =
  { Parse = fun s ->
      match parser.Parse s with
      | Ok (v, rest) -> Ok (f v, rest)
      | Error e -> Error e }

let (|>>) p f = map f p

let orElse p1 p2 =
  { Parse = fun s ->
      match p1.Parse s with
      | Ok (v, rest) -> Ok (v, rest)
      | Error _ -> p2.Parse s }

let (<|>) = orElse

let myfunc lst =
  failwith "Implement"
