using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    public partial class Form1 : Form
    {
        Form form2;
        Form form3;

        public Form1()
        {
            InitializeComponent();

            form2 = new Form2();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;

            form3 = new Form3();
            form3.TopLevel = false;
            form3.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            applyState(form2);
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            applyState(form3);
        }

        private void applyState(Form nextState)
        {
            if (this.panel1.Controls.Count == 1)
            {
                Form curr = this.panel1.Controls[0] as Form; // we only accept Forms so this shouldn't fail
                curr.Hide(); // de bun simt (cred? nu stiu daca influneteaza cu ceva un Form scos din ierarhie dar care inca e 'vizibil')
                // daca se dovedeste ca nu conteaza cu form-uri complete, se poate scoate...
            }
            
            this.panel1.Controls.Clear(); // remove old form
            this.panel1.Controls.Add(nextState); // add new form
            nextState.Size = this.panel1.Size;
            nextState.Show();
            this.panel1.Refresh();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            if ( this.panel1.Controls.Count == 1 )
            {
                this.panel1.Controls[0].Size = this.panel1.Size;
            }
        }
    }
}
