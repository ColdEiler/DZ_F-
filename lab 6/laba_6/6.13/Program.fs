// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//1.10
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

let readData1 = 
    printfn "Сколько элементов в списке?"
    let m = System.Convert.ToInt32(System.Console.ReadLine())
    readList m

let rec writeList = function
|[] ->   let z = Console.ReadKey()
         0        
| (head : int)::tail -> 
                   Console.WriteLine(head)
                   writeList tail

let k list x =
    let rec k1 list x count =
        match list with
        |[]->count
        |h::tail-> 
            let newcount =if(h=x) then count + 1 else count
            k1 tail x newcount
    k1 list x 0 

let sovp list1 list2 =
    let rec sovp1 list1 list2 count =
        match list1 with
        |[]->count
        |h::tail->
            let newcount = (k list2 h) + count
            sovp1 tail list2 newcount
    sovp1 list1 list2 0


[<EntryPoint>]
let main argv =
    let l=readData
    let d=readData1
    Console.WriteLine(sovp l d)
    0 // return an integer exit code