// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

//9
//В порядке увеличения квадратичного отклонения между наибольшим ASCII-кодом символа строки и разницы в ASCII-кодах пар зеркально
//расположенных символов строки (относительно ее середины)
//10 В порядке увеличения среднего количества «зеркальных» троек
//(например, «ada») символов в строке

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() 
        let Tail = readList (n-1)
        Head::Tail

let rec writeList = function
    [] ->   []
    | (head:string)::tail -> 
                   Console.WriteLine(head)
                   writeList tail 

let readData =
    printfn "Сколько элементов в списке?"
    let n = int(Console.ReadLine())
    readList n 
//10
let tr s = 
    let rec r (s:string) n acc =
        match n with 
        |1->acc
        |_->
            if (s.[n]=s.[n-2]) then r s (n-1) (acc+1)
            else r s (n-1) acc
    r s ((String.length s)-1) 0

let tri list =
    let rec r list newlist =
        match list with 
        |[]->newlist
        |(h:string)::tail->
            r tail (newlist @ [tr h])
    r list []
//10
//11
let kod (s:char) = int (s)

let maxkod s =
    let rec r (s:string) n acc =
        match n with 
        |(-1)->acc
        |_->
            if (kod(s.[n])>acc) then r s (n-1) (kod(s.[n]))
            else r s (n-1) acc
    r s ((String.length s)-1) 0       

let maxdiff s =
    let rec r (s:string) n acc =
        match n with 
        |(-1)->acc
        |_->
            let diff = kod(s.[n])-kod(s.[(String.length s)- 1- n])
            if (kod(s.[n])>acc) then r s (n-1)  diff
            else r s (n-1) acc
    r s ((String.length s)-1) 0  

let lala list = 
    let rec r list newlist = 
        match list with 
        |[]-> newlist
        | (h:string)::tail ->
            r tail (newlist @ [(maxkod h - maxdiff h)*(maxkod h - maxdiff h)])
    r list []

[<EntryPoint>]
let main argv =
    let l = readData
    let chislo, l2 = List.unzip (List.sort(List.zip (tri l) l))
    writeList l2
    Console.WriteLine()
    let cchislo, l3 = List.unzip (List.sort (List.zip (lala l) l))
    writeList l3 
    0 // return an integer exit code