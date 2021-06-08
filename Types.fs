namespace CS220

type Shape =
  /// A circle of a radius.
  | Circle of float
  /// A square with a side length.
  | Square of float
  /// A triangle with side lengths.
  | Triangle of float * float * float

/// My own list.
type MyList<'T> =
  | Nil
  | Cons of 'T * MyList<'T>

/// Type IntTree
type IntTree =
  | Node of left: IntTree * int * right : IntTree
  | Empty

type ILocatable =
  abstract X: float
  abstract Y: float

[<AbstractClass>]
type Animal (age: int) =
  member __.Age with get () = age

type Dog (age, x, y) =
  inherit Animal(age)
  interface ILocatable with
    member __.X = x
    member __.Y = y

type Cat (age, x, y) =
  inherit Animal(age)
  interface ILocatable with
    member __.X = x
    member __.Y = y

type Elephant (age, x, y) =
  inherit Animal(age)
  interface ILocatable with
    member __.X = x
    member __.Y = y

type Stream<'a> =
  | Nil
  | Cons of 'a * (unit -> Stream<'a>)

type LoggableInteger = {
  Value: int
  Log: string list
}

type Parser<'a> = {
  Parse: string -> Result<'a * string, string>
}

module Parser =
  let char ch =
    { Parse = fun s ->
        if System.String.IsNullOrEmpty (s) then Error "No more input."
        else
          if s.[0] = ch then Ok (s.[0], s.[1..])
          else Error "Invalid char." }

type ParserBuilder () =
  member __.Bind (p, f) =
    { Parse = (fun s ->
               match p.Parse s with
               | Ok (v, rest) -> (f v).Parse rest
               | Error e -> Error e) }

  member __.Return (v) =
    { Parse = (fun s -> Ok (v, s)) }

type Expr =
  | Number of int
  | Add of Expr * Expr
  | Sub of Expr * Expr
