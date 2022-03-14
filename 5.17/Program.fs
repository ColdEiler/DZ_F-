// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
let rec nod a b =
    if a = b then a
    else
        if (a > b) then 
            let new_a = b 
            let new_b = a-b
            nod new_a new_b
        else 
            let new_a = a 
            let new_b = b-a
            nod new_a new_b

// взаимнопростые делители
let prst x f init =
    let rec prst1 x f init cand=
        if cand <= 0 then init
        else 
            let newinit = if nod x cand = 1 then f init cand else init
            let newcand = cand-1
            prst1 x f newinit newcand
    prst1 x f init x

// делители
let obhod n f init =
    let rec obhod1 n f init dev =
       if (dev=0) then init
       else
            let newinit = if (n % dev =0 ) then f init dev else init
            let newdev = dev - 1
            obhod1 n f newinit newdev
    obhod1 n f init n

let  VzaimDel n predicate f init=
    let f1 init div = if predicate div then f init div else init
    prst n f1 init 

let Vsedel n predicate f init =
    let f2 init div = if predicate div then f init div else init 
    obhod n f2 init

[<EntryPoint>]
let main argv =
    let n =Console.ReadLine()|>Int32.Parse
    Console.WriteLine(Vsedel n (fun x-> x%2=0) (fun x y->x+y) 0)
    Console.WriteLine(VzaimDel n (fun x-> x>0) (fun x y-> x+y)0)
    0 