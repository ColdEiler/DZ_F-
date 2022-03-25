// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.19
//Дан целочисленный массив.
//Необходимоосуществить циклический сдвиг элементов массива вправо на одну позицию.

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
| (head : int)::tail -> 
                   System.Console.WriteLine(head)
                   writeList tail



[<EntryPoint>]
let main argv =
    let l= readData
    let l2= List.indexed l 
    let newlist = List.filter(fun x-> if fst x < fst (List.last l2) then true else false) l2
    let list = List.map(fun x-> snd x) newlist    
    writeList ( [List.last l] @ list)
    0 // return an integer exit code