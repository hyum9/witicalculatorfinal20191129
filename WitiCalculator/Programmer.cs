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
    public partial class Programmer : Form
    {
        bool Witi_Y_gv_checkNewNumber = true, Witi_Y_gv_checkNewOperator = false;
        int Witi_Y_gv_numOriginal = 0;
        char Witi_Y_operator = '\0';
        enum Highlight
        {
            DEC,//0
            HEX,//1
            OCT,
            BIN
        }

        Highlight Witi_Y_gv_highlight = Highlight.DEC;


        public Programmer()
        {
            InitializeComponent();
        }
        //Programmer 초기화

        private void Witi_Y_eventBackButton_Click(object sender, EventArgs e)
        {


            Witi_Y_gv_labelNumber.Text = Witi_Y_gv_labelNumber.Text.Remove(Witi_Y_gv_labelNumber.Text.Length - 1);
        }

        private void Witi_Y_eventNumButton_Click(object sender, EventArgs e)
        {
            Button Witi_Y_lv_button = (Button)sender;
            Witi_Y_gv_checkNewOperator = false;
            if (Witi_Y_gv_checkNewNumber)
            {
                Witi_Y_gv_labelNumber.Text = Witi_Y_lv_button.Text;
                Witi_Y_gv_checkNewNumber = false;
            }
            else
            {
                Witi_Y_gv_labelNumber.Text += Witi_Y_lv_button.Text;
            }
            Witi_Y_labelWrite();
        }
        //NumButton Text -> Witi_Y_gv_labelNumber.Text

         private void Witi_Y_eventClearButton_Click(object sender, EventArgs e)
         {
            Button Witi_Y_lv_button = (Button)sender;
            String Witi_Y_lv_buttonText = Witi_Y_lv_button.Text;

            switch(Witi_Y_lv_buttonText)
            {
                case "CE":
                    Witi_Y_gv_labelNumber.Text = "0";
                    Witi_Y_gv_checkNewNumber = true;
                    break;
                case "C":
                    Witi_Y_gv_labelNumber.Text = "0"; Witi_Y_gv_labelExpression.Text = null;
                    Witi_Y_gv_checkNewNumber = true; Witi_Y_gv_checkNewOperator = false;
                    Witi_Y_gv_numOriginal = 0; Witi_Y_operator = '\0';
                    break;
            }
         }

        private void Witi_Y_eventOperatorButton_Click(object sender, EventArgs e)
        {
            Button Witi_Y_lv_button = (Button)sender;
            WitiCalculator.Witi_KSM_Api_original Witi_KSM_lv_ApiInstance = new WitiCalculator.Witi_KSM_Api_original();
            Witi_Y_gv_checkNewNumber = true;

            if (Witi_Y_gv_checkNewOperator == false)
            {
                if(Witi_Y_lv_button.Text[0]!='=')
                {
                    Witi_Y_gv_labelExpression.Text += Witi_Y_gv_labelNumber.Text + Witi_Y_lv_button.Text;
                    if (Witi_Y_operator == '\0')
                    {
                        Witi_Y_gv_numOriginal = Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelNumber.Text);
                        Witi_Y_operator = Witi_Y_lv_button.Text[0];
                    }
                    else
                    {
                        WitiCalculator.Witi_Y_operation Witi_Y_gv_operationInstance = new WitiCalculator.Witi_Y_operation(Witi_Y_gv_numOriginal, Witi_Y_operator, Witi_Y_gv_labelNumber.Text, (int)Witi_Y_gv_highlight);
                        Witi_Y_gv_numOriginal = Witi_Y_gv_operationInstance.Witi_Y_getNum();
                        Witi_Y_operator = Witi_Y_lv_button.Text[0];
                        Witi_Y_gv_labelNumber.Text = Witi_KSM_lv_ApiInstance.WITI_Convert_ToString(Witi_Y_gv_numOriginal, 10);
                        Witi_Y_labelWrite();
                    }
                }
               
                else
                {
                    WitiCalculator.Witi_Y_operation Witi_Y_gv_operationInstance = new WitiCalculator.Witi_Y_operation(Witi_Y_gv_numOriginal, Witi_Y_operator, Witi_Y_gv_labelNumber.Text, (int)Witi_Y_gv_highlight);
                    Witi_Y_gv_numOriginal = Witi_Y_gv_operationInstance.Witi_Y_getNum();
                    Witi_Y_operator = '\0';
                    Witi_Y_gv_labelExpression.Text = null;
                    Witi_Y_gv_labelNumber.Text = Witi_KSM_lv_ApiInstance.WITI_Convert_ToString(Witi_Y_gv_numOriginal, 10);
                    Witi_Y_labelWrite();

                }
                Witi_Y_gv_checkNewOperator = true;
            }

            else if (Witi_Y_gv_checkNewOperator == true)
            {
                Witi_Y_operator = Witi_Y_lv_button.Text[0];
                Witi_Y_gv_labelExpression.Text = Witi_Y_gv_labelExpression.Text.Remove(Witi_Y_gv_labelExpression.Text.Length - 1);
                Witi_Y_gv_labelExpression.Text += Witi_Y_lv_button.Text[0];
            }

        }
        //OperatorButton Text -> Witi_Y_gv_labelNumber.Text + OperatorButton.Text ->  Witi_Y_gv_labelExpression

        private void Witi_Y_labelWrite()
        {
            WitiCalculator.Witi_KSM_Api_original Witi_KSM_lv_ApiInstance = new WitiCalculator.Witi_KSM_Api_original();

            if (Witi_Y_gv_labelDEC.Font.Bold == true)
            {
                Witi_Y_gv_labelWriteDEC.Text = Witi_Y_gv_labelNumber.Text;
                Witi_Y_gv_labelWriteBIN.Text = Convert.ToString(Int32.Parse(Witi_Y_gv_labelNumber.Text), 2);
                Witi_Y_gv_labelWriteOCT.Text = Convert.ToString(Int32.Parse(Witi_Y_gv_labelNumber.Text), 8);
                Witi_Y_gv_labelWriteHEX.Text = Convert.ToString(Int32.Parse(Witi_Y_gv_labelNumber.Text), 16);
            }

            else if (Witi_Y_gv_labelHEX.Font.Bold == true)
            {
                Witi_Y_gv_labelWriteHEX.Text = Witi_Y_gv_labelNumber.Text;
                Witi_Y_gv_labelWriteBIN.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteHEX.Text, 16), 2);
                Witi_Y_gv_labelWriteDEC.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteHEX.Text, 16), 10);
                Witi_Y_gv_labelWriteOCT.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteHEX.Text, 16), 8);
            }

            else if (Witi_Y_gv_labelOCT.Font.Bold == true)
            {
                Witi_Y_gv_labelWriteOCT.Text = Witi_Y_gv_labelNumber.Text;
                Witi_Y_gv_labelWriteBIN.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteOCT.Text, 8), 2);
                Witi_Y_gv_labelWriteDEC.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteOCT.Text, 8), 10);
                Witi_Y_gv_labelWriteHEX.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteOCT.Text, 8), 16);
            }

            else if (Witi_Y_gv_labelBIN.Font.Bold == true)
            {
                Witi_Y_gv_labelWriteBIN.Text = Witi_Y_gv_labelNumber.Text;
                Witi_Y_gv_labelWriteDEC.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteBIN.Text, 2), 10);
                Witi_Y_gv_labelWriteOCT.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteBIN.Text, 2), 8);
                Witi_Y_gv_labelWriteHEX.Text = Convert.ToString(Witi_KSM_lv_ApiInstance.WITI_Convert_Toint32(Witi_Y_gv_labelWriteBIN.Text, 2), 16);
            }
        }
        //Witi_Y_gv_labelNumber.Text -> Witi_Y_gv_labelWriteBIN, Witi_Y_gv_labelWriteDEC, Witi_Y_gv_labelWriteOCT, Witi_Y_gv_labelWriteHEX



        private void Witi_Y_eventLabel_MouseDown(object sender, MouseEventArgs e)
        {
            Label Witi_Y_lv_label = (Label)sender;

            Witi_Y_gv_labelHEX.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style & ~FontStyle.Bold);
            Witi_Y_gv_labelDEC.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style & ~FontStyle.Bold);
            Witi_Y_gv_labelBIN.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style & ~FontStyle.Bold);
            Witi_Y_gv_labelOCT.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style & ~FontStyle.Bold);

            Witi_Y_gv_colorLabelHEX.BackColor = SystemColors.Control;
            Witi_Y_gv_colorLabelDEC.BackColor = SystemColors.Control;
            Witi_Y_gv_colorLabelOCT.BackColor = SystemColors.Control;
            Witi_Y_gv_colorLabelBIN.BackColor = SystemColors.Control;
            Witi_Y_gv_checkNewNumber = true;

            if (Witi_Y_lv_label.Text == "DEC")
            {
                Witi_Y_gv_highlight = Highlight.DEC;
                Witi_Y_lv_label.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style | FontStyle.Bold);
                Witi_Y_gv_colorLabelDEC.BackColor = Color.LimeGreen;
                Witi_Y_gv_buttonA.Enabled = Witi_Y_gv_buttonB.Enabled = Witi_Y_gv_buttonC.Enabled = false;
                Witi_Y_gv_buttonD.Enabled = Witi_Y_gv_buttonE.Enabled = Witi_Y_gv_buttonF.Enabled = false;

                Witi_Y_gv_button0.Enabled = Witi_Y_gv_button1.Enabled = Witi_Y_gv_button2.Enabled = true;
                Witi_Y_gv_button3.Enabled = Witi_Y_gv_button4.Enabled = Witi_Y_gv_button5.Enabled = true;
                Witi_Y_gv_button6.Enabled = Witi_Y_gv_button7.Enabled = Witi_Y_gv_button8.Enabled = true;
                Witi_Y_gv_button9.Enabled = true;
            }

            else if (Witi_Y_lv_label.Text == "BIN")
            {
                Witi_Y_gv_highlight = Highlight.BIN;
                Witi_Y_lv_label.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style | FontStyle.Bold);
                Witi_Y_gv_colorLabelBIN.BackColor = Color.LimeGreen;
                Witi_Y_gv_buttonA.Enabled = Witi_Y_gv_buttonB.Enabled = Witi_Y_gv_buttonC.Enabled = false;
                Witi_Y_gv_buttonD.Enabled = Witi_Y_gv_buttonE.Enabled = Witi_Y_gv_buttonF.Enabled = false;
                Witi_Y_gv_button2.Enabled = Witi_Y_gv_button9.Enabled = false;
                Witi_Y_gv_button3.Enabled = Witi_Y_gv_button4.Enabled = Witi_Y_gv_button5.Enabled = false;
                Witi_Y_gv_button6.Enabled = Witi_Y_gv_button7.Enabled = Witi_Y_gv_button8.Enabled = false;

                Witi_Y_gv_button0.Enabled = Witi_Y_gv_button1.Enabled = true;
            }

            else if (Witi_Y_lv_label.Text == "OCT")
            {
                Witi_Y_gv_highlight = Highlight.OCT;
                Witi_Y_lv_label.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style | FontStyle.Bold);
                Witi_Y_gv_colorLabelOCT.BackColor = Color.LimeGreen;
                Witi_Y_gv_buttonA.Enabled = Witi_Y_gv_buttonB.Enabled = Witi_Y_gv_buttonC.Enabled = false;
                Witi_Y_gv_buttonD.Enabled = Witi_Y_gv_buttonE.Enabled = Witi_Y_gv_buttonF.Enabled = false;
                Witi_Y_gv_button8.Enabled = Witi_Y_gv_button9.Enabled = false;

                Witi_Y_gv_button0.Enabled = Witi_Y_gv_button1.Enabled = Witi_Y_gv_button2.Enabled = true;
                Witi_Y_gv_button3.Enabled = Witi_Y_gv_button4.Enabled = Witi_Y_gv_button5.Enabled = true;
                Witi_Y_gv_button6.Enabled = Witi_Y_gv_button7.Enabled = true;
            }

            else if (Witi_Y_lv_label.Text == "HEX")
            {
                Witi_Y_gv_highlight = Highlight.HEX;
                Witi_Y_lv_label.Font = new Font(Witi_Y_lv_label.Font, Witi_Y_lv_label.Font.Style | FontStyle.Bold);
                Witi_Y_gv_colorLabelHEX.BackColor = Color.LimeGreen;
                Witi_Y_gv_buttonA.Enabled = Witi_Y_gv_buttonB.Enabled = Witi_Y_gv_buttonC.Enabled = true;
                Witi_Y_gv_buttonD.Enabled = Witi_Y_gv_buttonE.Enabled = Witi_Y_gv_buttonF.Enabled = true;
                Witi_Y_gv_button0.Enabled = Witi_Y_gv_button1.Enabled = Witi_Y_gv_button2.Enabled = true;
                Witi_Y_gv_button3.Enabled = Witi_Y_gv_button4.Enabled = Witi_Y_gv_button5.Enabled = true;
                Witi_Y_gv_button6.Enabled = Witi_Y_gv_button7.Enabled = Witi_Y_gv_button8.Enabled = true;
                Witi_Y_gv_button9.Enabled = true;
            }
            //Witi_Y_gv_labelWriteBIN, Witi_Y_gv_labelWriteDEC, Witi_Y_gv_labelWriteOCT, Witi_Y_gv_labelWriteHEX Button Enabled 
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

