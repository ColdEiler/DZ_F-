// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//1.23 2 min
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

let  obhod f list res =
   let rec obhod1 f list res=
        match list with 
        | [] -> res
        | h::tail->
            let newres = f h res     
            obhod1 f tail newres
   obhod1 f list res

let rec dob list min new_list =
    match list with
    |[] -> new_list
    |h::t ->
            if h = min then 
                let new_new_list = new_list @ [] 
                dob t min new_new_list
            else
                let new_new_list = new_list@[h]
                dob t min new_new_list     
            

[<EntryPoint>]
let main argv =
    let l = readData
    let min1 = obhod (fun x y-> if x<y then x else y)  l l.Head
    let new_list = dob l min1 []
    let min2 = obhod (fun x y-> if(x<y) then x else y) new_list new_list.Head
    Console.WriteLine(min1)
    Console.WriteLine(min2)
    0 // return an integer exit code