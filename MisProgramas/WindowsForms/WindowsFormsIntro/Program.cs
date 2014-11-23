using System.Windows.Forms;

class Program
{
    static void Main()
    {
        Form form = new Form();
        form.Text = "Mi primer formulario";
        form.Width = 500;
        form.Height = 200;

        Label lbl = new Label();
        lbl.Text = "Hola Windows";

        form.Controls.Add(lbl);


        Application.Run(form);
    }    
}