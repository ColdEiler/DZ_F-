// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//9 Для введенного списка построить новый список, в который войдут лишь те
//элементы, которые 
//- больше, чем сумма всех предыдущих в исходном списке,
//- являются полным квадратом одного из элементов исходного
//- делятся на все предыдущие элементы исходного списка.

open System

let rec readlist n =
    if n =0 then []
    else
        let Head= int (Console.ReadLine ())
        let Tail = readlist (n-1)
        Head::Tail

let readData= 
    printfn "Сколько элементов в списке?"
    let n= int(Console.ReadLine ())
    readlist n

let rec writeList = function
|[] ->   let z = System.Console.ReadKey()
         0
| (head : int*int*int)::tail -> 
                   System.Console.WriteLine(head)
                   writeList tail


let createl x list =
    let rec r list x newlist = 
        match list with
        |[]-> newlist
        |h::tail->
            if (fst h< fst x)
            then r tail x (newlist@[snd h])
            else r [] x newlist
    r list x []

            
let del list x = 
    let rec r list x (f:bool)=
        match list with 
        |[]-> f
        |h::tail->
            if (fst h < fst x) 
            then 
                if(snd x % snd h = 0) then r tail x true
                else r [] x false 
            else r [] x f
    r list x true 

let count x list =
    let rec r list x res = 
        match list with
        |[]-> res
        |h::tail->
            if (snd h> snd x)
            then r tail x (res+1)
            else r tail x res 
    r list x 0

[<EntryPoint>]
let main argv =
   let l =readData
   let l2 = List.indexed l  
   let result = List.filter(fun (x:int*int) -> if (List.sum (createl x l2)< snd x && List.exists(fun (elem:int*int)-> snd elem*snd elem = snd x) l2) then true else false )  l2
 
   let j = List. map (fun x-> List.sum (createl x l2)) result
   let h = List.map (fun x-> count x l2) result
   let ans = List.map3 (fun x y z-> (snd x,y,z)) result j h 
   writeList ans
   0 // return an integer exit code

   //(INDEX,A[i])


   //(not(List.exists(fun elem-> snd elem % snd x<>0 && fst elem < fst x)l2)
   //List.sum (createl x l2) l2 < snd x 
   //List.exists (fun elem-> snd elem* snd elem= snd x)l2)