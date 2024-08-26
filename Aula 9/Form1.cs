namespace Aula_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Exibe o Form2 como uma nova janela
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();


            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form4 form4 = new Form4();


            form4.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form5 form5 = new Form5();


            form5.Show();

        }
    }
}