using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitiCalculator
{
    class WITI_LSH_EngineeringCalculation
    {
        public WITI_LSH_EngineeringCalculation() { }

        public static string WITI_LSH_ExpMethod(string WITI_LSH_Iv_fristNumber, string WITI_Iv_secondNumber)
        {         
            double WITI_LSH_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_LSH_Iv_fristNumber) * WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_Api.WITI_KSM_Pow(WITI_KSM_Api.WITI_KSM_Convert_ToString(10), WITI_Iv_secondNumber));
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_LSH_lv_result);
        }
        public static string WITI_LSH_10squareMethod(string WITI_LSH_Iv_fristNumber)
        {
            double WITI_LSH_lv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_Api.WITI_KSM_Pow(WITI_KSM_Api.WITI_KSM_Convert_ToString(10), WITI_LSH_Iv_fristNumber));
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_LSH_lv_result);
        }
        public static string WITI_LSH_XsquareYMethod(string WITI_LSH_Iv_firstNumber, string WITI_LSH_Iv_SecondNumber)
        {
            double WITI_LSH_Iv_result = WITI_KSM_Api.WITI_KSM_Convert_ToDouble(WITI_KSM_Api.WITI_KSM_Pow(WITI_LSH_Iv_firstNumber, WITI_LSH_Iv_SecondNumber));
            return WITI_KSM_Api.WITI_KSM_Convert_ToString(WITI_LSH_Iv_result);
        }

    }
}
