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
