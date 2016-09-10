using System;

namespace Argum
{
    public class ArgumValueConverter
    {
        public static object ConvertValue(object val, Type destType)
        {
            try
            {
                if (destType.IsArray)
                    return ConvertToArray(val, destType.GetElementType());

                return ConvertSingleValue(val, destType);
            }
            catch(Exception ex)
            {
                throw new ArgumException($"Cannot convert value: {val} to {destType.Name}", ex);
            }
        }

        private static object ConvertToArray(object val, Type elementType)
        {
            var source = val.ToString().Split(',');

            var arr = Array.CreateInstance(elementType, source.Length);
            for (int i = 0; i < source.Length; i++)
                arr.SetValue(ConvertSingleValue(source[i], elementType), i);

            return arr;
        }

        private static object ConvertSingleValue(object val, Type destType) => Convert.ChangeType(val, destType);

    }
}
