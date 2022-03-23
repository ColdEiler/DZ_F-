// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.49. Для введенного списка положительных чисел построить список всех
//положительных простых делителей элементов списка без повторений.

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

let prost n = 
    let rec r n del =
        if (del = 1) then true
        else
            if (n%del = 0) then false
                else r n (del-1)
    r n (n-1)

let dev n = 
    let rec r n del newlist = 
        if (del=1) then newlist
        else 
            if (n % del=0) 
            then 
                let newnewlist = newlist @ [del]
                r n (del-1) newnewlist
            else r n (del-1) newlist
    r n n []

let makedelList list = 
    let rec r list newlist = 
        match list with 
        |[]->newlist
        |h::tail ->
            let newnewlist = newlist @ dev h
            r tail newnewlist
    r list []
[<EntryPoint>]
let main argv =
    let l = readData
    let ans = Set.toList(Set.ofList (List.filter (fun x -> if prost x then true else false ) (makedelList l)))
    writeList ans 
    0 // return an integer exit code