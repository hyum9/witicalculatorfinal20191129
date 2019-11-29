using System;

namespace WitiCalculator
{

    class WITI_KSM_Api
    {
        public WITI_KSM_Api()
        {
            // 기본 생성자
        }

        public static string getPI()
        {
            return WITI_KSM_Convert_ToString(Math.PI);
        }

        public static int WITI_KSM_Convert_Toint32(string WITI_KSM_lv_numberText)             // 문제가 있을시 0을 반환
        {
            int WITI_KSM_lv_result = 0;
            try
            {
                if (WITI_KSM_lv_numberText != null)
                {
                    WITI_KSM_lv_result = Convert.ToInt32(WITI_KSM_lv_numberText);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return WITI_KSM_lv_result;                                      // string 값을 받아 int 형으로 리턴해준다.
        }

        public static int WITI_KSM_Convert_Toint32(string WITI_KSM_lv_numberText, int WITI_KSM_lv_number)
        {
            int WITI_KSM_lv_result = 0;

            try
            {
                if (WITI_KSM_lv_numberText != null)
                {
                    switch (WITI_KSM_lv_number)
                    {
                        case 2:
                            WITI_KSM_lv_result = Convert.ToInt32(WITI_KSM_lv_numberText, 2);
                            break;
                        case 8:
                            WITI_KSM_lv_result = Convert.ToInt32(WITI_KSM_lv_numberText, 8);
                            break;
                        case 10:
                            WITI_KSM_lv_result = Convert.ToInt32(WITI_KSM_lv_numberText, 10);
                            break;
                        case 16:
                            WITI_KSM_lv_result = Convert.ToInt32(WITI_KSM_lv_numberText, 16);
                            break;
                    }
                }
                return WITI_KSM_lv_result;
            }
            catch(Exception)
            {
                return 0;
            }
            

                                                // string 값을 받아 WITI_lv_number의 진수로 진수변환해준다. 
        }

        public static double WITI_KSM_Convert_ToDouble(string WITI_KSM_lv_numberText)             // 문제가 있을시 0을 반환
        {
            double WITI_KSM_lv_result = 0;
            try
            {
                if (WITI_KSM_lv_numberText != null)
                {
                    WITI_KSM_lv_result = Convert.ToDouble(WITI_KSM_lv_numberText);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return WITI_KSM_lv_result;                                      // string 값을 받아 double 형으로 리턴해준다.
        }

        public static long WITI_KSM_Convert_Toint64(string WITI_KSM_lv_numberText)             // 문제가 있을시 0을 반환
        {
            long WITI_KSM_lv_result = 0;
            try
            {
                if (WITI_KSM_lv_numberText != null)
                {
                    WITI_KSM_lv_result = Convert.ToInt64(WITI_KSM_lv_numberText);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return WITI_KSM_lv_result;                                      // string 값을 받아 long 형으로 리턴해준다.
        }

        public static long WITI_KSM_Convert_Toint64(string WITI_KSM_lv_numberText, int WITI_KSM_lv_number)
        {
            long WITI_KSM_lv_result = 0;

            if (WITI_KSM_lv_numberText != null)
            {
                switch (WITI_KSM_lv_number)
                {
                    case 2:
                        WITI_KSM_lv_result = Convert.ToInt64(WITI_KSM_lv_numberText, 2);
                        break;
                    case 8:
                        WITI_KSM_lv_result = Convert.ToInt64(WITI_KSM_lv_numberText, 8);
                        break;
                    case 10:
                        WITI_KSM_lv_result = Convert.ToInt64(WITI_KSM_lv_numberText, 10);
                        break;
                    case 16:
                        WITI_KSM_lv_result = Convert.ToInt64(WITI_KSM_lv_numberText, 16);
                        break;
                }
            }

            return WITI_KSM_lv_result;                                      // string 값을 받아 WITI_lv_number의 진수로 진수변환해준다. 
        }

        public static string WITI_KSM_Convert_ToString(int WITI_KSM_lv_number)
        {
            return Convert.ToString(WITI_KSM_lv_number);                    // int 값을 받아 string 값으로 리턴해준다.
        }

        public static string WITI_KSM_Convert_ToString(double WITI_KSM_lv_number)
        {
            return Convert.ToString(WITI_KSM_lv_number);                    // double 값을 받아 string 값으로 리턴해준다.
        }

        public static string WITI_KSM_Convert_ToString(float WITI_KSM_lv_number)
        {
            return Convert.ToString(WITI_KSM_lv_number);                    // float 값을 받아 string 값으로 리턴해준다.
        }

        public static string WITI_KSM_Convert_ToString(int WITI_KSM_lv_number, int WITI_KSM_lv_binaryNumber)
        {
            string WITI_KSM_lv_result = null;

            if (WITI_KSM_lv_number != 0)
            {
                switch (WITI_KSM_lv_binaryNumber)
                {
                    case 2:
                        WITI_KSM_lv_result = Convert.ToString(WITI_KSM_lv_number, 2);
                        break;
                    case 8:
                        WITI_KSM_lv_result = Convert.ToString(WITI_KSM_lv_number, 8);
                        break;
                    case 10:
                        WITI_KSM_lv_result = Convert.ToString(WITI_KSM_lv_number, 10);
                        break;
                    case 16:
                        WITI_KSM_lv_result = Convert.ToString(WITI_KSM_lv_number, 16);
                        break;
                }
            }

            return WITI_KSM_lv_result;                                      // int 값을 받아 WITI_lv_binaryNumber의 진수로 진수변환해준다. 
        }

        public static bool WITI_KSM_IsNullOrWhiteSpace(string WITI_KSM_lv_numberText)
        {
            return String.IsNullOrWhiteSpace(WITI_KSM_lv_numberText);   // string 값이 공백으로만 이루어져있는지를 판단해 공백이면 true, 아니면 false를 반환
        }

        public static bool WITI_KSM_Contains(string WITI_KSM_lv_numberText, string WITI_KSM_lv_text)
        {
            return WITI_KSM_lv_numberText.Contains(WITI_KSM_lv_text);   // WITI_KSM_lv_numberText에서 WITI_KSM_lv_text의 값이 있는지 판단후 있으면 true, 없으면 false를 반환
        }

        public static int WITI_KSM_Length(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_lv_numberText.Length;   // WITI_KSM_lv_numberText값의 길이를 반환
        }

        public static string WITI_KSM_Substring(string WITI_KSM_lv_numberText, int WITI_KSM_lv_startIndex, int WITI_KSM_lv_length)
        {
            return WITI_KSM_lv_numberText.Substring(WITI_KSM_lv_startIndex, WITI_KSM_lv_length);
            // WITI_KSM_lv_numberText의 WITI_KSM_lv_startIndex부터 WITI_KSM_lv_length까지 문자열을 잘라줌
        }

        public static string WITI_KSM_Pow(string WITI_KSM_lv_firstNumber, string WITI_KSM_lv_secondNumber)
        {
            return WITI_KSM_Convert_ToString(Math.Pow(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_firstNumber), WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber)));
            // WITI_KSM_lv_firstNumber의 WITI_KSM_lv_secondNumber승을 string값으로 리턴
        }

        public static string WITI_KSM_Sin(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_Convert_ToString(Math.Sin(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_numberText)));
        }

        public static string WITI_KSM_Cos(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_Convert_ToString(Math.Cos(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_numberText)));
        }

        public static string WITI_KSM_Tan(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_Convert_ToString(Math.Tan(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_numberText)));
        }

        public static string WITI_KSM_Sqrt(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_Convert_ToString(Math.Sqrt(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_numberText)));
        }

        public static string WITI_KSM_Max(string WITI_KSM_lv_firstNumber, string WITI_KSM_lv_secondNumber)
        {
            return WITI_KSM_Convert_ToString(Math.Max(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_firstNumber), WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber)));
        }

        public static string WITI_KSM_Min(string WITI_KSM_lv_firstNumber, string WITI_KSM_lv_secondNumber)
        {
            return WITI_KSM_Convert_ToString(Math.Min(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_firstNumber), WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber)));
        }

        public static string WITI_KSM_Log(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_Convert_ToString(Math.Log(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_numberText)));
        }

        public static string WITI_KSM_Log(string WITI_KSM_lv_firstNumber, string WITI_KSM_lv_secondNumber)
        {
            return WITI_KSM_Convert_ToString(Math.Log(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_firstNumber), WITI_KSM_Convert_ToDouble(WITI_KSM_lv_secondNumber)));
        }

        public static string WITI_KSM_Exp(string WITI_KSM_lv_numberText)
        {
            return WITI_KSM_Convert_ToString(Math.Exp(WITI_KSM_Convert_ToDouble(WITI_KSM_lv_numberText)));
        }

        public static string WITI_KSM_Fact(string WITI_KSM_lv_numberText)
        {
            int WITI_KSM_lv_index = WITI_KSM_Convert_Toint32(WITI_KSM_lv_numberText);
            long WITI_KSM_lv_result = 1;
            for(int WITI_KSM_lv_i = 1; WITI_KSM_lv_i <= WITI_KSM_lv_index; WITI_KSM_lv_i++)
            {
                WITI_KSM_lv_result *= WITI_KSM_lv_i;
            }

            return WITI_KSM_Convert_ToString(WITI_KSM_lv_result);
            // 팩토리얼
        }
    }
}
