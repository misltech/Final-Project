using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Pi_Quartos
{
    class LED
    {
        private GpioPin _pin2;
        private int _LED_PIN;

        public LED(int LEDPIN)
        {
            
            _LED_PIN = LEDPIN;
            var gpio = GpioController.GetDefault();
            _pin2 = gpio.OpenPin(_LED_PIN);
            _pin2.SetDriveMode(GpioPinDriveMode.Output);
        }
        public void Led_On()
        {
           
            _pin2.Write(GpioPinValue.Low);
        }
        public void Led_Off()
        {
            _pin2.Write(GpioPinValue.High);
        }
    }
}

    

