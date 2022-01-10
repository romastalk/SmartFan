using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroykaCap;
using TroykaCap.Expander;
using TroykaCap.Expander.Extensions;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace ThridTry
{
    public class Fan
    {
        public void SendVent(double speed)
        {
            Pi.Init<BootstrapWiringPi>();
            GpioExpander expander = Pi.I2C.GetGpioExpander();
            expander.AnalogWriteDouble(GpioExpanderPin.Pin0, speed);
        }

    }
}
