// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
//1.09 
// 1.9 Дан целочисленный массив. Необходимо найти элементы,расположенные перед последним минимальным.

let rec readlist n =
    if n =0 then []
    else
        let Head= int(Console.ReadLine ())
        let Tail = readlist (n-1)
        Head::Tail


let readData= 
    printfn "Сколько элементов в списке ?"
    let n= int(Console.ReadLine ())
    readlist n

let rec writeList = function
|[] ->   let z = System.Console.ReadKey()
         0
| (head : int)::tail -> 
                   System.Console.WriteLine(head)
                   writeList tail

let makenewlist list last=
    let rec r list last newlist ind =
        match list with 
        |[]-> newlist
        | h::tail->
            if(ind <> last)
            then
                let newnewlist= newlist @ [h]
                r tail last newnewlist (ind+1)
            else r [] last newlist ind
    r list last [] 0

[<EntryPoint>]
let main argv =
    let l =readData
    let last = List.findIndexBack (fun x -> if x = List.min l then true else false) l 
    let newlist = makenewlist l last
    Console.WriteLine () 
    writeList newlist
    0 // return an integer exit code