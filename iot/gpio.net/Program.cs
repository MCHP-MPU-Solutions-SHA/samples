using System;
using System.Device.Gpio;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int pin1 = 6, pin2 = 7;
            using var gpio = new GpioController(PinNumberingScheme.Logical);
            gpio.OpenPin(pin1, PinMode.Output);
            gpio.OpenPin(pin2, PinMode.Output);
            var flag = false;
            while (true)
            {
                var pv1 = flag ? PinValue.High : PinValue.Low;
                var pv2 = !flag ? PinValue.High : PinValue.Low;
                flag = !flag;

                gpio.Write(pin1, pv1);
                gpio.Write(pin2, pv2);
                Thread.Sleep(500);
            }
        }
    }
}