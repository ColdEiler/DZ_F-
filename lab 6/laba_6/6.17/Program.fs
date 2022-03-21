// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//1.36 maxnechet
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



let rec nech n = if(n%2<>0) then true else false
     
let  obhod f predicate list =
   let rec obhod1 f predicate list res=
        match list with 
        | [] -> res
        | h::tail->
            let newres = f h res 
            if predicate h then obhod1 f predicate tail newres
            else obhod1 f predicate tail res
   obhod1 f predicate list 0


let listMaxNechet list = obhod (fun x y-> if x>y then x else y) nech list  
[<EntryPoint>]
let main argv =
    let l = readData
    listMaxNechet l |>Console.WriteLine
    0 // return an integer exit code