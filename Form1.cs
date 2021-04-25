using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//AJUSTES
//  {
//      FIX MULT;
//  }
//

namespace MaquinaNorma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtConsole.ReadOnly = true;

        }

        private Par Initialize(Par par)
        {

            Par reg = new Par();
            reg.name = par.name;
            reg.value = new int[] { 0, 0 };

            while (par.value[1] != 0)
            {
                txtConsole.AppendText("Inicializando o registrador " + reg.name + " // valor atual: " + reg.value[1] + "\n" + Environment.NewLine);
                Dec(par);
                Inc(reg);
            }
            txtConsole.AppendText("Registrador " + reg.name + " inicializado como: " + reg.value[1] + "\n" + Environment.NewLine);
            return reg;
        }
        private Par Soma(Par A, Par B)
        {
            if (A.value[1] > B.value[1])
            {
                while (!Zero(B))
                {
                    A = Inc(A);
                    B = Dec(B);
                }
                return A;
            }
            else
            {
                while (!Zero(A))
                {
                    B = Inc(B);
                    A = Dec(A);
                }
                return B;
            }

        }
        private Par Sub(Par A, Par B)
        {
            while (!Zero(B))
            {
                Dec(A);
                Dec(B);
                if (Zero(B))
                {
                    A.value[0] = 1;
                }
            }
            return A;
        }
        private Par Mult(Par A, Par B)
        {
            Par C = new Par();
            Par D = new Par();
            C.name = "C";
            C.value = new int[] { 0, 0 };
            D.name = "D";
            D.value = new int[] { 0, 0 };


            while (!Zero(A))
            {
                C = Inc(C);
                A = Dec(A);
            }
            while (!Zero(C))
            {
                while (!Zero(B))
                {
                    A = Inc(A);
                    D = Inc(D);
                    B = Dec(B);
                }
                while (!Zero(D))
                {
                    B = Inc(B);
                    D = Dec(D);
                }
                C = Dec(C);
            }
            return A;
        }
        private Par Inc(Par par)
        {
            txtConsole.AppendText("Reg" + par.name + " Inc(" + par.value[1] + "), seu valor agora é: " + (par.value[1] + 1) + "\n" + Environment.NewLine);
            par.value[1]++;
            return par;
        }
        private Par Dec(Par par)
        {
            txtConsole.AppendText("Reg" + par.name + " Dec(" + par.value[1] + "), seu valor agora é: " + (par.value[1] - 1) + "\n" + Environment.NewLine);
            par.value[1]--;
            return par;
        }
        private bool Zero(Par X)
        {
            if (X.value[1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnSoma_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
            Par A = new Par();
            A.name = "A";
            A.value = new int[] { 0, Convert.ToInt32(txtA.Text) };
            Par B = new Par();
            B.name = "B";
            B.value = new int[] { 0, Convert.ToInt32(txtB.Text) };
            A = Initialize(A);
            B = Initialize(B);
            var result = Soma(A, B);
            txtConsole.AppendText("-- Soma finalizada --" + "\n" + Environment.NewLine);
            txtConsole.AppendText("Resultado: " + result.value[1] + "\n" + Environment.NewLine);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
            Par A = new Par();
            A.name = "A";
            A.value = new int[] { 0, Convert.ToInt32(txtA.Text) };
            Par B = new Par();
            B.name = "B";
            B.value = new int[] { 0, Convert.ToInt32(txtB.Text) };
            A = Initialize(A);
            B = Initialize(B);
            var result = Sub(A, B);
            if (result.value[0] == 0)
            {
                txtConsole.AppendText("-- Subtracao finalizada --" + "\n" + Environment.NewLine);
                txtConsole.AppendText("Resultado: -" + result.value[1] + "\n" + Environment.NewLine);
            }
            else
            {
                txtConsole.AppendText("-- Subtracao finalizada --" + "\n" + Environment.NewLine);
                txtConsole.AppendText("Resultado: " + result.value[1] + "\n" + Environment.NewLine);
            }
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
            Par A = new Par();
            A.name = "A";
            A.value = new int[] { 0, Convert.ToInt32(txtA.Text) };
            Par B = new Par();
            B.name = "B";
            B.value = new int[] { 0, Convert.ToInt32(txtB.Text) };
            A = Initialize(A);
            B = Initialize(B);
            var result = Mult(A, B);
            txtConsole.AppendText("-- Multiplicação finalizada --" + "\n" + Environment.NewLine);
            txtConsole.AppendText("Resultado: " + result.value[1] + "\n" + Environment.NewLine);
        }
    }
}
