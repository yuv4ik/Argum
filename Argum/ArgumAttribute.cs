using System;

namespace Argum
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumAttribute : Attribute
    {

        public readonly string Name;
        public readonly string Description;
        public readonly bool IsMandatory;

        /// <param name="name">The name (key) of the argument.</param>
        /// <param name="isMandatory">If marked as mandatory an exception will be thrown if missing from the user input.</param>
        /// <param name="description">Desription to use in auto-generated help message.</param>
        public ArgumAttribute(string name, bool isMandatory = false, string description = null)
        {
            Name = name;
            IsMandatory = isMandatory;
            Description = description;
        }

        public override string ToString()
        {
            var helpDescription = $"{Name} (mandatory: {IsMandatory})";
            if (!string.IsNullOrEmpty(Description))
                helpDescription += $" - {Description}";
            return helpDescription;
        }

    }
}
