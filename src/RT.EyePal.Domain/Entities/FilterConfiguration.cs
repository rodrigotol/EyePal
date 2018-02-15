using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace RT.EyePal.Domain.Entities
{
    [XmlRoot]
    public class FilterConfiguration
    {       
        public byte FilterColorA { get; set; }
        public byte FilterColorR { get; set; }
        public byte FilterColorG { get; set; }
        public byte FilterColorB { get; set; }
        public double FilterOpacity { get; set; }

        /// <summary>
        /// Checks if the entity is valid
        /// </summary>
        /// <returns>true if valid, false otherwise</returns>
        public bool IsValid()
        {
            return FilterOpacity >= 0.0 && FilterOpacity <= 1.0;
        }

        public Color CreateNewFilterColor()
        {
            return Color.FromArgb(FilterColorA, FilterColorR, FilterColorG, FilterColorB);
        }
    }
}