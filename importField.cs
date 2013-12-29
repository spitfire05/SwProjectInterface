
namespace SwProjectInterface
{
    public class importField
    {
        public string Name { get; set; }
        public importFieldValue Value { get; set; }

        public importField(string name, importFieldValue value)
        {
            Name = name;
            Value = value;
        }
    }

    public enum importFieldValue
    {
        NONE,
        PREFIX,
        SUFFIX,
        NAME,
        NUMBER,
        PREFIX_NUMBER_SUFFIX,
        PATH_RELATIVE,
        PATH_ABSOLUTE,
    }
}
