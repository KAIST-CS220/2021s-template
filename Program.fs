module CS220.Program // This line declares Program module.

open CS220.Library

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

[<EntryPoint>] // This line is essential for a program as it defines the main entry point of this program.
let main argv =
  let p = myfunc [ 'a' .. 'z']
  p.Parse "abc123" |> printfn "%A"
  0 // DON't touch this; this is an integer exit code meaning successful termination.
