// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.19
//Дан целочисленный массив.
//Необходимоосуществить циклический сдвиг элементов массива вправо на одну позицию.

let rec readlist n =
    if n =0 then []
    else
        let Head= Console.ReadLine ()
        let Tail = readlist (n-1)
        Head::Tail


let readData= 
    printf "Сколько элементов в списке ?"
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
  
    0 // return an integer exit code