open System
open System.Windows.Forms
open System.Drawing

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

Application.EnableVisualStyles()
let form = new Form(Text="Работа с массивами",Height=300,Width=550)
let label1 = new Label()
label1.Location<-new Point(100,50)
label1.Text<-"Массив первые 100 делящихся на 13 и на 17 чисел"
label1.Width<-500
label1.Height<-20
let TextBox = new TextBox(Text="",Left = 10,Top = 100,Width=500,Height=100,Multiline=true)  


let button = new Button(Text="Вывести")
button.Location<-new Point(15,50) 
button.Click.AddHandler(fun _ _ ->
let array = read_array 100 
let run = TextBox.Text<- (array |> Seq.map string |> String.concat ", ")
run
|> ignore) 

form.Controls.Add(button)
form.Controls.Add(label1)
form.Controls.Add(TextBox)

Application.Run(form)