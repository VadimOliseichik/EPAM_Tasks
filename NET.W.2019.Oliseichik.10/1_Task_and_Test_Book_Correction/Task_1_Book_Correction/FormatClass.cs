using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task_1_Book_Correction
{
    /// <summary>
    /// Class implementing interface IFormatProvider and interface ICustomFormatter.
    /// </summary>
    public class FormatClass : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Method get format.
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// A method that implements a given format.
        /// </summary>
        /// <param name="fmt"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(string))
            {
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }

            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "H" || ufmt == "I"))
            {
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }

            string result = arg.ToString();

            if (ufmt == "I")
            {
                return result.Replace("-", string.Empty);
            }
            else 
            {
                return result;
            }                   
        }

        /// <summary>
        /// Method Handle other formats.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
