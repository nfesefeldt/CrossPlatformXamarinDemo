using System.Diagnostics;
using System.Reflection;

namespace XamarinDemo.Attributes
{
    public class FontUtil
    {
        public static void ApplyFontAttribute(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetRuntimeProperties();

            // class properties
            foreach (var property in properties)
            {
                //property attributes
                foreach(var attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is FontAttribute fontAttribute)
                    {
                        Debug.WriteLine("Found the attribute for: " + property.Name);
                    }
                }
                
            }
        }
    }
}
