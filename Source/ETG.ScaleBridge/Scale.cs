using HidSharp;
using HidSharp.DeviceHelpers;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;

namespace ETG.ScaleBridge
{
    internal static class Scale
    {
        private static HidDevice? currentDevice;
        private static HidStream? currentStream;
        private static HidScale.Status status;
        private static HidScale.Unit unit;
        private static decimal weight;
        public static event EventHandler? OnDeviceListChanged;
        public static event EventHandler? OnDeviceRead;
        static Scale()
        {
            DeviceList.Local.Changed += DeviceList_Changed;
            OpenDevice();
        }

        private static void CurrentStream_Closed(object? sender, EventArgs e)
        {
            OpenDevice();
        }

        public static void SelectDevice(int vendorId, int productId)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ETG\ScaleBridge"))
            {
                key.SetValue("VendorID", vendorId, RegistryValueKind.DWord);
                key.SetValue("ProductID", productId, RegistryValueKind.DWord);
            }

            OpenDevice();
        }

        private static void OpenDevice()
        {
            int vendorId;
            int productId;

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ETG\ScaleBridge"))
            {
                vendorId = (int)(key.GetValue("VendorID", 0) ?? 0);
                productId = (int)(key.GetValue("ProductID", 0) ?? 0);
            }

            currentDevice = DeviceList.Local.GetHidDevices(vendorId, productId).FirstOrDefault();
            status = 0;
            unit = 0;
            weight = 0;
            
            if (currentDevice != null)
            {
                if (currentStream != null)
                {
                    currentStream.Closed -= CurrentStream_Closed;
                }

                currentDevice.TryOpen(out currentStream);
                currentStream.Closed += CurrentStream_Closed;
            }
            OnDeviceListChanged?.Invoke(null, new());
        }

        private static void DeviceList_Changed(object? sender, DeviceListChangedEventArgs e)
        {
            OpenDevice();
        }

        public static string CurrentDevice
        {
            get
            {
                if (currentDevice == null)
                {
                    return "";
                }
                else
                {
                    return currentDevice.GetFriendlyName();
                }
            }
        }
        public static bool IsConnected { get { return CurrentDevice != ""; } }

        public static decimal Weight { get { return weight; } }
        public static string Status { get { return HidScale.GetNameFromStatus(status); } }
        public static string Unit { get { return HidScale.GetNameFromUnit(unit); } }

        public static BindingList<HidDevice> Devices {
            get {
                var result = new BindingList<HidDevice>();

                foreach (var hidDevice in DeviceList.Local.GetHidDevices())
                {
                    if (hidDevice.GetTopLevelUsage() == 0x8D0020) //Get only "Weight Scale" type of devices
                    {
                        result.Add(hidDevice);
                    }
                }
                return result;
            }
        }

        public static void ReadFromDevice()
        {
            if (IsConnected)
            {
                var scaleReader = new HidScale(currentStream);

                try
                {
                    scaleReader.ReadSample(out int value, out int exponent, out unit, out status, out bool buffered);

                    if (exponent < 0)
                    {
                        weight = (decimal)value / (int)Math.Pow(10,Math.Abs(exponent));
                    }
                    else
                    {
                        weight = (decimal)value * (int)Math.Pow(10, Math.Abs(exponent));
                    }

                    Debug.Print("{0}: {1} {2}", Status, Weight,Unit);

                    if (!buffered)
                    {
                        OnDeviceRead?.Invoke(null, new());
                    }
                } catch { }
            }
        }
    }
}
