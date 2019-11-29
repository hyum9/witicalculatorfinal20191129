using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WitiCalculator
{
    public partial class Standard : Form
    {
        public enum Operators { NULL = 0, PLUS, MINUS, MULTI, DIVISION, ETC}  // 더하기, 빼기, 곱하기, 나누기(몫), 나누기(나머지)

        private string WITI_KSM_gv_number = "";                // ResultLabel에서 수를 저장
        private string WITI_KSM_gv_processLabelNumber = "";     // processLabel에 띄워줄 연산과정을 저장
        private bool WITI_KSM_gv_isOperator = true;             // true이면 연산자들을 누르기전 false이면 한번 누른상태
        private bool WITI_KSM_gv_isNumber = true;               // true이면 숫자들을 누르기전 false이면 한번이상 누른상태
        private bool WITI_KSM_gv_isEqual = true;                // true이면 =을 누르기전 false이면 =을 누른상태
        private Operators WITI_KSM_gv_Operator = Operators.NULL;            // 무슨연산자가 클릭되었는지를 확인하는 변수
        private Operators WITI_KSM_gv_previousOperator = Operators.NULL;    // 이전에 무슨연산자가 클릭되었는지를 확인하는 변수

        public Standard()
        {
            InitializeComponent();
            WITI_KSM_gv_resultLabel.Text = null;
            WITI_KSM_gv_processLabel.Text = null;
        }

        private void ButtonNumbers_Click(object sender, EventArgs e)
        {
            Button WITI_KSM_lv_selectButton = (Button)sender;

            switch (WITI_KSM_lv_selectButton.Name)
            {
                case "WITI_KSM_gv_buttonNumber0":         // 0
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber1":         // 1
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber2":         // 2
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber3":         // 3
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber4":         // 4
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber5":         // 5
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber6":         // 6
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber7":         // 7
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber8":         // 8
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_buttonNumber9":         // 9
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_notButton":             // Not
                    WITI_KSM_gv_resultLabel.Text = WITI_KSM_StandardCalculation.WITI_KSM_notMethod(WITI_KSM_gv_resultLabel.Text);
                    break;
                case "WITI_KSM_gv_dotButton":             // .
                    SetNumber(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_resultButton":          // =
                    OperatorMethod(WITI_KSM_lv_selectButton.Text);
                    break;
                case "WITI_KSM_gv_plusButton":            // +
                    WITI_KSM_gv_Operator = Operators.PLUS;
                    OperatorMethod(WITI_KSM_lv_selectButton.Text);
                    WITI_KSM_gv_previousOperator = Operators.PLUS;
                    break;
                case "WITI_KSM_gv_minusButton":           // -
                    WITI_KSM_gv_Operator = Operators.MINUS;
                    OperatorMethod(WITI_KSM_lv_selectButton.Text);
                    WITI_KSM_gv_previousOperator = Operators.MINUS;
                    break;
                case "WITI_KSM_gv_multiButton":           // *
                    WITI_KSM_gv_Operator = Operators.MULTI;
                    OperatorMethod(WITI_KSM_lv_selectButton.Text);
                    WITI_KSM_gv_previousOperator = Operators.MULTI;
                    break;
                case "WITI_KSM_gv_divisionButton":        // /
                    WITI_KSM_gv_Operator = Operators.DIVISION;
                    OperatorMethod(WITI_KSM_lv_selectButton.Text);
                    WITI_KSM_gv_previousOperator = Operators.DIVISION;
                    break;
                case "WITI_KSM_gv_etcButton":             // %
                    if (WITI_KSM_gv_isEqual == true)
                    {
                        WITI_KSM_gv_resultLabel.Text = WITI_KSM_gv_processLabel.Text = "0";
                        return;
                    }
                    else
                    {
                        WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text = WITI_KSM_gv_processLabel.Text = 
                            WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_gv_resultLabel.Text) * 0.01);
                    }
                    break;
                case "WITI_KSM_gv_squareButton":          // 제곱
                    WITI_KSM_gv_resultLabel.Text = WITI_KSM_StandardCalculation.WITI_KSM_SquareMethod(WITI_KSM_gv_resultLabel.Text);
                    break;
                case "WITI_KSM_gv_CEButton":              // CE
                    WITI_KSM_gv_resultLabel.Text = "";
                    break;
                case "WITI_KSM_gv_clearButton":               // C
                    WITI_KSM_Reset();
                    break;
                case "WITI_KSM_gv_deleteButton":          // 지우기
                    if(WITI_KSM_Api.WITI_KSM_Length(WITI_KSM_gv_resultLabel.Text) == 0)
                    {
                        return;
                    }
                    WITI_KSM_gv_resultLabel.Text = 
                        WITI_KSM_Api.WITI_KSM_Substring(WITI_KSM_gv_resultLabel.Text, 0, WITI_KSM_Api.WITI_KSM_Length(WITI_KSM_gv_resultLabel.Text) - 1);
                    break;
                case "WITI_KSM_gv_1overX":      // x 분의 1
                    WITI_KSM_gv_resultLabel.Text = WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod("1", WITI_KSM_gv_resultLabel.Text);
                    break;
            }
        }

        private void SetNumber(string WITI_KSM_lv_numberText)
        {

            WITI_KSM_gv_isNumber = false;

            if (WITI_KSM_gv_isEqual == false)
            {
                WITI_KSM_gv_resultLabel.Text = "";
                WITI_KSM_gv_number = "";
                WITI_KSM_gv_isEqual = true;
            }

            if (WITI_KSM_gv_isOperator == false)
            {
                WITI_KSM_gv_resultLabel.Text = "";
                WITI_KSM_gv_isOperator = true;
            }

            if (WITI_KSM_gv_resultLabel.Text == "0")
            {
                if (WITI_KSM_gv_resultLabel.Text == "0" && WITI_KSM_lv_numberText == ".")
                {
                    WITI_KSM_gv_resultLabel.Text = "0.";
                }
                else
                {
                    WITI_KSM_gv_resultLabel.Text = WITI_KSM_lv_numberText;
                }                
            }
            else
            {
                if (WITI_KSM_Api.WITI_KSM_Contains(WITI_KSM_gv_resultLabel.Text, ".") && WITI_KSM_lv_numberText == ".")
                {
                    return;
                }
                else
                {
                    WITI_KSM_gv_resultLabel.Text += WITI_KSM_lv_numberText;
                }
            }
        }

        private void OperatorMethod(string WITI_KSM_lv_numberText)
        {

            if (WITI_KSM_gv_isEqual == false)
            {
                WITI_KSM_gv_isEqual = true;
            }

            if (WITI_KSM_gv_isNumber == true)
            {
                WITI_KSM_gv_processLabel.Text = WITI_KSM_gv_resultLabel.Text + " " + WITI_KSM_lv_numberText + " ";
                return;
            }
            else
            {
                switch (WITI_KSM_lv_numberText) {
                    case "+":
                        WITI_KSM_gv_processLabelNumber += WITI_KSM_gv_resultLabel.Text + " + ";
                        WITI_KSM_AdditionalOperation(WITI_KSM_lv_numberText);
                        WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text;
                        WITI_KSM_gv_isOperator = false;
                        break;
                    case "-":
                        WITI_KSM_gv_processLabelNumber += WITI_KSM_gv_resultLabel.Text + " - ";
                        WITI_KSM_AdditionalOperation(WITI_KSM_lv_numberText);
                        WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text;
                        WITI_KSM_gv_isOperator = false;
                        break;
                    case "*":
                        WITI_KSM_gv_processLabelNumber += WITI_KSM_gv_resultLabel.Text + " * ";
                        WITI_KSM_AdditionalOperation(WITI_KSM_lv_numberText);
                        WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text;
                        WITI_KSM_gv_isOperator = false;
                        break;
                    case "/":
                        WITI_KSM_gv_processLabelNumber += WITI_KSM_gv_resultLabel.Text + " / ";
                        WITI_KSM_AdditionalOperation(WITI_KSM_lv_numberText);
                        WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text;
                        WITI_KSM_gv_isOperator = false;
                        break;
                    case "%":
                        WITI_KSM_gv_processLabelNumber += WITI_KSM_gv_resultLabel.Text + " % ";
                        WITI_KSM_AdditionalOperation(WITI_KSM_lv_numberText);
                        WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text;
                        WITI_KSM_gv_isOperator = false;
                        break;
                    case "=":
                        WITI_KSM_EqualMethod();
                        break;
                }
                WITI_KSM_gv_isNumber = true;
                WITI_KSM_gv_processLabel.Text = WITI_KSM_gv_processLabelNumber;
            }

        }

        private void WITI_KSM_EqualMethod()
        {
            if (WITI_KSM_gv_isOperator == true)
            {
                
            }

            switch (WITI_KSM_gv_Operator)
            {
                case Operators.PLUS:    // 더하기
                    WITI_KSM_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_PlusMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                    break;
                case Operators.MINUS:   // 빼기
                    WITI_KSM_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_MinusMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                    break;
                case Operators.MULTI:   // 곱하기
                    WITI_KSM_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_MultiMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                    break;
                case Operators.DIVISION:    // 나누기(몫)
                    WITI_KSM_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                    break;
                case Operators.ETC:         // 나누기(나머지)
                    WITI_KSM_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_EtcMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                    break;
            }
            WITI_KSM_gv_isOperator = false;
            WITI_KSM_gv_number = WITI_KSM_gv_resultLabel.Text;
            WITI_KSM_gv_processLabelNumber = "";
            WITI_KSM_gv_isEqual = false;
            WITI_KSM_gv_isNumber = false;
            
        }

        private void WITI_KSM_AdditionalOperation(string WITI_KSM_lv_numberText)
        {
            if (WITI_KSM_gv_previousOperator == Operators.NULL)
            {
                switch (WITI_KSM_lv_numberText)
                {
                    case "+":
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_PlusMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case "-":
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MinusMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case "*":
                        WITI_KSM_gv_number = "1";
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MultiMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case "/":
                        WITI_KSM_gv_number = (WITI_KSM_StandardCalculation.WITI_KSM_SquareMethod(WITI_KSM_gv_resultLabel.Text));
                        WITI_KSM_gv_resultLabel.Text =
                                WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case "%":
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_EtcMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                }
            }
            else
            {
                switch (WITI_KSM_gv_previousOperator)
                {
                    case Operators.PLUS:
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_PlusMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case Operators.MINUS:
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MinusMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case Operators.MULTI:
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MultiMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case Operators.DIVISION:
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                    case Operators.ETC:
                        WITI_KSM_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_EtcMethod(WITI_KSM_gv_number, WITI_KSM_gv_resultLabel.Text);
                        break;
                }
            }
        }


        private void WITI_KSM_Reset()
        {
            WITI_KSM_gv_resultLabel.Text = "";
            WITI_KSM_gv_processLabel.Text = "";
            WITI_KSM_gv_number = "";
            WITI_KSM_gv_processLabelNumber = "";
            WITI_KSM_gv_isOperator = true;
            WITI_KSM_gv_isNumber = true;
            WITI_KSM_gv_Operator = Operators.NULL;
            WITI_KSM_gv_previousOperator = Operators.NULL;
            WITI_KSM_gv_isEqual = true;
        }

        private void WITI_KSM_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Engineering engineeringView = new Engineering();
            Programmer programmerView = new Programmer();
            switch (item.Name)
            {
                case "WITI_KSM_StandardMenuButton":
                    // this는 Standard이므로 필요없음
                    break;
                case "WITI_KSM_EngineeringMenuButton":
                    this.Hide();
                    engineeringView.ShowDialog();
                    this.Close();
                    break;
                case "WITI_KSM_programmerMenuButton":
                    this.Hide();
                    programmerView.ShowDialog();
                    this.Close();
                    break;
            }
        }
    }
}
