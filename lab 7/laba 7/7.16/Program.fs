// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

//1.59. Дан список. Построить новый список из квадратов
//неотрицательных чисел, меньших 100 и встречающихся в массиве
//больше 2 раз.

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
    let l2 = List.filter (fun x -> if fst x<100 && fst x>0 && snd x > 2 then true else false) (List.countBy id l)
    let ans = List.map (fun x-> fst x * fst x) l2 
    Console.WriteLine()
    writeList ans 
    0 // return an integer exit code