// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

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

let k list x =
    let rec k1 list x (count:int) =
        match list with
        |[]->count
        |h::tail-> 
            let newcount =if(h=x) then count + 1 else count
            k1 tail x newcount
    k1 list x 0 

let  kolvo list =
   let rec kolvo1 list res=
        match list with 
        | [] -> res
        | h::tail->
            let newres = res+1     
            kolvo1 tail newres
   kolvo1 list 0

let find list1 list2 c= 
    let rec find1 list1 list2 c res = 
        match list1 with 
        |[]->res
        |h::tail->
            let newres = if (k list2 h <> c) then h else res
            find1 tail list2 c newres
    find1 list1 list2 c 0


[<EntryPoint>]
let main argv =
    let l =readData
    let c = kolvo l - 1
    Console.WriteLine(find l l c)   
    0 // return an integer exit code