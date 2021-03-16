using System;

namespace LeaguerManagement.Entities.Utilities.Extentsion
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the string value.
        /// </summary>
        public static string ToValue(this Enum thisEnum)
        {
            string output = null;
            var type = thisEnum.GetType();

            // Check first in our cached results...
            // Look for our 'StringValueAttribute' in the field's custom attributes
            var fi = type.GetField(thisEnum.ToString());

            if (fi.GetCustomAttributes(typeof(StringValue), false) is StringValue[] attrs && attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Define the string value enumeration
    /// </summary>
    public class StringValue : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public StringValue(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }
    }
}
