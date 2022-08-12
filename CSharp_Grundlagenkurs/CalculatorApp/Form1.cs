using CalculationLibrary;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double zahl1;
        private double zahl2;

        private Calculator calculator;
        public Form1()
        {
            InitializeComponent();
            calculator = new();
        }

        private void LeseWerteAusUI()
        {
            zahl1 = double.Parse(textBox1.Text);
            zahl2 = double.Parse(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeseWerteAusUI();
            MessageBox.Show($"{calculator.Addieren(this.zahl1, this.zahl2)}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LeseWerteAusUI();
            MessageBox.Show($"{calculator.Subtrahieren(this.zahl1, this.zahl2)}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeseWerteAusUI();
            MessageBox.Show($"{calculator.Multiplikation(this.zahl1, this.zahl2)}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LeseWerteAusUI();
                MessageBox.Show($"{calculator.Division(this.zahl1, this.zahl2)}");
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show("Lieber Benutzer, dividieren durch 0 ist nicht möglich");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lieber Benutzer, ein unbekannter Fehler ist passiert");
            }

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Hier wird CalculatorException entstehen
                calculator.MethodeAVonAzubi();
            }
            catch (DivByZeroException myEx)
            {
                MessageBox.Show(myEx.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CalculatorException myEx)
            {
                MessageBox.Show(myEx.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Hier wird DivByZeroException entstehen
                calculator.MethodeBVonAzubi();
            }
            catch (DivByZeroException myEx)
            {
                MessageBox.Show(myEx.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CalculatorException myEx)
            {
                MessageBox.Show(myEx.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}