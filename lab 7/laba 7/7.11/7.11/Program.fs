// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.09 
// 1.9 Дан целочисленный массив. Необходимо найти элементы,расположенные перед последним минимальным.
let rec readlist n =
    if n =0 then []
    else
        let Head= int (Console.ReadLine ())
        let Tail = readlist (n-1)
        Head::Tail

let readData= 
    printfn "Сколько элементов в списке ?"
    let n = int (Console.ReadLine())
    readlist n

let rec writeList = function
|[] ->   let z = System.Console.ReadKey()
         0
| (head : int*int)::tail -> 
                   Console.WriteLine(snd head)
                   writeList tail

[<EntryPoint>]
let main argv =
    let l = readData
    let l2 = List.indexed l 
    let last= List.findIndexBack (fun x-> if (x = List.min l) then true else false) l
    let result = List.filter (fun x-> if fst x < last then true else false) l2 
    writeList result
     
    0 // return an integer exit code
