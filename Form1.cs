using System;
using System.Globalization;
using System.Windows.Forms;

namespace SimpleCalculatorSDA
{
    public partial class Form1 : Form
    {
		/// <summary>
		/// Store the value
		/// </summary>
        private double _accumulator = 0;

		/// <summary>
		/// Store information about last pressed operation button.
		/// </summary>
        private char _lastOperationChar;


		/// <summary>
		/// Default contructor. Windows Forms Api needs that for create the form
		/// </summary>
        public Form1()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Function for handling 'operation' buttons click
		/// </summary>
		/// <param name="sender">Indicate who is calling the function</param>
		/// <param name="e">Additional data for delegate</param>
		private void Operator_Pressed(object sender, EventArgs e)
        {
            char operation = ((Button) sender).Text[0];
            if (operation == 'C')
            {
                _accumulator = 0;
            }
            else
            {
                double currentValue = double.Parse(txtResult.Text);
                switch (_lastOperationChar)
                {
                    case '+': _accumulator += currentValue; break;
                    case '-': _accumulator -= currentValue; break;
                    case '×': _accumulator *= currentValue; break;
                    case '÷': _accumulator /= currentValue; break;
                    default: _accumulator = currentValue; break;
                }
            }

            _lastOperationChar = operation;
            txtResult.Text = operation == '=' ? _accumulator.ToString(CultureInfo.InvariantCulture) : "0";
        }

		/// <summary>
		/// Function for handling 'number' buttons click
		/// </summary>
		/// <param name="sender">Indicate who is calling the function</param>
		/// <param name="e">Additional data for delegate</param>
		private void Number_Pressed(object sender, EventArgs e)
        {
            string number = ((Button) sender).Text;
            txtResult.Text = txtResult.Text == "0" ? number : txtResult.Text + number;
        }

    }
}
