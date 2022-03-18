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

let  kolvo list =
   let rec kolvo1 list res=
        match list with 
        | [] -> res
        | h::tail->
            let newres = res+1     
            kolvo1 tail newres
   kolvo1 list 0

let Dobav list = 
    if kolvo list % 3 = 0 then list 
    else 
        if kolvo list % 3 = 1 then list @ [1] @ [1]
        else list @ [1]

let sum f list=
    let rec sum f list newlist = 
        match list with 
        | []-> newlist
        |h::tail->
            let h2 = tail.Head
            let h3 =tail.Tail.Head
            let res = f h h2 h3
            let Nextlist = newlist @ [res]
            sum f tail.Tail.Tail Nextlist
    sum f list []
                

[<EntryPoint>]
let main argv = 
    let l = readData
    printfn "Список после применения функции Sum:"
    writeList (sum (fun x y z -> x+y+z) (Dobav l)) 
    
    0 // return an integer exit code