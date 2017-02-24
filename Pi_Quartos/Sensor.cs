using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;

namespace Pi_Quartos
{
    class Sensor
    {
        //few important datatypes
        private int _SENSOR_PIN;
        private GpioPin _pin;
        private GpioPinValue _pinValue;
        private LED _led1 = new LED(6);
        private bool _sensorstatus;
        private bool _occupied;
        private int _counting;


        DispatcherTimer _timer;
        //qmrservice.qmrserviceSoap client = new qmrservice.qmrserviceSoap();
        //qmrservice.qmrserviceSoapClient tes = new qmrservice.qmrserviceSoapClient();



        //Constructor 
        public Sensor(int SensorPin)
        {
            var gpio = GpioController.GetDefault();
            _SENSOR_PIN = SensorPin;
            _pin = gpio.OpenPin(_SENSOR_PIN);
            _pin.SetDriveMode(GpioPinDriveMode.Input);
            _timer.Interval = TimeSpan.FromMinutes(1);
            _timer.Tick += count;

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
            //TODO: **RIGHT HERE**check database on its status{reserved or not} set _occupied accordingly
            //_occupied=database;
        }

        //Starts listening for changes in sensor
        public void Start()
        {
            _pin.DebounceTimeout = TimeSpan.FromSeconds(1); //EverySecond
            _pin.ValueChanged += SensorValueChanged;

        }


        //Handles LED light on movement{database writing}
        private void SensorValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            _pinValue = _pin.Read();
            if (_pinValue == GpioPinValue.High) //check current state
            {
                _led1.Led_On();
                if (!_occupied)
                {

                    //write to database that the room is reserved
                    _occupied = true;
                    _timer.Stop();
                    _counting = 1;
                }
            }
            else
            {
                //Complications, when pi gets database value here {if raspi goes down}
                _led1.Led_Off();
                if (_occupied)
                {
                    //write to database that room is not active
                    _occupied = false;
                    _timer.Start();
                }
            }
        }

        public void count(object sender, object e)
        {
            _counting = 1;

            while (_counting != 0)
            {
                _counting++;
            }

            if (_counting == 11)
            {
                //unreserve room from database
                _occupied = false; //set occupied to false
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