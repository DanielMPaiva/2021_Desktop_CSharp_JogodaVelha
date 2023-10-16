using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JogodaVelha
{
    public partial class Form1 : Form
    {
        public bool podejogar = true;
        //public char p1;
        public int jogos = 0;
        public int p1 = 0;
        public int p2 = 0;
        public int p3 = 0;
        public int p4 = 0;
        public int p5 = 0;
        public int p6 = 0;
        public int p7 = 0;
        public int p8 = 0;
        public int p9 = 0;
        public int posicoesdisponiveis = 0;
        public int jogada = 0;
        public string ondejogar = "";
        public string dequemeavez = "usuario";
        public string primerajogadadamaquina = "sim";

        public Form1()
        {
            InitializeComponent();
            limpar();

            if (!Directory.Exists("c:/temp"))
            { Directory.CreateDirectory("c:/temp"); }

            if (!File.Exists("c:/temp/jogodavelhalog.txt"))
            { File.Create("c:/temp/jogodavelhalog.txt"); }

            label1.Text = jogos.ToString();
            limpar();
        }

        private void checkwin()
        {
            if (
                (button1.Text == "X" && button2.Text == "X" && button3.Text == "X") ||
                (button4.Text == "X" && button5.Text == "X" && button6.Text == "X") ||
                (button7.Text == "X" && button8.Text == "X" && button9.Text == "X") ||

                (button1.Text == "X" && button4.Text == "X" && button7.Text == "X") ||
                (button2.Text == "X" && button5.Text == "X" && button8.Text == "X") ||
                (button3.Text == "X" && button6.Text == "X" && button9.Text == "X") ||

                (button1.Text == "X" && button5.Text == "X" && button9.Text == "X") ||
                (button3.Text == "X" && button5.Text == "X" && button7.Text == "X") 
                )
            {
                MessageBox.Show("Você venceu! Parabéns!");
                limpar();            
            }
            else if (
                (button1.Text == "O" && button2.Text == "O" && button3.Text == "O") ||
                (button4.Text == "O" && button5.Text == "O" && button6.Text == "O") ||
                (button7.Text == "O" && button8.Text == "O" && button9.Text == "O") ||

                (button1.Text == "O" && button4.Text == "O" && button7.Text == "O") ||
                (button2.Text == "O" && button5.Text == "O" && button8.Text == "O") ||
                (button3.Text == "O" && button6.Text == "O" && button9.Text == "O") ||

                (button1.Text == "O" && button5.Text == "O" && button9.Text == "O") ||
                (button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
                )
            {
                MessageBox.Show("Você Perdeu...Tente novamente");
                limpar();
            }
            else if(
                    button1.Text != "" &&
                    button2.Text != "" &&
                    button3.Text != "" &&
                    button4.Text != "" &&
                    button5.Text != "" &&
                    button6.Text != "" &&
                    button7.Text != "" &&
                    button8.Text != ""&&
                    button9.Text != ""
                )
            {
                    MessageBox.Show("Deu VELHA!...Tente novamente");
                    limpar();
            }
            else
            {
                if(dequemeavez=="maquina"){vezdamaquina();}
            }
        }

        private void atualizamapa()
        {
            map1.Text = p1.ToString();
            map2.Text = p2.ToString();
            map3.Text = p3.ToString();
            map4.Text = p4.ToString();
            map5.Text = p5.ToString();
            map6.Text = p6.ToString();
            map7.Text = p7.ToString();
            map8.Text = p8.ToString();
            map9.Text = p9.ToString();
        }

        public void zeraposicoes()
        {
            p1 = 0;
            p2 = 0;
            p3 = 0;
            p4 = 0;
            p5 = 0;
            p6 = 0;
            p7 = 0;
            p8 = 0;
            p9 = 0;
            jogada = 0;
            atualizamapa();
        }

        private void vezdamaquina()
        {
            zeraposicoes();

            //mapear posições disponíveis
            //+1 POR LUGAR VAGO
            if (button1.Text == "") { p1 = 1; }
            if (button2.Text == "") { p2 = 1; }
            if (button3.Text == "") { p3 = 1; }
            if (button4.Text == "") { p4 = 1; }
            if (button5.Text == "") { p5 = 1; }
            if (button6.Text == "") { p6 = 1; }
            if (button7.Text == "") { p7 = 1; }
            if (button8.Text == "") { p8 = 1; }
            if (button9.Text == "") { p9 = 1; }


            //=========================   DEFININDO OPÇÕES PRA JOGAR
            //+1 ONDE JA ESTIVER "O"
            //+1 NAS POSIÇÕES DE VITORIA
            //+1 NAS POSIÇÕES DE VITORIA COM AS 2 RESTANTES VAZIAS
            if (button1.Text == "O")
            {
                p1++;
                if (p2 > 0) { p2++; }
                if (p3 > 0) { p3++; }
                if (p5 > 0) { p5++; }
                if (p9 > 0) { p9++; }
                if (p4 > 0) { p4++; }
                if (p7 > 0) { p7++; }

                if (p2 > 0 && p3 > 0) { p2++; p3++; }
                if (p5 > 0 && p9 > 0) { p5++; p9++; }
                if (p4 > 0 && p7 > 0) { p4++; p7++; }
            }

            if (button2.Text == "O")
            {
                p2++;
                if (p1 > 0) { p1++; }
                if (p3 > 0) { p3++; }
                if (p5 > 0) { p5++; }
                if (p8 > 0) { p8++; }

                if (p1 > 0 && p3 > 0) { p1++; p3++; }
                if (p5 > 0 && p8 > 0) { p5++; p8++; }

            }

            if (button3.Text == "O")
            {
                p3++;
                if (p2 > 0) { p2++; }
                if (p1 > 0) { p1++; }
                if (p5 > 0) { p5++; }
                if (p7 > 0) { p7++; }
                if (p6 > 0) { p6++; }
                if (p9 > 0) { p9++; }

                if (p2 > 0 && p1 > 0) { p2++; p1++; }
                if (p5 > 0 && p7 > 0) { p5++; p7++; }
                if (p6 > 0 && p9 > 0) { p6++; p9++; }
            }

            if (button4.Text == "O")
            {
                p4++;
                if (p1 > 0) { p1++; }
                if (p7 > 0) { p7++; }
                if (p5 > 0) { p5++; }
                if (p6 > 0) { p6++; }

                if (p1 > 0 && p7 > 0) { p1++; p7++; }
                if (p5 > 0 && p6 > 0) { p5++; p6++; }
            }

            if (button5.Text == "O")
            {
                p5++;
                if (p1 > 0) { p1++; }
                if (p2 > 0) { p2++; }
                if (p3 > 0) { p3++; }
                if (p4 > 0) { p4++; }
                if (p6 > 0) { p6++; }
                if (p7 > 0) { p7++; }
                if (p8 > 0) { p8++; }
                if (p9 > 0) { p9++; }

                if (p1 > 0 && p9 > 0) { p1++; p9++; }
                if (p2 > 0 && p8 > 0) { p2++; p8++; }
                if (p3 > 0 && p7 > 0) { p3++; p7++; }
                if (p4 > 0 && p6 > 0) { p4++; p6++; }
            }

            if (button6.Text == "O")
            {
                p6++;
                if (p3 > 0) { p3++; }
                if (p9 > 0) { p9++; }
                if (p4 > 0) { p4++; }
                if (p5 > 0) { p5++; }

                if (p3 > 0 && p9 > 0) { p3++; p9++; }
                if (p4 > 0 && p5 > 0) { p4++; p5++; }
            }

            if (button7.Text == "O")
            {
                p7++;
                if (p1 > 0) { p1++; }
                if (p4 > 0) { p4++; }
                if (p5 > 0) { p5++; }
                if (p3 > 0) { p3++; }
                if (p8 > 0) { p8++; }
                if (p9 > 0) { p9++; }

                if (p1 > 0 && p4 > 0) { p1++; p4++; }
                if (p5 > 0 && p3 > 0) { p5++; p3++; }
                if (p8 > 0 && p9 > 0) { p8++; p9++; }
            }

            if (button8.Text == "O")
            {
                p8++;
                if (p7 > 0) { p7++; }
                if (p9 > 0) { p9++; }
                if (p5 > 0) { p5++; }
                if (p2 > 0) { p2++; }

                if (p7 > 0 && p9 > 0) { p7++; p9++; }
                if (p5 > 0 && p2 > 0) { p5++; p2++; }
            }

            if (button9.Text == "O")
            {
                p3++;
                if (p8 > 0) { p8++; }
                if (p7 > 0) { p7++; }
                if (p5 > 0) { p5++; }
                if (p1 > 0) { p1++; }
                if (p6 > 0) { p6++; }
                if (p3 > 0) { p3++; }

                if (p8 > 0 && p7 > 0) { p8++; p7++; }
                if (p5 > 0 && p1 > 0) { p5++; p1++; }
                if (p6 > 0 && p3 > 0) { p6++; p3++; }
            }

            //=========================   DEFESA
            //+5 PRA IMPEDIR VITORIA DO JOGADOR
            if ((button2.Text == "X" && button3.Text == "X" && button1.Text == "") ||
                (button9.Text == "X" && button5.Text == "X" && button1.Text == "") ||
                (button7.Text == "X" && button4.Text == "X" && button1.Text == ""))
            { p1 = p1 + 5; }

            if ((button1.Text == "X" && button3.Text == "X" && button2.Text == "") ||
                (button8.Text == "X" && button5.Text == "X" && button2.Text == ""))
            { p2 = p2 + 5; }

            if ((button1.Text == "X" && button2.Text == "X" && button3.Text == "") ||
                (button7.Text == "X" && button5.Text == "X" && button3.Text == "") ||
                (button9.Text == "X" && button6.Text == "X" && button3.Text == ""))
            { p3 = p3 + 5; }

            if ((button1.Text == "X" && button7.Text == "X" && button4.Text == "") ||
                (button5.Text == "X" && button6.Text == "X" && button4.Text == ""))
            { p4 = p4 + 5; }

            if ((button2.Text == "X" && button8.Text == "X" && button5.Text == "") ||
                (button4.Text == "X" && button6.Text == "X" && button5.Text == "") ||
                (button1.Text == "X" && button9.Text == "X" && button5.Text == "") ||
                (button3.Text == "X" && button7.Text == "X" && button5.Text == ""))
            { p5 = p5 + 5; }

            if ((button3.Text == "X" && button9.Text == "X" && button6.Text == "") ||
                (button4.Text == "X" && button5.Text == "X" && button6.Text == ""))
            { p6 = p6 + 5; }

            if ((button1.Text == "X" && button4.Text == "X" && button7.Text == "") ||
                (button5.Text == "X" && button3.Text == "X" && button7.Text == "") ||
                (button8.Text == "X" && button9.Text == "X" && button7.Text == ""))
            { p7 = p7 + 5; }

            if ((button2.Text == "X" && button5.Text == "X" && button8.Text == "") ||
                (button7.Text == "X" && button9.Text == "X" && button8.Text == ""))
            { p8 = p8 + 5; }

            if ((button3.Text == "X" && button6.Text == "X" && button9.Text == "") ||
                (button1.Text == "X" && button5.Text == "X" && button9.Text == "") ||
                (button7.Text == "X" && button8.Text == "X" && button9.Text == ""))
            { p9 = p9 + 5; }

            //=========================   ATAQUE
            //+6 SE PRA CASO HAJA ESCOLHA ENTRE ATACAR E DEFENDER
            if ((button2.Text == "O" && button3.Text == "O" && button1.Text == "") ||
                (button9.Text == "O" && button5.Text == "O" && button1.Text == "") ||
                (button7.Text == "O" && button4.Text == "O" && button1.Text == ""))
            { p1 = p1 + 6; }

            if ((button1.Text == "O" && button3.Text == "O" && button2.Text == "") ||
                (button8.Text == "O" && button5.Text == "O" && button2.Text == ""))
            { p2 = p2 + 5; }

            if ((button1.Text == "O" && button2.Text == "O" && button3.Text == "") ||
                (button7.Text == "O" && button5.Text == "O" && button3.Text == "") ||
                (button9.Text == "O" && button6.Text == "O" && button3.Text == ""))
            { p3 = p3 + 5; }

            if ((button1.Text == "O" && button7.Text == "O" && button4.Text == "") ||
                (button5.Text == "O" && button6.Text == "O" && button4.Text == ""))
            { p4 = p4 + 5; }

            if ((button2.Text == "O" && button8.Text == "O" && button5.Text == "") ||
                (button4.Text == "O" && button6.Text == "O" && button5.Text == "") ||
                (button1.Text == "O" && button9.Text == "O" && button5.Text == "") ||
                (button3.Text == "O" && button7.Text == "O" && button5.Text == ""))
            { p5 = p5 + 5; }

            if ((button3.Text == "O" && button9.Text == "O" && button6.Text == "") ||
                (button4.Text == "O" && button5.Text == "O" && button6.Text == ""))
            { p6 = p6 + 5; }

            if ((button1.Text == "O" && button4.Text == "O" && button7.Text == "") ||
                (button5.Text == "O" && button3.Text == "O" && button7.Text == "") ||
                (button8.Text == "O" && button9.Text == "O" && button7.Text == ""))
            { p7 = p7 + 5; }

            if ((button2.Text == "O" && button5.Text == "O" && button8.Text == "") ||
                (button7.Text == "O" && button9.Text == "O" && button8.Text == ""))
            { p8 = p8 + 5; }

            if ((button3.Text == "O" && button6.Text == "O" && button9.Text == "") ||
                (button1.Text == "O" && button5.Text == "O" && button9.Text == "") ||
                (button7.Text == "O" && button8.Text == "O" && button9.Text == ""))
            { p9 = p9 + 5; }

            atualizamapa();

            //=========================   JOGANDO
            // PRIMEIRA JOGADA ALEATÓRIA
            // APÓS É BASEADA NAS MÉTRICAS
            if (primerajogadadamaquina == "sim")
            {
                Random numaleatorio = new Random();
                string numerovalidov = "nao";
                int randNum;
                while(numerovalidov=="nao")
                {
                    randNum = numaleatorio.Next(1,9);
                    //MessageBox.Show(randNum.ToString());
                    if (randNum.ToString() == "1" && button1.Text == "")
                    { 
                        button1.Text = "O"; 
                        richTextBox1.AppendText("O1\n"); 
                        numerovalidov = "sim";
                    }
                    else if (randNum.ToString() == "2" && button2.Text == "")
                    { 
                        button2.Text = "O"; 
                        richTextBox1.AppendText("O2\n"); 
                        numerovalidov = "sim"; 
                    }
                    else if (randNum.ToString() == "3" && button3.Text == "")
                    {
                        button3.Text = "O"; 
                        richTextBox1.AppendText("O3\n"); 
                        numerovalidov = "sim"; 
                    }
                    else if (randNum.ToString() == "4" && button4.Text == "")
                    { 
                        button4.Text = "O"; 
                        richTextBox1.AppendText("O4\n"); 
                        numerovalidov = "sim"; 
                    }
                    else if (randNum.ToString() == "5" && button5.Text == "")
                    {
                        button5.Text = "O";
                        richTextBox1.AppendText("O5\n");
                        numerovalidov = "sim";
                    }
                    else if (randNum.ToString() == "6" && button6.Text == "")
                    {
                        button6.Text = "O";
                        richTextBox1.AppendText("O6\n");
                        numerovalidov = "sim";
                    }
                    else if (randNum.ToString() == "7" && button7.Text == "")
                    {
                        button7.Text = "O";
                        richTextBox1.AppendText("O7\n");
                        numerovalidov = "sim";
                    }
                    else if (randNum.ToString() == "8" && button8.Text == "")
                    {
                        button8.Text = "O";
                        richTextBox1.AppendText("O8\n");
                        numerovalidov = "sim";
                    }
                    else if (randNum.ToString() == "9" && button8.Text == "")
                    {
                        button9.Text = "O";
                        richTextBox1.AppendText("O9\n");
                        numerovalidov = "sim";
                    }
                }
                primerajogadadamaquina = "nao";
            }
            else
            {                
                if (button1.Text == "" && jogada <= p1) { jogada = p1; ondejogar = "1"; }
                if (button2.Text == "" && jogada <= p2) { jogada = p2; ondejogar = "2"; }
                if (button3.Text == "" && jogada <= p3) { jogada = p3; ondejogar = "3"; }
                if (button4.Text == "" && jogada <= p4) { jogada = p4; ondejogar = "4"; }
                if (button5.Text == "" && jogada <= p5) { jogada = p5; ondejogar = "5"; }
                if (button6.Text == "" && jogada <= p6) { jogada = p6; ondejogar = "6"; }
                if (button7.Text == "" && jogada <= p7) { jogada = p7; ondejogar = "7"; }
                if (button8.Text == "" && jogada <= p8) { jogada = p8; ondejogar = "8"; }
                if (button9.Text == "" && jogada <= p9) { jogada = p9; ondejogar = "9"; }

                if (ondejogar == "1") { button1.Text = "O"; richTextBox1.AppendText("O1\n"); }
                if (ondejogar == "2") { button2.Text = "O"; richTextBox1.AppendText("O2\n"); }
                if (ondejogar == "3") { button3.Text = "O"; richTextBox1.AppendText("O3\n"); }
                if (ondejogar == "4") { button4.Text = "O"; richTextBox1.AppendText("O4\n"); }
                if (ondejogar == "5") { button5.Text = "O"; richTextBox1.AppendText("O5\n"); }
                if (ondejogar == "6") { button6.Text = "O"; richTextBox1.AppendText("O6\n"); }
                if (ondejogar == "7") { button7.Text = "O"; richTextBox1.AppendText("O7\n"); }
                if (ondejogar == "8") { button8.Text = "O"; richTextBox1.AppendText("O8\n"); }
                if (ondejogar == "9") { button9.Text = "O"; richTextBox1.AppendText("O9\n"); }
            }

            dequemeavez = "usuario";
            checkwin();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            
                bt.Text = "X";
                podejogar = false;
                richTextBox1.AppendText("X" + bt.Name.Remove(0, 6) + "\n");
                richTextBox1.ScrollToCaret();
                dequemeavez = "maquina"; 
                checkwin();
        }

        private void limpar()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            zeraposicoes();
            richTextBox1.Clear();
            primerajogadadamaquina = "sim";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            limpar();
        }

    }
}
