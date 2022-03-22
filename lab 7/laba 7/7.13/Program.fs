// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.29 Дан целочисленный массив и интервал a..b. Необходимо проверить
//наличие максимального элемента массива в этом интервале.
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
    let l = readData
    let max = List.max l
    printfn "Введите интервал"
    let a = int(Console.ReadLine ())
    let b= int (Console.ReadLine ())
    let ans = List.filter(fun x-> if x>a && x<b && x=max then true else false) l
    Console.WriteLine(not(List.isEmpty ans))
    0 // return an integer exit code