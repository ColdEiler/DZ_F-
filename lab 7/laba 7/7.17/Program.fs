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
            
[<EntryPoint>]
let main argv =
   let l =readData
   let l2 = List.indexed l  
   let createl x list = List.filter (fun y-> if fst y < fst x then true else false) list
   let cr x list = List.map (fun x->snd x) (createl x list)
   let result = List.filter(fun (x:int*int) -> if (List.sum (cr x l2)< snd x && List.exists(fun (elem:int*int)-> snd elem*snd elem = snd x) l2 && not (List.exists(fun elem->  snd x % elem <> 0) (cr x l2))) then true else false )  l2
  // writeList result 
   let j = List. map (fun x-> List.sum (cr x l2)) result
   let h = List.map (fun x-> List. length (List.filter(fun elem-> if (snd x<elem) then true else false) l)) result
   let ans = List.map3 (fun x y z-> (snd x,y,z)) result j h 
   writeList ans
   0 

   //(INDEX,A[i])


   //(not(List.exists(fun elem-> snd elem % snd x<>0 && fst elem < fst x)l2)
   //List.sum (createl x l2) l2 < snd x 
   //List.exists (fun elem-> snd elem* snd elem= snd x)l2)