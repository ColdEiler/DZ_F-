// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый язык программирования?"
    let answer x  = 
        match x with 
        | "F#"|"Prolog"->"Чел, ну ты и подлиза"
        |"Pascal"->"Вы случайно не Кирилл Цветков?"
        |"Python"->"На дудке игрец?"
        |"Java"->"Пройдемте на конференцию"
        |"Swift"->"Apple ушла из рынка("
        |"Php"->"Хорош,  ты купил слона"
        |"C++"-> "Распаралелил метод Зейнделя?"
        |"JavaScript"-> "1+1=11"
        |"Assembler"->" О циклах слышал?"
        |_->"Еще что расскажешь?"    
    //12.1
    (Console.ReadLine>>answer>>Console.WriteLine)()
    //12.2
    //let z =Console.ReadLine()
    let pot (x:string->unit) y z =  x(y (z()))
    pot Console.WriteLine answer Console.ReadLine

    
    0 // return an integer exit code