// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//1.39
//Дан целочисленный массив. Необходимо вывести вначале его
//элементы с четными индексами, а затем - с нечетными.
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

let fop list (list2:int list) predicate =
    let rec fop1 list (list2: int list) predicate ind newlist=
        match list with 
        |[]->newlist
        |h::tail->
            if (predicate ind = true) 
            then 
                let newnewlist= newlist @ [list2.Item(ind)]
                let newind=ind+1
                fop1 tail list2 predicate newind newnewlist
            else 
                fop1 tail list2 predicate (ind+1) newlist
    fop1 list list2 predicate 0 []

[<EntryPoint>]
let main argv =
    let l = readData  
    let chlist = fop l l (fun x->if x % 2 = 0 then true else false)
    let nechlist= fop l l (fun x->if x % 2 = 1 then true else false)
    let newl= chlist@nechlist
    writeList newl
    0 // return an integer exit code