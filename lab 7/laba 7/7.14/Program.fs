// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.39
//Дан целочисленный массив. Необходимо вывести вначале его
//элементы с четными индексами, а затем - с нечетными.
let rec readlist n =
    if n =0 then []
    else
        let Head= int (Console.ReadLine ())
        let Tail = readlist (n-1)
        Head::Tail


let readData= 
    printfn "Сколько элементов в списке ?"
    let n= int(Console.ReadLine ())
    readlist n

let rec writeList = function
|[] ->   let z = System.Console.ReadKey()
         0
| (head : int*int)::tail -> 
                   System.Console.WriteLine(fst head)
                   writeList tail

let normList list=
    let rec r list newlist = 
        match list with 
        |[]->newlist
        |(h:int*int)::tail->
            let newnewlist = newlist @ [snd h]
            r tail newnewlist
    r list []

[<EntryPoint>]
let main argv =
    let l = readData
    let l2= List.indexed l 
    let chlist = List.filter(fun x -> if fst x % 2 =0 then true else false) l2
    let nechlist = List.filter(fun x-> if fst x % 2 <> 0 then true else false) l2
    let l3 = chlist@nechlist
    writeList l3
    0 // return an integer exit code