using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Pi_Quartos
{
    class Sensor
    {
        //few important datatypes
        private int _SENSOR_PIN;
        private GpioPin _pin;
        private GpioPinValue _pinValue;
        //private LED _led1 = new LED(6);
        //private LED _led2 = new LED(21);
        private bool _sensorstatus;
        private Boolean _occupied;
        //qmrservice.qmrserviceSoap client = new qmrservice.qmrserviceSoap();
        //qmrservice.qmrserviceSoapClient tes = new qmrservice.qmrserviceSoapClient();
        
            
            
            //Constructor 
        public Sensor(int SensorPin)
        {
            var gpio = GpioController.GetDefault();
            _SENSOR_PIN = SensorPin;
            _pin = gpio.OpenPin(_SENSOR_PIN);
            _pin.SetDriveMode(GpioPinDriveMode.Input);

        }
        //Check to see if sensor port is giving out a reading
        public bool active()
        {
            if (_pin == null)
            {
                return false;
            }
            else
                return true;
        }

        //Starts listening for changes in sensor
        public void Start()
        {
            _pin.DebounceTimeout = TimeSpan.FromSeconds(1);
            _pin.ValueChanged += SensorValueChanged;
          
        }


        //Handles LED light on movement
        private void SensorValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            _pinValue = _pin.Read();
            if (_pinValue == GpioPinValue.High)
            {
                //_led2.Led_On();
                //check current state
                if (!_occupied)
                {
                    //write to database that the room is reserved
                    _occupied = true;
                }
                else
                {
                    //_led1.Led_Off();
                    //if (_occupied)
                    //{
                    //    //write to database that room is not active
                    //    _occupied = false;
                    //}
                }

            }
        }
    }
}
// **************************************BETA May or May not work***********************************************

//if (args.Edge == GpioPinEdge.RisingEdge)
//{
//    _pinValue = _pin.Read();
//    _motion = true;
//   // _led1.Led_On();
//}
//else if (args.Edge == GpioPinEdge.FallingEdge)
//{
//    _pinValue = _pin.Read();
//    _motion = false;
// _led1.Led_Off();