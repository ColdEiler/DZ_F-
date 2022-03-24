// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let read_array n =
    let rec read_array_r n arr pos13 pos17 = 
        if n = 0 then
            arr
        else
            let tail1= 13*pos13
            let tail2 = 17*pos17
            if (tail1<tail2) 
            then
                let newarr= Array.append arr [|tail1|]
                read_array_r (n-1) newarr (pos13+1) pos17 
            else 
                let newarr= Array.append arr [|tail2|]
                read_array_r (n-1) newarr pos13 (pos17+1)
    read_array_r n [||] 1 1 

let write_array arr =
    printfn "%A" arr

[<EntryPoint>]
let main argv =
    let n=100
    let arr= read_array 100 
    write_array arr
    0
    // let new_arr = Array.append arr [|tail|]
   