using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WitiCalculator
{
    internal class Witi_Y_operation
    {
        private char Witi_Y_operator;
        private int Witi_Y_numOriginal;
        private int Witi_Y_numNew;
        private int Witi_Y_result;
        private int Witi_Y_highlight;

        public Witi_Y_operation(int Witi_Y_numOriginal, char Witi_Y_operator, string Witi_Y_numNew, int Witi_Y_lv_highlight)
        {
            WitiCalculator.Witi_KSM_Api_original witi_KSM_Api_lv_Instance = new WitiCalculator.Witi_KSM_Api_original();
            this.Witi_Y_numOriginal = Witi_Y_numOriginal;
            this.Witi_Y_operator = Witi_Y_operator;
            this.Witi_Y_numNew = witi_KSM_Api_lv_Instance.WITI_Convert_Toint32(Witi_Y_numNew);
            this.Witi_Y_result = 0;
            this.Witi_Y_highlight = Witi_Y_lv_highlight;
        }


        public int Witi_Y_getNum()
        {
            switch (Witi_Y_operator)
            {
                case '+':
                    this.Witi_Y_result = this.Witi_Y_numOriginal + this.Witi_Y_numNew;
                    break;
                case '-':
                    this.Witi_Y_result = this.Witi_Y_numOriginal - this.Witi_Y_numNew;
                    break;
                case '/':
                    this.Witi_Y_result = this.Witi_Y_numOriginal / this.Witi_Y_numNew;
                    break;
                case 'x':
                    this.Witi_Y_result = this.Witi_Y_numOriginal * this.Witi_Y_numNew;
                    break;
                case 'O':
                case 'X':
                case 'A':
                    this.Witi_Y_result = Witi_Y_bitOperator();
                    break;
                case 'L':
                case 'R':
                    this.Witi_Y_result = Witi_Y_bitShift();
                    break;
                case 'M':
                    this.Witi_Y_result = this.Witi_Y_numOriginal % this.Witi_Y_numNew;
                    break;
                default:
                    break;
            }

            return Witi_Y_result;
        }

        //this.Witi_Y_numOriginal
        //this.Witi_Y_numNew

        private int Witi_Y_bitOperator()
        {
            int Witi_Y_result = 0;
            byte temp = 0;
            //int->string
            string stroriginal = Witi_Y_numOriginal.ToString();
            string strnewnum = Witi_Y_numNew.ToString();
            //string->byte
            byte byteoriginal = Convert.ToByte(stroriginal, 10);
            byte bytenewnum = Convert.ToByte(strnewnum, 10);
            //calculate byte
            switch (Witi_Y_operator)
            {
                case 'O':
                    temp = (byte)(byteoriginal | bytenewnum);
                    break;
                case 'X':
                    temp = (byte)(byteoriginal ^ bytenewnum);
                    break;
                case 'A':
                    temp = (byte)(byteoriginal & bytenewnum);
                    break;
            }
            //Witi_Y_result
            Witi_Y_result = Convert.ToInt32(temp);

            return Witi_Y_result;
        }

        private int Witi_Y_bitShift()
        {
            int Witi_Y_result = 0;
            var temp = 0;
            string strtemp = null;

            switch(Witi_Y_operator)
            {
                case 'L':
                    temp = Witi_Y_numOriginal << Witi_Y_numNew;
                    break;
                case 'R':
                    temp = Witi_Y_numOriginal >> Witi_Y_numNew;
                    break;
            }

            strtemp = Convert.ToString(temp, toBase:10);
            Witi_Y_result = Int32.Parse(strtemp);
            return Witi_Y_result;
        }

    }
}
