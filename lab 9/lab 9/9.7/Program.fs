open System
open System.Drawing
open System.Windows.Forms

let form = new Form(
    Width= 373, Height = 400,
    Visible = true,
    Text = "Лаба 7 F#",
    Menu = new MainMenu()
)


let button = new  Button (Text = "ответ", Left=230,Top=9,Width=100,Height=50)
let label4 = new Label (Text="0",Left = 20,Top=9,Width=50,Height=50)
let textBox1 = new TextBox(Text="0", Left=10, Top=100, Width=55,
Height=20)
let textBox2 = new TextBox(Text="0", Left=71, Top=100, Width=55,
Height=20)
let textBox3 = new TextBox(Text="0", Left=151, Top=100, Width=55,
Height=20)


let label1 = new Label(Text="для cos x", Left=10, Top=80, Width=50, Height=16)
let label2 = new Label(Text="для sin x", Left=70, Top=80, Width=50, Height=13)
let label3 = new Label(Text="для tg x", Left=151, Top=80, Width=50, Height=13)

form.Controls.Add(label4);
form.Controls.Add(button);
form.Controls.Add(label1);
form.Controls.Add(label3);
form.Controls.Add(label2);
form.Controls.Add(textBox3);
form.Controls.Add(textBox2);
form.Controls.Add(textBox1);

let ravno _ = 
    let ans(a,b,c) =
        (Math.Cos(a*Math.PI/180.0),
         Math.Sin(b*Math.PI/180.0),
         Math.Tan(c*Math.PI/180.0))
    let x = (float(textBox1.Text),float(textBox2.Text),float(textBox3.Text))
    let r = ans x 
    label4.Text<-string r
let _ = button.Click.Add(ravno)     

do Application.Run(form)



