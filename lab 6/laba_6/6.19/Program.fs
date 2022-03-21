// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//6.45
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

let interval a b n = if (a<n && n<b) then true else false 
let  obhod f predicate list =
   let rec obhod1 f predicate list res=
        match list with 
        | [] -> res
        | h::tail->
            let newres = f h res 
            if predicate h then obhod1 f predicate tail newres
            else obhod1 f predicate tail res
   obhod1 f predicate list 0

let sum_in_interval list a c = obhod (fun x y-> x+y) (interval a c) list    
[<EntryPoint>]
let main argv =
    let l =readData
    Console.WriteLine("Введите интервал!!!")
    let a= int (Console.ReadLine())
    let b = int (Console.ReadLine())
    sum_in_interval l a b |>Console.WriteLine
    0 // return an integer exit code