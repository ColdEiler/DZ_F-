// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
// рекурсия вверх
let rec upr x =
    if (x=0) then 1
    else (x%10)*upr(x/10)
// рекурсия вниз
let  vpr x =
    let rec vpr1 x curpr =
        if x=0 then curpr
        else
            let x1 =x/10
            let cifr=x%10
            let newpr= cifr*curpr
            vpr1 x1 newpr
    vpr1 x 1 
    // min chislo up
let rec umin x =
    if(x<10) then x
        else min (x%10) (umin(x/10)) 
    // min chislo down 
let  dmin x=
    let rec umin1 x cupr=
        if (x=0)then cupr
        else 
            let x1=x/10;
            let cifr=x%10;
            let m= if cupr>cifr then cifr else cupr 
            umin1 x1 m
    umin1 x 10

    // max chislo up

let rec umax x=
    if(x<10) then x
        else max (x%10) (umax(x/10))
      // max chislo down 
let  dmax x=
      let rec dmax1 x cupr=
          if (x=0)then cupr
          else 
              let x1=x/10;
              let cifr=x%10;
              let m= if cupr<cifr then cifr else cupr 
              dmax1 x1 m
      dmax1 x -1

    

[<EntryPoint>]
let main argv =
    
    printfn "Произведение цифр числа"
    let x = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Рекурсия вверх числа {0}", upr x)
    Console.WriteLine("Рекурсия вниз числа {0}", vpr x)

    printfn "Минимальная цифра в числе"
    let z = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Рекурсия вверх числа {0}", umin z)
    Console.WriteLine("Рекурсия вниз числа {0}", dmin z) 
    
    printfn "Максимальная цифра  в числе"  
    let y = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Рекурсия вверх числа {0}", umax y)
    Console.WriteLine("Рекурсия вниз числа {0}", dmax y)


    0 // return an integer exit code