module CS220.Library // This line declares Library module.

type BankAccount () =
  let mutable balance = 0
  member __.GetBalance () = balance
  member __.Deposit amount =
    balance <- balance + amount
