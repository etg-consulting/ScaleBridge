using System.Windows.Forms;
using Windows.Media.Devices;

namespace ETG.ScaleBridge;
public partial class FormSettings : Form
{
    public FormSettings()
    {
        InitializeComponent();
        ETG.ScaleBridge.Scale.OnDeviceListChanged += Scale_OnDeviceListChanged;
        ETG.ScaleBridge.Scale.OnDeviceRead += Scale_OnDeviceRead;
    }

    private void FormSettings_Load(object sender, EventArgs e)
    {
        txtDevice.Text = ETG.ScaleBridge.Scale.CurrentDevice;
        txtStaus.Text = ETG.ScaleBridge.Scale.Status;
        txtWeight.Text = ETG.ScaleBridge.Scale.Weight.ToString();
        txtUnit.Text = ETG.ScaleBridge.Scale.Unit;
    }


    private void Scale_OnDeviceRead(object? sender, EventArgs e)
    {
        if (IsHandleCreated)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txtStaus.Text = ETG.ScaleBridge.Scale.Status;
                txtWeight.Text = ETG.ScaleBridge.Scale.Weight.ToString();
                txtUnit.Text = ETG.ScaleBridge.Scale.Unit;
            }));
        }
    }
    private void Scale_OnDeviceListChanged(object? sender, EventArgs e)
    {
        if (IsHandleCreated)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txtDevice.Text = ETG.ScaleBridge.Scale.CurrentDevice;
                txtStaus.Text = ETG.ScaleBridge.Scale.Status;
                txtWeight.Text = ETG.ScaleBridge.Scale.Weight.ToString();
                txtUnit.Text = ETG.ScaleBridge.Scale.Unit;
            }));
        }
    }

    private void BtnSelect_Click(object sender, EventArgs e)
    {
        var frm = new FormSelectDevice();
        frm.ShowDialog();
    }

    private void FormSettings_VisibleChanged(object sender, EventArgs e)
    {
        Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}