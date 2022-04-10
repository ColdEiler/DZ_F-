open System
open System.Windows.Forms
open System.Drawing

Application.EnableVisualStyles()
let form = new Form(Width=502, Height=350,Text = "ЛАБА 9")
let button1 = new Button(Left=10, Top=38, Text="отзеркалить список", Width=100,Height=50)
let label1 = new Label(Text = "Введите список", Left=180,Top=38,Width=96,Height=23)
let TextBox1 = new TextBox(Left=170,Width=200,Top=68,Height=23,Multiline=true,Text= "10 9 8 7 6 5 4 3 2 1 0")
let TextBox2 = new TextBox(Left=170,Width=200,Top=128,Height=23,Multiline=true)


form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize = new System.Drawing.Size(302, 314);
form.Controls.Add(TextBox1);
form.Controls.Add(TextBox2);
form.Controls.Add(label1);
form.Controls.Add(button1);
form.ResumeLayout(false);
form.PerformLayout();


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

let create s =
    let rec r (s:string) newlist=
        match s with
        |""->newlist
        |_->
            let newWord = s.[0 .. (findSpace s-1)]
            let newnewlist=newlist@[int(newWord)]
            let news=s.[findSpace s .. s.Length] 
            r news newnewlist 
    r s []



button1.Click.AddHandler(fun _ _ ->
    let list1 = create TextBox1.Text 
    let list2= List.rev list1
    let run = TextBox2.Text<- (list2 |> Seq.map string |> String.concat ", ")
    run
    |> ignore)            

Application.Run(form)
