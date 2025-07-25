﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFilters.Extensions
{
    public class GradientsExtension : IMarkupExtension<LinearGradientBrush>
    {
        public string Colors { get; set; }
        public string Direction { get; set; }
        public LinearGradientBrush ProvideValue(IServiceProvider serviceProvider)
        {
            if(string.IsNullOrWhiteSpace(Colors))
            {
                throw new ArgumentException("Colors must be provided");
            }

            var colorStrings = Colors.Split(',');

            foreach(var colorString in colorStrings)
            {
                if(!IsValidColor(colorString))
                    throw new ArgumentException($"Invalid color format: {colorString}");
            }

            var brush = new LinearGradientBrush();

            var step = 1.0 / (colorStrings.Length - 1);

            var offset = 0.0;

            GetDirection(brush);

            foreach(var colorString in colorStrings)
            {
                var color = Color.FromArgb(colorString);
                brush.GradientStops.Add(new GradientStop(color, (float)offset));
                offset += step;
            }

            return brush;

        }

        private void GetDirection(LinearGradientBrush brush)
        {
            (brush.StartPoint, brush.EndPoint) = Direction.ToLower() switch
            {
               "u" => (new Point(0, 1), new Point(0, 0)),
               "d" => (new Point(0, 0), new Point(0, 1)),
               "l" => (new Point(1, 0), new Point(0, 0)),
               "r" => (new Point(0, 0), new Point(1, 0)),
               _ => (new Point(0, 1), new Point(0, 0))
            };
        }

        private bool IsValidColor(string colorString)
        {
            return colorString.StartsWith("#") && colorString.Length == 7; //#FFFFFF
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<LinearGradientBrush>)
                .ProvideValue(serviceProvider);
        }
    }
}
