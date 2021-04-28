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

[<AbstractClass>]
type Animal (age: int) =
  member __.Age with get () = age

type Dog (age) =
  inherit Animal(age)

type Cat (age) =
  inherit Animal(age)
