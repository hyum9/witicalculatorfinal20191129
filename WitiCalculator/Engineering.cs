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
    public partial class Engineering : Form
    {
        public Engineering()
        {
            InitializeComponent();
            WITI_LSH_gv_resultLabel.Text = null;
            WITI_LSH_gv_processLabel.Text = null;
        }

        public enum Operators { NULL = 0, PLUS, MINUS, MULTI, DIVISION, ETC, XsquareY}
        private String WITI_LSH_gv_Num = "";
        private String WITI_LSH_gv_Num2 = "0";                  //Exp를 계산하기 위해 만든 변수
        private string WITI_LSH_gv_Num3 = "";
        private String WITI_LSH_gv_processNum = "";             // processLabel에 띄워줄 연산과정을 저장
        private bool WITI_LSH_gv_isOperater = true;             // true이면 연산자들을 누르기 전 false이면 한번 누른상태
        private bool WITI_LSH_gv_isNumber = true;               // true이면 숫자들을 누르기 전 false이면 한번이상 누른상태
        private bool WITI_LSH_gv_isEqual = true;                // true이면 =을 누르기 전 false이면 =을 누른상태
        private bool WITI_LSH_gv_isExp = true;                  // true이면 Exp를 누르기 전 false이면 Exp를 누른상태
        private bool WITI_LSH_gv_isXsquareY = true;         // true이면 XsquareY를 누르기 전 false이면 XsquareY를 누른 상태
        private Operators WITI_LSH_gv_Operator = Operators.NULL;            // 무슨연산자가 클릭 되었는지를 확인하는 변수
        private Operators WITI_LSH_gv_previousOperator = Operators.NULL;    // 이전에 무슨연산자가 클릭 되었는지를 확인하는 변수

        private void Button_Click(object sender, EventArgs e)
        {
            Button WITI_LSH_Iv_selectButton = (Button)sender;
            switch (WITI_LSH_Iv_selectButton.Name)
            {
                case "WITI_LSH_gv_buttonNumber0":           //0
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber1":           //1
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber2":           //2
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber3":           //3
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber4":           //4
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber5":           //5
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber6":           //6
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber7":           //7
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber8":           //8
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_buttonNumber9":           //9
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_ClearButton":             //C
                    WITI_LSH_Reset();
                    break;
                case "WITI_LSH_gv_DeleteButton":           //지우기
                    if (WITI_KSM_Api.WITI_KSM_Length(WITI_LSH_gv_resultLabel.Text) == 0)
                    {
                        return;
                    }
                    WITI_LSH_gv_resultLabel.Text =
                        WITI_KSM_Api.WITI_KSM_Substring(WITI_LSH_gv_resultLabel.Text, 0, WITI_KSM_Api.WITI_KSM_Length(WITI_LSH_gv_resultLabel.Text) - 1);
                    break;
                case "WITI_LSH_gv_CEButton":                //CE
                    WITI_LSH_gv_resultLabel.Text = "";
                    break;
                case "WITI_LSH_gv_divisionButton":          ///
                    WITI_LSH_gv_Operator = Operators.DIVISION;
                    OperatorMethod(WITI_LSH_Iv_selectButton.Text);
                    WITI_LSH_gv_previousOperator = Operators.DIVISION;
                    break;
                case "WITI_LSH_gv_multiButton":             //*
                    WITI_LSH_gv_Operator = Operators.MULTI;
                    OperatorMethod(WITI_LSH_Iv_selectButton.Text);
                    WITI_LSH_gv_previousOperator = Operators.MULTI;
                    break;
                case "WITI_LSH_gv_minusButton":             //-
                    WITI_LSH_gv_Operator = Operators.MINUS;
                    OperatorMethod(WITI_LSH_Iv_selectButton.Text);
                    WITI_LSH_gv_previousOperator = Operators.MINUS;
                    break;
                case "WITI_LSH_gv_plusButton":              //+
                    WITI_LSH_gv_Operator = Operators.PLUS;
                    OperatorMethod(WITI_LSH_Iv_selectButton.Text);
                    WITI_LSH_gv_previousOperator = Operators.PLUS;
                    break;
                case "WITI_LSH_GV_etcButton":               //%
                    WITI_LSH_gv_Operator = Operators.ETC;
                    OperatorMethod(WITI_LSH_Iv_selectButton.Text);
                    WITI_LSH_gv_previousOperator = Operators.ETC;
                    break;
                case "WITI_LSH_gv_resultButton":            //=
                    OperatorMethod(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_PMButton":                //+/-
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_StandardCalculation.WITI_KSM_notMethod(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_sinButton":               //sin
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.WITI_KSM_Sin(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_cosButton":               //cos
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.WITI_KSM_Cos(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_tanButton":                //tan
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.WITI_KSM_Tan(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_ExpButton":               //Exp
                    WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                    WITI_LSH_gv_resultLabel.Text = WITI_LSH_gv_Num + ".e + "+ WITI_LSH_gv_Num2;
                    WITI_LSH_gv_isExp = false;
                    break;
                case "WITI_LSH_gv_XsquareYButton":
                    WITI_LSH_gv_Num3 = WITI_LSH_gv_resultLabel.Text;
                    WITI_LSH_gv_processLabel.Text = WITI_LSH_gv_Num3 + "^";
                    WITI_LSH_gv_resultLabel.Text = "";
                    WITI_LSH_gv_isXsquareY = false;
                    break;
                case "WITI_LSH_gv_10squareButton":          //10square
                    WITI_LSH_gv_processLabel.Text += "10^" + "(" + WITI_LSH_gv_resultLabel.Text + ")";
                    WITI_LSH_gv_resultLabel.Text = WITI_LSH_EngineeringCalculation.WITI_LSH_10squareMethod(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_dotButton":               //.
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
                case "WITI_LSH_gv_logButton":               //log
                    WITI_LSH_gv_resultLabel.Text = (WITI_KSM_Api.WITI_KSM_Log(WITI_LSH_gv_resultLabel.Text));
                    break;


                //case "WITI_LSH_gv_ModButton":               //Mod
                //    SetNum(WITI_LSH_Iv_selectButton.Text);
                //    break;
                
                case "WITI_LSH_gv_piButton":                //pi
                    
                    WITI_LSH_gv_isOperater = false;
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.getPI();
                    WITI_LSH_gv_isNumber = false;
                    break;
                case "WITI_LSH_gv_2ndButton":               //2nd
                    SetNum(WITI_LSH_Iv_selectButton.Text);
                    break;
               case "WITI_LSH_gv_rootButton":              //root
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.WITI_KSM_Sqrt(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_SquareButton":           //square
                    WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text = WITI_KSM_StandardCalculation.WITI_KSM_SquareMethod(WITI_LSH_gv_resultLabel.Text);
                    break;
                case "WITI_LSH_gv_factorialButton":
                    WITI_LSH_gv_processLabel.Text +="fact("+WITI_LSH_gv_resultLabel.Text+")";
                    WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.WITI_KSM_Fact(WITI_LSH_gv_resultLabel.Text);
                    break;
            }
        }
        private void SetNum(string WITI_LSH_Iv_numberText)
        {

            WITI_LSH_gv_isNumber = false;

          /*  if (WITI_LSH_gv_isExp == false)
            {
                if(WITI_LSH_gv_Num2 == "0")
                {
                    WITI_LSH_gv_Num2 = WITI_LSH_Iv_numberText;
                    WITI_LSH_gv_resultLabel.Text = WITI_LSH_gv_Num + ".e + " + WITI_LSH_gv_Num2;
                    return;
                }
                WITI_LSH_gv_Num2 += WITI_LSH_Iv_numberText;
                WITI_LSH_gv_resultLabel.Text = WITI_LSH_gv_Num + ".e + " + WITI_LSH_gv_Num2;

                return;
            }*/

            if (WITI_LSH_gv_isEqual == false)
            {
                WITI_LSH_gv_resultLabel.Text = "";
                WITI_LSH_gv_Num = "";
                WITI_LSH_gv_isEqual = true;
            }

            if(WITI_LSH_gv_isOperater == false)
            {
                WITI_LSH_gv_resultLabel.Text = "";
                WITI_LSH_gv_isOperater = true;
            }

            if(WITI_LSH_gv_resultLabel.Text == "0")
            {
                if(WITI_LSH_gv_resultLabel.Text == "0" && WITI_LSH_Iv_numberText == ".")
                {
                    WITI_LSH_gv_resultLabel.Text = "0.";
                }
                else
                {
                    WITI_LSH_gv_resultLabel.Text = WITI_LSH_Iv_numberText;
                }
            }
            else
            {
                if (WITI_KSM_Api.WITI_KSM_Contains(WITI_LSH_gv_resultLabel.Text, ".") && WITI_LSH_Iv_numberText == ".")
                {
                    return;
                }
                else
                {
                    WITI_LSH_gv_resultLabel.Text += WITI_LSH_Iv_numberText;
                }
            }
        }

        private void OperatorMethod(string WITI_LSH_Iv_numberText)
        {
            if(WITI_LSH_gv_isXsquareY == false)
            {
                WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text = 
                    (Convert.ToString(Math.Pow(Convert.ToDouble(WITI_LSH_gv_Num3), Convert.ToDouble(WITI_LSH_gv_resultLabel.Text))));
                WITI_LSH_gv_isXsquareY = true;
                WITI_LSH_gv_isOperater = false;
                WITI_LSH_gv_processNum = WITI_LSH_gv_processLabel.Text = "";
                WITI_LSH_gv_isEqual = true;
                WITI_LSH_gv_isNumber = true;
                return;
            }

            if (WITI_LSH_gv_isEqual == false)
            {
                WITI_LSH_gv_isEqual = true;
            }

            if (WITI_LSH_gv_isNumber == true)
            {
                WITI_LSH_gv_processLabel.Text = WITI_LSH_gv_resultLabel.Text + " " + WITI_LSH_Iv_numberText + " ";
                return;
            }
            else
            {
                switch (WITI_LSH_Iv_numberText)
                {
                    case "+":
                        WITI_LSH_gv_processNum += WITI_LSH_gv_resultLabel.Text + " + ";
                        WITI_LSH_AdditionalOperation(WITI_LSH_Iv_numberText);
                        WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                        WITI_LSH_gv_isOperater = false;
                        break;
                    case "-":
                        WITI_LSH_gv_processNum += WITI_LSH_gv_resultLabel.Text + " - ";
                        WITI_LSH_AdditionalOperation(WITI_LSH_Iv_numberText);
                        WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                        WITI_LSH_gv_isOperater = false;
                        break;
                    case "*":
                        WITI_LSH_gv_processNum += WITI_LSH_gv_resultLabel.Text + " * ";
                        WITI_LSH_AdditionalOperation(WITI_LSH_Iv_numberText);
                        WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                        WITI_LSH_gv_isOperater = false;
                        break;
                    case "/":
                        WITI_LSH_gv_processNum += WITI_LSH_gv_resultLabel.Text + " / ";
                        WITI_LSH_AdditionalOperation(WITI_LSH_Iv_numberText);
                        WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                        WITI_LSH_gv_isOperater = false;
                        break;
                    case "%":
                        WITI_LSH_gv_processNum += WITI_LSH_gv_resultLabel.Text + " % ";
                        WITI_LSH_AdditionalOperation(WITI_LSH_Iv_numberText);
                        WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                        WITI_LSH_gv_isOperater = false;
                        break;
/*                    case "^":
                        WITI_LSH_gv_processNum += WITI_LSH_gv_resultLabel.Text + " ^ ";
                        WITI_LSH_AdditionalOperation(WITI_LSH_Iv_numberText);
                        WITI_LSH_gv_Num3 = WITI_LSH_gv_resultLabel.Text;
                        WITI_LSH_gv_isOperater = false;
                        break;*/
                    case "=":
                        WITI_LSH_EqualMethod();
                        break;
                }
            }
            WITI_LSH_gv_isNumber = true;
            WITI_LSH_gv_processLabel.Text = WITI_LSH_gv_processNum;

/*            if (WITI_LSH_gv_isXsquareY == false)
            {
                double result = Math.Pow(WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_LSH_gv_Num), WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_LSH_gv_Num3));
                WITI_LSH_gv_resultLabel.Text = WITI_KSM_Api.WITI_KSM_Convert_ToString(result);
                WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
                WITI_LSH_gv_Num3 = "";
                WITI_LSH_gv_isXsquareY = true;
            }*/

        }

        private void WITI_LSH_EqualMethod()
        {
            switch (WITI_LSH_gv_Operator)
            {
                case Operators.PLUS:
                    WITI_LSH_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_PlusMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                    break;
                case Operators.MINUS:
                    WITI_LSH_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_MinusMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                    break;
                case Operators.MULTI:
                    WITI_LSH_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_MultiMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                    break;
                case Operators.DIVISION:
                    WITI_LSH_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                    break;
                case Operators.ETC:
                    WITI_LSH_gv_resultLabel.Text =
                        WITI_KSM_StandardCalculation.WITI_KSM_EtcMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                    break;
            }

            WITI_LSH_gv_isOperater = false;
            WITI_LSH_gv_Num = WITI_LSH_gv_resultLabel.Text;
            WITI_LSH_gv_processNum = "";
            WITI_LSH_gv_isEqual = true;
            WITI_LSH_gv_isNumber = true;
        }

        private void WITI_LSH_AdditionalOperation(string WITI_LSH_Iv_numberText)
        {
            if (WITI_LSH_gv_previousOperator == Operators.NULL)
            {
                switch (WITI_LSH_Iv_numberText)
                {
                    case "+":
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_PlusMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case "-":
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MinusMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case "*":
                        WITI_LSH_gv_Num = "1";
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MultiMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case "/":
                        WITI_LSH_gv_Num = (WITI_KSM_StandardCalculation.WITI_KSM_SquareMethod(WITI_LSH_gv_resultLabel.Text));
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case "%":
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_EtcMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                }
            }
            else
            {
                switch (WITI_LSH_gv_previousOperator)
                {
                    case Operators.PLUS:
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_PlusMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case Operators.MINUS:
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MinusMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case Operators.MULTI:
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_MultiMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case Operators.DIVISION:
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_DivisionMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                    case Operators.ETC:
                        WITI_LSH_gv_resultLabel.Text =
                            WITI_KSM_StandardCalculation.WITI_KSM_EtcMethod(WITI_LSH_gv_Num, WITI_LSH_gv_resultLabel.Text);
                        break;
                }
            } 
        }

        private void WITI_LSH_Reset()
        {
            WITI_LSH_gv_resultLabel.Text = "";
            WITI_LSH_gv_processLabel.Text = "";
            WITI_LSH_gv_Num = "";
            WITI_LSH_gv_processNum = "";
            WITI_LSH_gv_isOperater = true;
            WITI_LSH_gv_isNumber = true;
            WITI_LSH_gv_Operator = Operators.NULL;
            WITI_LSH_gv_previousOperator = Operators.NULL;
            WITI_LSH_gv_isEqual = true;
        }

        private void WITI_KSM_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Standard standardView = new Standard();
            Programmer programmerView = new Programmer();
            switch (item.Name)
            {
                case "WITI_LSH_StandardMenuButton":
                    this.Hide();
                    standardView.ShowDialog();
                    this.Close();
                    break;
                case "WITI_LSH_MenuItemEngin":
                    // this는 Engineering이므로 필요없음
                    break;
                case "WITI_LSH_programmerMenuButton":
                    this.Hide();
                    programmerView.ShowDialog();
                    this.Close();
                    break;
            }

        }
    }
}
