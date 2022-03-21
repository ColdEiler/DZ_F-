// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.57 Для введенного списка найти количество таких элементов, которые
//больше, чем сумма всех предыдущих.

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

let  doh list x =
   let rec doh1 list x newlist=
        match list with 
        | [] -> newlist
        | h::tail->
            if(h<>x) 
            then
                let newnewlist = newlist @ [h]
                doh1 tail x newnewlist
            else doh1 [] x newlist
   doh1 list x []

let sum list= obhod (fun x y->x+y) list

let kolv list = 
    let rec kolv1 list list1 res=
        match list with
        | []->res
        | h::tail->
            if(h>sum (doh list1 h)) then kolv1 tail list1 (res+1)
            else kolv1 tail list1 res
    kolv1 list list 0
            

[<EntryPoint>]
let main argv =
    let l = readData
    kolv l|>Console.WriteLine
    
    0 // return an integer exit code