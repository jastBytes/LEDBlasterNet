using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LEDBlasterNet;

namespace LEDBlasterREST
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RGBLedService : IRGBLedServiceContract
    {
        private RGBLed _rgbLed;

        public RGBLedService()
        {
            Console.WriteLine("Created new service instance.");
            _rgbLed = null;
        }

        public bool SetPorts(int red, int green, int blue)
        {
            if (_rgbLed == null)
            {
                _rgbLed = new RGBLed(red, green, blue);
            }
            else
            {
                _rgbLed.PinRed = red;
                _rgbLed.PinGreen = red;
                _rgbLed.PinBlue = red;
            }
            Console.WriteLine("Red: {0}, Green: {1}, Blue: {2}", _rgbLed.PinRed, _rgbLed.PinGreen, _rgbLed.PinBlue);
            return true;
        }

        public bool AllOff()
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            _rgbLed.AllOff();
            return true;
        }

        public bool AllOn()
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            _rgbLed.AllOn();
            return true;
        }

        public bool ColorFlash(int ms)
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            _rgbLed.Colorflash(ms);
            return true;
        }

        public bool ColorFade(int ms)
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            _rgbLed.Colorfade(ms);
            return true;
        }

        public bool SetHtmlColor(string htmlColor)
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            try
            {
                _rgbLed.SetColor(htmlColor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                AllOff();
            }
            return true;
        }

        public bool SetColorMode(int mode)
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            _rgbLed.CurrentMode = (RGBLed.ColorChangeMode)mode;
            return true;
        }

        public bool SetRgbColor(int r, int g, int b)
        {
            if (_rgbLed == null) throw new InvalidOperationException("Not initialized. Call SetPorts(r,g,b) first.");
            _rgbLed.SetColor(r, g, b);
            return true;
        }

        public string GetHTMLColor()
        {
            return ColorTranslator.ToHtml(_rgbLed.CurrentColor);
        }

        public bool Strobe(int ms)
        {
            _rgbLed.Strobe(ms);
            return true;
        }

        public bool ColorStrobe(int ms)
        {
            _rgbLed.Colorstrobe(ms);
            return true;
        }
    }
}
