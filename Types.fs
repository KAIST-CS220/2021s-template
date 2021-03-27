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
