// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
 //метод 1
let prost n =
    let rec prost1 n del =
        if (del=1) then true
        else 
            if (n % del=0) then false
            else 
                let newdel =del-1
                prost1 n newdel
    prost1 n (n-1) 
 
let  mutable  m = 1
let MaxProstDel n = 
    let rec r n del = 
        if (del = 1) then m 
            else 
                let j = if(prost del=true && del>m && n%del=0) then m<-del 
                let newdel=del-1; 
                r n newdel  
    r n n
// метод 2
let prCifrne5 n = 
    let rec prCfrne5_1 n curpr = 
        if n = 0 then curpr
        else
            let cifr = if(n%10%5<>0) then n%10 else 1
            let n1 = n / 10
            let newSum = curpr * cifr
            prCfrne5_1 n1 newSum
    prCfrne5_1 n 1 
//метод 3
let pr n=
    let rec pr_1 n cupr=
        if n =0 then cupr
        else
            let n1=n/10
            let cifr= n%10
            let newpr=cupr*cifr
            pr_1 n1 newpr
    pr_1 n 1

let rec nod a b =
    if a = b then a
    else
        if (a > b) then 
            let new_a = b 
            let new_b = a-b
            nod new_a new_b
        else 
            let new_a = a 
            let new_b = b-a
            nod new_a new_b

let  mutable  b = 1
let maxnechetneprost n =
    let rec t n del =
        if (del=1) then b
        else 
            let j = if(prost del=false && del>m && n%del=0 && del%2<>0) then b<-del 
            let newdel=del-1; 
            t n newdel 
    t n n

let method_3 n = nod (maxnechetneprost n) (pr n)   
[<EntryPoint>]
let main argv =
    let n=Console.ReadLine()|>Int32.Parse
    Console.WriteLine(MaxProstDel n)
    Console.WriteLine(prCifrne5 n)
    Console.WriteLine(method_3 n)
     
    0 // return an integer exit code