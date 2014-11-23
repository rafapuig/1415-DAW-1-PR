using System;
using System.Windows.Forms;


class Program304
{
    static TextBox txtNombre;
    static TextBox txtPrimerApellido;
    static TextBox txtSegundoApellido;
    
        
        static void Main()
    {
        Form form = new Form();
        form.Text = "Mi primer formulario";
        form.Width = 400;
        form.Height = 300;

        Label lblNombre = new Label();
        lblNombre.Top = 40;
        lblNombre.Text = "Nombre:";
        form.Controls.Add(lblNombre);
        
        Label lblPrimerApellido = new Label();
        lblPrimerApellido.Top = 80;
        lblPrimerApellido.Text = "Primer Apellido:";
        form.Controls.Add(lblPrimerApellido);

        Label lblSegundoApellido = new Label();
        lblSegundoApellido.Top = 120;
        lblSegundoApellido.Text = "Segundo Apellido:";
        form.Controls.Add(lblSegundoApellido);

        txtNombre = new TextBox();
        txtNombre.Top = 40;
        txtNombre.Left = 150;
        form.Controls.Add(txtNombre);

        txtPrimerApellido = new TextBox();
        txtPrimerApellido.Top = 80;
        txtPrimerApellido.Left = 150;
        form.Controls.Add(txtPrimerApellido);

        txtSegundoApellido = new TextBox();
        txtSegundoApellido.Top = 120;
        txtSegundoApellido.Left = 150;
        form.Controls.Add(txtSegundoApellido);

        Button btnMostrarNombre = new Button();
        btnMostrarNombre.Top = 150;
        btnMostrarNombre.Left = 150;
        btnMostrarNombre.Click += MostrarNombre;
        form.Controls.Add(btnMostrarNombre);

        Application.Run(form);
    } 
  
    static void MostrarNombre(object source, System.EventArgs e)
    {
        MessageBox.Show(
            string.Format("{0} {1} {2}", 
                            txtNombre.Text, 
                            txtPrimerApellido.Text, 
                            txtSegundoApellido.Text));
    } 

}