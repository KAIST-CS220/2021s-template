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

let myfunc x y =
  x + y
