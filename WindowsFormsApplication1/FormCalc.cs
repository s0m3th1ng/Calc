using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormCalc : Form
    {
        private double _firstValue = 0, _secondValue = 0;   //Values of calculation
        private bool _operationChosen = false;   //button of operation clicked (if true: button of operation was clicked)
        private bool _containsDot = false; //number at the screen contains dot
        private int _operationNumber;   //operations by TabIndex: 12 - "+", 13 - "-", 14 - "*", 15 - "/"
        private const int OperationSum = 12, OperationSub = 13, OperationMul = 14, OperationDiv = 15;
        private bool _isInfinity = false;   //screen displays "Infinity" (ban of using keyboard until reset)
        
        public FormCalc()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(FormCalc_KeyPress);
        }

        private void button_Click(object sender, EventArgs e)   //numbers & operations buttons click handler (use for buttons only)
        {
            if (sender.GetType() == typeof(Button))
            {
                labelError.Text = "";
                if ((((Button) sender).TabIndex >= 1) && (((Button) sender).TabIndex <= 10))   //Handling numbers click
                {
                    HandleNumberClick(((Button) sender).TabIndex - 1);
                } else   //Handling operations click
                {
                    HandleOperationClick(((Button) sender).TabIndex);
                }
            }
            else
            {
                labelError.Text = "Impossible method call (method: " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            }
        }
        
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (labelValue.Text.Length == 0)
            {
                labelError.Text = "Enter value";
            }
            else if (_operationChosen)
            {
                _secondValue = double.Parse(labelValue.Text);
                _firstValue = Calculate(_firstValue, _secondValue);
                if (!labelValue.Text.Equals("Infinity"))
                {
                    labelValue.Text = _firstValue.ToString();
                }
                _operationChosen = false;
                _operationNumber = 0;
                _containsDot = labelValue.Text.Contains(".");
            }
        }

        private void HandleNumberClick(int number)
        {
            labelValue.Text += number.ToString();
        }

        private void HandleOperationClick(int operationNumber)
        {
            _containsDot = false;
            if (labelValue.Text.Length == 0)
            {
                labelError.Text = "Enter value";   //TODO: remove after adding labelLastCalculation
            }
            else
            {
                if (_operationChosen)
                {
                    _firstValue = Calculate(_firstValue, double.Parse(labelValue.Text));
                }
                else
                {
                    _operationChosen = true;
                    _firstValue = double.Parse(labelValue.Text);
                }
                if (!labelValue.Text.Equals("Infinity"))
                {
                    labelValue.Text = "";
                }
            }
            _operationNumber = operationNumber;
        }

        private double Calculate(double value1, double value2)
        {
            switch (_operationNumber)
            {
                case OperationDiv:
                    if (value2 == 0)
                    {
                        labelValue.Text = "Infinity";
                        foreach (Control c in this.Controls)
                        {
                            if (c.TabIndex < 16)
                            {
                                c.Enabled = false;
                            }
                        }

                        _isInfinity = true;
                    }
                    else
                    {
                        value1 /= value2;
                    }

                    break;
                case OperationMul:
                    value1 *= value2;
                    break;
                case OperationSum:
                    value1 += value2;
                    break;
                case OperationSub:
                    value1 -= value2;
                    break;
            }

            return value1;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if ((labelValue.Text.Length > 0) && (!_containsDot))
            {
                labelValue.Text += ",";
                _containsDot = true;
            }
        }
        
        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelError.Text = "";
            _operationChosen = false;
            _containsDot = false;
            _isInfinity = false;
            labelValue.Text = "";
            _firstValue = 0;
            _secondValue = 0;
            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
        }
        
        void FormCalc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_isInfinity && (e.KeyChar >= 48 && e.KeyChar <= 57))   //48-57 - codes of chars '0'-'9'
            {
                labelValue.Text += (char)e.KeyChar;
            }
        }

        private void FormCalc_Load(object sender, EventArgs e)
        {
            
        }
    }
}
