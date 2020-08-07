using System;
namespace XamarinDemo.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class FontAttribute : Attribute
    {
        public FontEnum Font { get; set; }
        public ColorEnum Color { get; set; }
        public string Size { get; set; }

        public FontAttribute()
        {
        }
    }
}
