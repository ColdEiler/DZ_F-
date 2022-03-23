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


let sum list x= 
    let rec r list x sum = 
        match list with 
        |[]-> sum
        |h::tail->
            if(snd x<>snd h)
            then r tail x (sum+fst h)
            else r [] x sum
    r list x 0

//let del list x = 
  //  let rec r list x (f:bool)=
    //    match list with 
      //  |[]-> f
        //|h::tail->
          //  if (snd h <> snd x) 
            ///then 
               /// if(fst h % fst x = 0) then r tail x true
                //else r [] x false 
            //else r [] x f
    ///r list x true 

let map list list2 count = 
   let rec map2 list list2 count newlist = 
       match list with
        |[]-> newlist
        |h::tail ->
            let newnewlist = newlist @ [(fst h, sum list2 h,count h list2)]
            map2 tail list2 count newlist 
   map2 list list2 count [] 

let count x list =
    let rec r list x res = 
        match list with
        |[]-> res
        |h::tail->
            if (fst h> fst x)
            then r tail x (res+1)
            else r tail x res 
    r list x 0

[<EntryPoint>]
let main argv =
   let l =readData
   let l2 = List.indexed l 
   let result = List.filter (fun (x:int*int)-> if ( not (List.exists(fun elem-> fst elem % fst x<>0 && snd elem < snd x)l2) && sum l2 x < fst x && (List.exists (fun elem-> fst elem* fst elem= fst x)l2)) then true else false) l2
   let ans = map result l2 count 
   0 // return an integer exit code