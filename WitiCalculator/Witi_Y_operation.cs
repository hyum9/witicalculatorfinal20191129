using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitiCalculator
{
    internal class Witi_Y_operation
    {
        private char Witi_Y_operator;
        private int Witi_Y_numOriginal;
        private int Witi_Y_numNew;
        private int Witi_Y_result;

        public Witi_Y_operation(int Witi_Y_numOriginal, char Witi_Y_operator, string Witi_Y_numNew)
        {
            WitiCalculator.Witi_KSM_Api_original witi_KSM_Api_lv_Instance = new WitiCalculator.Witi_KSM_Api_original();
            this.Witi_Y_numOriginal = Witi_Y_numOriginal;
            this.Witi_Y_operator = Witi_Y_operator;
            this.Witi_Y_numNew = witi_KSM_Api_lv_Instance.WITI_Convert_Toint32(Witi_Y_numNew);
            this.Witi_Y_result = 0;
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
                default:
                    break;
            }

            return Witi_Y_result;
        }
    }
}
