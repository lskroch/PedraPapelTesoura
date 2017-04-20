using PedraPapelTesoura.Controler;
using PedraPapelTesoura.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedraPapelTesoura
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                Start(richTextBox1.Text);
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro "+er.Message);
            }
        }
        private void Start(string torneio_str)
        {
            richTextBox2.Text = "";
            Jogador vencedor = ControlerJogo.StartPartida(ControlerJogo.RpsGameWinner(torneio_str));             
            richTextBox2.Text = "Vencedor = " + vencedor.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string torneio_default = "[\n"
                                        + "\t[\n"
                                        + " \t[[\"Armando\", \"P\"], [\"Dave\", \"S\"]],\n"
                                        + " \t[[\"Richard\", \"R\"], [\"Michael\", \"S\"]],\n"
                                        + " \t],\n"
                                        + " \t[\n"
                                        + " \t[[\"Allen\", \"S\"], [\"Omer\", \"P\"]],\n"
                                        + " \t[[\"David E.\", \"R\"], [\"Richard X.\", \"P\"]]\n"
                                        + " \t]\n"
                                        + "]\n";
            richTextBox1.Text = torneio_default;
            Start(torneio_default);
        }
    }
}
