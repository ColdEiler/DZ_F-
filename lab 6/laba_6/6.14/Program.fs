// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//1.21
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

let  obhod f list =
   let rec obhod1 f list res=
        match list with 
        | [] -> res
        | h::tail->
            let newres = f h res     
            obhod1 f tail newres
   obhod1 f list 0

let dobav list  =
    let rec r list nlist =
        match list with 
        |[]->nlist
        |h::tail->
            if (h<>obhod max list) 
            then
                let newlist = nlist @ [h]
                r tail newlist
            else nlist
    r list []

let met list = 
    let rec met1 list newlist res=
        match list with 
        | []->newlist
        | h::tail->
            if(h= obhod max list && res < 1) 
            then 
                 let newres=res+1 
                 let d=dobav tail
                 met1 list d newres
            else 
            met1 tail newlist res
    met1 list [] 0

[<EntryPoint>]
let main argv =
    let l = readData
    writeList (met l)     
    
    0 // return an integer exit code