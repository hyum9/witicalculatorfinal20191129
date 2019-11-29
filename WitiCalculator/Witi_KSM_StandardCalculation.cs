using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitiCalculator
{
    class WITI_KSM_StandardCalculation
    {
        public WITI_KSM_StandardCalculation() { }// 기본생성자 

        public static string WITI_KSM_notMethod(string WITI_KSM_lv_number)
        {
            long WITI_KSM_lv_notString = ~WITI_KSM_Api.WITI_KSM_Convert_Toint64(WITI_KSM_lv_number) + 1;
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_notString);

        }

        public static string WITI_KSM_PlusMethod(string WITI_KSM_lv_fristNumber, string WITI_KSM_lv_secondNumber)
        {
            double WITI_KSM_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_fristNumber) +
                WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber);
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
        }

        public static string WITI_KSM_MinusMethod(string WITI_KSM_lv_fristNumber, string WITI_KSM_lv_secondNumber)
        {
            if (WITI_KSM_lv_fristNumber == "")
            {
                return WITI_KSM_lv_secondNumber;
            }
            double WITI_KSM_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_fristNumber) -
                WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber);
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
        }

        public static string WITI_KSM_MultiMethod(string WITI_KSM_lv_fristNumber, string WITI_KSM_lv_secondNumber)
        {
            double WITI_KSM_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_fristNumber) *
                WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber);
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
        }

        public static string WITI_KSM_DivisionMethod(string WITI_KSM_lv_fristNumber, string WITI_KSM_lv_secondNumber)
        {
            double WITI_KSM_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_fristNumber) /
                WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber);
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
        }

        public static string WITI_KSM_EtcMethod(string WITI_KSM_lv_fristNumber, string WITI_KSM_lv_secondNumber)
        {
            double WITI_KSM_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_fristNumber) %
                WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber);
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
        }

        public static string WITI_KSM_SquareMethod(string WITI_KSM_lv_fristNumber)
        {
            double WITI_KSM_lv_result = Math.Pow(WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_lv_fristNumber), 2);
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
        }


    }
}
