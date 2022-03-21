// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//1.36 maxnechet
open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    printfn "Сколько элементов в списке?"
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
|[] ->   let z = Console.ReadKey()
         0        
| (head : int)::tail -> 
                   Console.WriteLine(head)
                   writeList tail  

let rec obhod list (f : int -> int -> int) p acc = 
    match list with
    | [] -> acc
    | h::t ->
                let newAcc = f acc h
                if p h then obhod t f p newAcc
                else obhod t f p acc

let rec nech n = if(n%2<>0) then true else false
     
let listMaxNechet list = obhod list (fun x y-> if x>y then x else y) nech 0 
[<EntryPoint>]
let main argv =
    let l = readData
    listMaxNechet l |> Console.WriteLine 
    0 // return an integer exit code