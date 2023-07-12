using HidSharp;

namespace ETG.ScaleBridge;
public partial class FormSelectDevice : Form
{
    public FormSelectDevice()
    {
        InitializeComponent();

        ETG.ScaleBridge.Scale.OnDeviceListChanged += Scale_OnDeviceListChanged;
    }

    private void FormSelectDevice_Load(object sender, EventArgs e)
    {
        listDevices.DataSource = ETG.ScaleBridge.Scale.Devices;
        frmSelect.Enabled = listDevices.Items.Count > 0;
    }

    private void Scale_OnDeviceListChanged(object? sender, EventArgs e)
    {
        if (IsHandleCreated)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                listDevices.DataSource = ETG.ScaleBridge.Scale.Devices;
                frmSelect.Enabled = ETG.ScaleBridge.Scale.Devices.Count > 0;
            }));
        }
    }

    private void FrmSelect_Click(object sender, EventArgs e)
    {
        if (listDevices.SelectedItem != null)
        {
            var device = (HidDevice)listDevices.SelectedItem;

            ETG.ScaleBridge.Scale.SelectDevice(device.VendorID, device.ProductID);
        }

        Close();
    }

    private void FrmClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}