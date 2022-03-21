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

let obhod n f predicate init =
    let rec obhod1 n f predicate init dev=
       if (dev=1) then init
       else
            let newinit = if (n % dev = 0 && predicate dev ) then f init dev else init
            let newdev = dev - 1
            obhod1 n f predicate newinit newdev
    obhod1 n f predicate init n

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


let method_3 n = nod (obhod n (fun x y-> if x>y then x else y) (fun x-> not(prost x)) 1)  (pr n)   
[<EntryPoint>]
let main argv =
    let n=Console.ReadLine()|>Int32.Parse
    Console.WriteLine(obhod n (fun x y-> if x>y then x else y) prost 1)
    Console.WriteLine(prCifrne5 n)
    Console.WriteLine(method_3 n)
     
    0 // return an integer exit code

