using System;
using System.Drawing;

namespace RT.EyePal.Application.ViewModels
{
    public class FilterConfigurationViewModel
    {
        public Color FilterColor { get; set; }
        public double FilterOpacity { get; set; }

        public FilterConfigurationViewModel()
        {
            FilterColor = Color.Black;
            FilterOpacity = 0.5;
        }      

        public byte GetFilterOpacityAsByte()
        {
            return (byte)(FilterOpacity * 255);
        }
    }
}