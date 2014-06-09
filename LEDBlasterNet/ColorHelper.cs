using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LEDBlasterNet
{
    public static class ColorHelper
    {
        private static readonly Random _random;

        static ColorHelper()
        {
            _random = new Random();
        }

        public static Color GetRandomColor()
        {
            var rand = (float)(GetRandomNextDouble(0, 360));
            var color = HSBtoRGB(255, rand, 1f, 0.5f);
            Console.WriteLine("RandColor(R,G,B): {0},{1},{2}", color.R, color.G, color.B);
            return color;
        }
        private static double GetRandomNextDouble(double min, double max)
        {
            return min + _random.NextDouble() * (max - min);
        }

        public static Color HSBtoRGB(int a, float h, float s, float b)
        {

            if (0 > a || 255 < a)
            {
                throw new ArgumentOutOfRangeException("a");
            }
            if (0f > h || 360f < h)
            {
                throw new ArgumentOutOfRangeException("h");
            }
            if (0f > s || 1f < s)
            {
                throw new ArgumentOutOfRangeException("s");
            }
            if (0f > b || 1f < b)
            {
                throw new ArgumentOutOfRangeException("b");
            }

            if (0 == s)
            {
                return Color.FromArgb(a, Convert.ToInt32(b * 255),
                  Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < b)
            {
                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else
            {
                fMax = b + (b * s);
                fMin = b - (b * s);
            }

            iSextant = (int)Math.Floor(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(a, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(a, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(a, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(a, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(a, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(a, iMax, iMid, iMin);
            }
        }

        public static HsbColor RGBtoHSB(Color color)
        {
            return new HsbColor() { Brightness = color.GetBrightness(), Saturation = color.GetSaturation(), Hue = color.GetHue() };
        }

        public struct HsbColor
        {
            public double Hue;
            public double Saturation;
            public double Brightness;
        }
    }
}
