//Разработать программу, на главной форме разместить
//поле для ввода и индикатор хода загрузки. По мере ввода текста
//в поле ввода заполняется индикатор.
open System 
open System.Windows.Forms
open System.Drawing 
open System.IO

let Form = new Form(Width= 400, Height = 300, Text = "лаба 5")
let ProgressBar1 = new ProgressBar(Dock=DockStyle.Top)

let TextBox1 = new TextBox (Width = 300,Height=100,Top=50,MaxLength = 100)
Form.Controls.Add(ProgressBar1)
Form.Controls.Add(TextBox1)

let Change _ = ProgressBar1.Value <- TextBox1.TextLength
let _ = TextBox1.TextChanged.Add(Change)

 

[<EntryPoint>]
let main argv =
    do Application.Run(Form)
    0 // return an integer exit code