open System
//1.33 Дан целочисленный массив. Проверить, чередуются ли в нем положительные и отрицательные числа.

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

let rec cher list acc= 
    if(kolvo list =1) then acc 
    else 
        match list with
        h::tail->
            let newacc=if (h*tail.Head<0) then true else false
            cher tail newacc
            

[<EntryPoint>]
let main argv =
    let l = readData 
    (cher l true)|>Console.WriteLine
    0 // return an integer exit code