namespace ETG.ScaleBridge;

public class Tray : ApplicationContext
{
    private readonly NotifyIcon notifyIcon;
    private readonly FormSettings formSettings;
    private readonly ContextMenuStrip contextMenu;
    private readonly ToolStripMenuItem menuItemSettings;
    private readonly ToolStripMenuItem menuItemExit;
    public Tray()
    {
        menuItemSettings = new ToolStripMenuItem()
        {
            Text = "Settings",
        };
        menuItemSettings.Click += MenuItemSettings_Click;

        menuItemExit = new ToolStripMenuItem()
        {
            Text = "Exit",
        };
        menuItemExit.Click += MenuItemExit_Click;

        contextMenu = new ContextMenuStrip();
        contextMenu.Items.AddRange(new ToolStripMenuItem[] { menuItemSettings, menuItemExit });

        notifyIcon = new NotifyIcon()
        {
            ContextMenuStrip = contextMenu,
            Icon = GetNotifyIcon(),
            Text = "Scale Bridge",
            Visible = true,
        };
        notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

        formSettings = new FormSettings();

        Scale.OnDeviceListChanged += Scale_OnDeviceListChanged;
    }

    private void Scale_OnDeviceListChanged(object? sender, EventArgs e)
    {
        notifyIcon.Icon = GetNotifyIcon();
    }

    private static Icon GetNotifyIcon()
    {
        if (Scale.IsConnected)
        {
            return Properties.Resources.TrayIconOn;
        }
        else
        {
            return Properties.Resources.TrayIconOff;
        }
    }

    private void ShowSettingsForm()
    {
        if (formSettings.Visible == false)
        {
            formSettings.ShowDialog();
        }
    }

    private void MenuItemExit_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void MenuItemSettings_Click(object? sender, EventArgs e)
    {
        ShowSettingsForm();
    }

    private void NotifyIcon_DoubleClick(object? Sender, EventArgs e)
    {
        ShowSettingsForm();
    }
}
