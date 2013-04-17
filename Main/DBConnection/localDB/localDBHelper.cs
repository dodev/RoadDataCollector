using System;
using System.Text;

namespace DBConnection
{
    static public class localDBHelper
    {
        /// <summary>
        /// Перевод численного массива в строку вида: "N0; N1; "
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static public string ArrayToString(int[] array)
        {
            if (array.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder rValue = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                rValue.AppendFormat("{0}; ", array[i]);
            }

            return rValue.ToString();
        }

        /// <summary>
        /// Перевод строки вида: "N0; N1; " в численный массив.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public int[] StringToArray(string str)
        {
            if (str == String.Empty)
            {
                return null;
            }

            string[] values = str.Split(";".ToCharArray());

            int[] rValue = new int[values.Length - 1];

            for (int i = 0; i < values.Length - 1; i++)
            {
                rValue[i] = int.Parse(values[i]);
            }

            return rValue;
        }

        /// <summary>
        /// Перевод координат Х и У в строку вида: "Х; У"
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        static public string PointToString(int X, int Y, int Z)
        {
            return String.Format("{0}; {1}; {2}", X, Y, Z);
        }

        /// <summary>
        /// Перевод строки вида: "Х; У" в переменную типа Point
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public int[] StringToPoint(string str)
        {
            string[] values = str.Split(";".ToCharArray());

            return new int[] { int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]) };
        }
    }
}