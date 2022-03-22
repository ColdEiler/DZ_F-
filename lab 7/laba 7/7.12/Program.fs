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

let dob list n = 
    let rec dob1 list newlist ind=
        match list with
        |[]->newlist
        |h::tail->
            if(ind<> n)
            then dob1 tail (newlist@[h]) (ind+1)
            else dob1 [] newlist ind
    dob1 list [] 0

[<EntryPoint>]
let main argv =
    let l= readData
    let newlist = dob l (List.length l - 1)
    writeList ([l.Item(List.length l - 1)] @ newlist)
     
    0 // return an integer exit code