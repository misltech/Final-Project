using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Pi_Quartos
{
    public sealed partial class MainPage : Page
    {
        Sensor sensor1 = new Sensor(5);
        LED led1 = new LED(6);
       
        public MainPage()
        {
            this.InitializeComponent();

            if (sensor1.active())
            {
                sensor1.Start();
            }

            //qmrservice.qmrserviceSoapClient client = new qmrservice.qmrserviceSoapClient();

            //client.AddRoomAsync("testroom");

            //qmrservice.GetListRoomsResponse g = await client.GetListRoomsAsync();
            //Motion();
            Test();
        }

        private async void Test()
        {
            qmrservice.qmrserviceSoapClient client = new qmrservice.qmrserviceSoapClient();

            qmrservice.GetListRoomsResponse g = await client.GetListRoomsAsync();

            
        }
        //public void Motion()
        //{

        //    sensor1.Detected();
        //    if (motionDetected == true)
        //    {
        //        led1.Led_On();
        //    }
        //    else
        //        led1.Led_Off();
        //}
 
    }
}
