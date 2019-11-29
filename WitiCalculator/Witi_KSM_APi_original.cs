using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitiCalculator
{
    internal class Witi_KSM_Api_original
    {
        public int WITI_Convert_Toint32(string WITI_lv_str)             // 문제가 있을시 0을 반환
        {
            int WITI_lv_result = 0;
            try
            {
                if (WITI_lv_str != null)
                {
                    WITI_lv_result = Convert.ToInt32(WITI_lv_str);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return WITI_lv_result;                                      // string 값을 받아 int 형으로 리턴해준다.
        }

        public int WITI_Convert_Toint32(string WITI_lv_str, int WITI_lv_number)
        {
            int WITI_lv_result = 0;

            if (WITI_lv_str != null)
            {
                switch (WITI_lv_number)
                {
                    case 2:
                        WITI_lv_result = Convert.ToInt32(WITI_lv_str, 2);
                        break;
                    case 8:
                        WITI_lv_result = Convert.ToInt32(WITI_lv_str, 8);
                        break;
                    case 10:
                        WITI_lv_result = Convert.ToInt32(WITI_lv_str, 10);
                        break;
                    case 16:
                        WITI_lv_result = Convert.ToInt32(WITI_lv_str, 16);
                        break;
                }
            }

            return WITI_lv_result;                                      // string 값을 받아 WITI_lv_number의 진수로 진수변환해준다. 
        }

        public double WITI_Convert_ToDouble(string WITI_lv_str)             // 문제가 있을시 0을 반환
        {
            double WITI_lv_result = 0;
            try
            {
                if (WITI_lv_str != null)
                {
                    WITI_lv_result = Convert.ToDouble(WITI_lv_str);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return WITI_lv_result;                                      // string 값을 받아 double 형으로 리턴해준다.
        }

        public long WITI_Convert_Toint64(string WITI_lv_str)             // 문제가 있을시 0을 반환
        {
            long WITI_lv_result = 0;
            try
            {
                if (WITI_lv_str != null)
                {
                    WITI_lv_result = Convert.ToInt64(WITI_lv_str);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return WITI_lv_result;                                      // string 값을 받아 long 형으로 리턴해준다.
        }

        public long WITI_Convert_Toint64(string WITI_lv_str, int WITI_lv_number)
        {
            long WITI_lv_result = 0;

            if (WITI_lv_str != null)
            {
                switch (WITI_lv_number)
                {
                    case 2:
                        WITI_lv_result = Convert.ToInt64(WITI_lv_str, 2);
                        break;
                    case 8:
                        WITI_lv_result = Convert.ToInt64(WITI_lv_str, 8);
                        break;
                    case 10:
                        WITI_lv_result = Convert.ToInt64(WITI_lv_str, 10);
                        break;
                    case 16:
                        WITI_lv_result = Convert.ToInt64(WITI_lv_str, 16);
                        break;
                }
            }

            return WITI_lv_result;                                      // string 값을 받아 WITI_lv_number의 진수로 진수변환해준다. 
        }



        public static string WITI_Convert_ToString(int WITI_lv_number)
        {
            return Convert.ToString(WITI_lv_number);                    // int 값을 받아 string 값으로 리턴해준다.
        }

        public static string WITI_Convert_ToString(double WITI_lv_number)
        {
            return Convert.ToString(WITI_lv_number);                    // double 값을 받아 string 값으로 리턴해준다.
        }

        public static string WITI_Convert_ToString(float WITI_lv_number)
        {
            return Convert.ToString(WITI_lv_number);                    // float 값을 받아 string 값으로 리턴해준다.
        }

        public string WITI_Convert_ToString(int WITI_lv_number, int WITI_lv_binaryNumber)
        {
            string WITI_lv_result = null;

            if (WITI_lv_number != 0)
            {
                switch (WITI_lv_binaryNumber)
                {
                    case 2:
                        WITI_lv_result = Convert.ToString(WITI_lv_number, 2);
                        break;
                    case 8:
                        WITI_lv_result = Convert.ToString(WITI_lv_number, 8);
                        break;
                    case 10:
                        WITI_lv_result = Convert.ToString(WITI_lv_number, 10);
                        break;
                    case 16:
                        WITI_lv_result = Convert.ToString(WITI_lv_number, 16);
                        break;
                }
            }

            return WITI_lv_result;                                      // int 값을 받아 WITI_lv_binaryNumber의 진수로 진수변환해준다. 
        }
    }
}
