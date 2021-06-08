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

let rec zeroOrMore p s =
  match p.Parse s with
  | Error _ -> ([], s)
  | Ok (v, s) ->
    let v', s' = zeroOrMore p s
    v :: v', s'

let many p = { Parse = fun s -> Ok (zeroOrMore p s) }

let digit = ['0'..'9'] |> List.map Parser.char |> List.reduce (<|>)

let number =
  parser {
    let! d = digit
    let! ds = many digit
    return (d :: ds)
  } |>> (List.toArray >> System.String >> int >> Number)

let mutable exprRef = { Parse = fun _ -> failwith " XXX " }
let expr = { Parse = fun s -> exprRef.Parse s }

let add =
  parser {
    let! n = number
    let! _ = Parser.char '+'
    let! e = expr
    return Add (n , e)
  }

let sub =
  parser {
    let! n = number
    let! _ = Parser.char '-'
    let! e = expr
    return Sub (n , e)
  }

exprRef <- add <|> sub <|> number

let myfunc lst =
  failwith "Implement"
