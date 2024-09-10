using System;
using System.Windows.Forms;

namespace Bilheteria1
{
    public partial class Form1 : Form
    {
        private CheckBox[] poltrona;
        private Button btnOcupacao;
        private Button btnDesocupar;
        private Label lblOcupacao;

        public Form1()
        {
            InitializeComponent();
            InitializeMyComponents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeMyComponents()
        {
            poltrona = new CheckBox[30 * 20];

            for (int col = 0; col < 30; col++)
            {
                for (int lin = 0; lin < 20; lin++)
                {
                    int index = col * 20 + lin;
                    poltrona[index] = new CheckBox();
                    poltrona[index].Parent = this;
                    poltrona[index].Checked = false;
                    poltrona[index].Top = 15 * (lin + 1);
                    poltrona[index].Left = 15 * (col + 1);
                    poltrona[index].Width = 10;
                    poltrona[index].Height = 10;
                }
            }

            btnOcupacao = new Button();
            btnOcupacao.Parent = this;
            btnOcupacao.Left = 250;
            btnOcupacao.Top = 340;
            btnOcupacao.Text = "Ver Ocupação";
            btnOcupacao.Width = 100;
            btnOcupacao.Click += new EventHandler(ocupar);

            btnDesocupar = new Button();
            btnDesocupar.Parent = this;
            btnDesocupar.Left = 350;
            btnDesocupar.Top = 340;
            btnDesocupar.Text = "Desocupar tudo";
            btnDesocupar.Width = 100;
            btnDesocupar.Click += new EventHandler(desocupar);

            lblOcupacao = new Label();
            lblOcupacao.Parent = this;
            lblOcupacao.Left = 310;
            lblOcupacao.Top = 370;
            lblOcupacao.Text = "Ocupação: 0%";
        }

        private void ocupar(object sender, EventArgs e)
        {
            int total = poltrona.Length;
            int ocupado = 0;

            foreach (CheckBox cb in poltrona)
            {
                if (cb.Checked)
                {
                    ocupado++;
                }
            }

            double percentual = (ocupado / (double)total) * 100;

            lblOcupacao.Text = $"Ocupação: {percentual:F2}%";
        }

        private void desocupar(object sender, EventArgs e)
        {
            foreach (CheckBox cb in poltrona)
            {
                cb.Checked = false;
            }

            lblOcupacao.Text = "Ocupação: 0%";
        }
    }
}
