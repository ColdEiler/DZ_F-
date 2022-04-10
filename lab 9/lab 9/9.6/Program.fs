open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open System

let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let initWindow() =
    let xaml = "
        <Window
        	xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
        	xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' Title='F# WPF' Height='280' Width='320'>
        	<Grid>
        		<Grid.ColumnDefinitions>
        			<ColumnDefinition Width='320*' />
        		</Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height='140*' />
                    <RowDefinition Height='140*' />
                </Grid.RowDefinitions>
                <ProgressBar Height ='30' HorizontalAlignment = 'Center' Margin='20,30,0,0'
                            Name = 'ProgressBar1'  Width = '200'/>
                <TextBox Height='23' HorizontalAlignment='Center' Margin='20,30,0,0'
                 Name='TextBox1' VerticalAlignment='Top' Width='200' Grid.ColumnSpan='2'
                 IsEnabled='True'  />       		
        	</Grid>
        </Window>
    "
    let win = getWindow xaml
    let TextBox1 = win.FindName("TextBox1") :?> TextBox 
    let ProgressBar1 = win.FindName ("ProgressBar1"):?> ProgressBar

    let Change _ = ProgressBar1.Value <-float(String.length TextBox1.Text)
    let _ = TextBox1.TextChanged.Add(Change)

    win


[<EntryPoint>]
[<STAThread>] 
let main argv =
    let win = initWindow()
    ignore <| (new Application()).Run win
    0
   