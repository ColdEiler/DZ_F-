// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let obhod n f init =
    let rec obhod1 n f init dev=
       if (dev=0) then init
       else
            let newinit = if (n % dev = 0) then f init dev else init
            let newdev = dev - 1
            obhod1 n f newinit newdev
    obhod1 n f init n


[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|>Int32.Parse
    obhod n (fun x y-> x*y) 1 |> Console.WriteLine
    0
