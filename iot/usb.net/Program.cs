using System;
using LibUsbDotNet.DeviceNotify;
using LibUsbDotNet.DeviceNotify.Linux;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello USB!");
            LibUsbDotNet.DeviceNotify.IDeviceNotifier sama5d2 = new LinuxDeviceNotifier
            {
                Enabled = true
            };
            sama5d2.OnDeviceNotify += OnDeviceNotify;
        }

        private static void OnDeviceNotify(object sender, DeviceNotifyEventArgs e)
        {
            Console.WriteLine($"Insert USB dev: Pid {e.Device.IdProduct} vid {e.Device.IdVendor}");
        }
    }
}
