// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
// 3 Дана строка в которой слова записаны через пробел. Необходимо
//перемешать все слова этой строки в случайном порядке.
// 8
//Дана строка в которой записаны слова через пробел. Необходимо
//посчитать количество слов с четным количеством символов.
//16
//Дан массив в котором находятся строки "белый", "синий" и
//"красный" в случайном порядке. Необходимо упорядочить массив так,
//чтобы получился российский флаг.

let ReadRussiaArr n = 
    let  rec r n arr =
        if (n=0) then arr
        else
            let tail= System.Console.ReadLine()
            let newarr = Array.append arr[|tail|]
            let n1 =n-1
            r n1 newarr
    r n Array.empty

let rec writeList = function
    |[]-> let z =System.Console.ReadKey()
          0
    |(head:string)::tail ->
                    System.Console.WriteLine(head)
                    writeList tail
// поиск пробела 
let findSpace s=
    let rec r s ind symbol = 
        match s with 
        |""| " "-> ind+1
        |_->
            match symbol with 
            |' '-> ind
            |_ ->
                let newind= ind+1
                let newsymbol = s.[0]
                let newS = s.[1..String.length s]
                r newS newind newsymbol
    r s 0 'a'
// разбиение строки на слова
let razb (s:string) = 
    let rec cutWord (s:string) (words : 'string list)  =
        match s with
        |""->words
        |_->
            let newWord = s.[0 .. (findSpace s-1)]
            let newS= s.[(findSpace s).. String.length s]
            cutWord newS (words@[newWord])
    cutWord s []

// перемешивание листа по длине слов
let per s =
    let newS = razb s 
    let rnd = System.Random()
    let pers= List.permute (fun x->(x+3)%List.length newS)newS 
    pers
// сборка списка слов в строку
let ListToString (list: 'string list) = 
    let rec r list (str : string) =
        match list with
        |[]->
            let newS = str.[1..(String.length str - 1)]
            newS
        | h::tail->
            let newS = str + " " + h
            r tail newS
    r list ""

let perWords str = ListToString(per str)

let rec accCond list (f: string->int->int) p acc = 
    match list with 
    |[]->acc
    | h::tail->
            let newAcc= f h acc
            if p h then accCond tail f p newAcc
            else accCond tail f p acc
 
let evenWordsCount (s:string) = 
    let res = accCond (razb s) (fun x y-> if (x.Length % 2 = 0) then y + 1 else y ) (fun x-> true) 0
    res

let rusArr (arr:string array) = 
    let newarr = Array.sortBy (fun (x:string)-> x.[1]) arr 
    newarr

let defaultF s = Console.WriteLine ("Чел...")

let choose n = 
    match n with 
    | 1-> 
        let (s:string) = Console.ReadLine()
        Console.WriteLine (perWords s)
    | 2 -> 
        let (s:string) = Console.ReadLine()
        Console.WriteLine (evenWordsCount s)
    |3->
        let arr = ReadRussiaArr 3 
        printfn "%A" (rusArr arr)
    |_-> defaultF ""

[<EntryPoint>]
let main argv =
    Console.WriteLine("Выберите функцию:")
    Console.Write (
    "    1. Перемешать слова в строке \n
    2. Кол-во четных по длине слов \n 
    3.Флаг Россиюшки нашей из слов Белый Красный Синий в любом порядке\n")
    let n = int(Console.ReadLine())
    choose n 
    0 // return an integer exit code