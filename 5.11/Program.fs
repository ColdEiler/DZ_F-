// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let myans =function
|"F#"|"Prolog"->"Чел, ну ты и подлиза"
|"Pascal"->"Вы случайно не Кирилл Цветков?"
|"Python"->"На дудке игрец?"
|"Java"->"Пройдемте на конференцию"
|"Swift"->"Apple ушла из рынка("
|"Php"->"Хорош,  ты купил слона"
|"C++"-> "Распаралелил метод Зейнделя?"
|"JavaScript"-> "1+1=11"
|"Assembler"->" О циклах слышал?"
|_->"Еще что расскажешь?"

[<EntryPoint>]
let main argv =
    printfn "Какой ваш любимый язык?"
    let ans=Console.ReadLine()
    Console.WriteLine(myans ans)
    0 // return an integer exit code