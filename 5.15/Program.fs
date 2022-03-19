open System

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

let prst x f init =
    let rec prst1 x f init cand=
        if cand <= 1 then init
        else 
            let newinit = if nod x cand =1 then f init cand else init
            let newcand = cand-1
            prst1 x f newinit newcand
    prst1 x f init x

let euler x=
    prst x (fun t y->t+1) 0

[<EntryPoint>]
let main argv =
    let x = Console.ReadLine() |> Int32.Parse
    printfn "Сумма взаимнопростых чисел: %d" (prst x (fun a b -> a + b) 0)
    printfn "Число Эйлера: %d" (euler x)
    0 