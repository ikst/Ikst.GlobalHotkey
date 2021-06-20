# Ikst.GlobalHotkey
Global Hotkey library for .net windows applications.
Shortcut keys can be used to trigger actions even when the application is inactive.

## usage
Create a GlobalHotkey instance and use the Regist method to register the action to be taken when the hotkey is pressed.

The arguments are the numerical value of the virtual key and the action delegate.
Note that the virtual key is a Win32 virtual key.
https://docs.microsoft.com/ja-jp/windows/win32/inputdev/virtual-key-codes?redirectedfrom=MSDN

```C#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Ikst.GlobalHotkey.GlobalHotkey gh = new Ikst.GlobalHotkey.GlobalHotkey();

        gh.Regist((int)(ModifierKeys.Control | ModifierKeys.Shift), KeyInterop.VirtualKeyFromKey(Key.Q), () => MessageBox.Show("Ctrl+Shift+Q"));
        gh.Regist(12, 0x51, () => MessageBox.Show("Win+shift+Q"));

    }
}
```

## nuget
https://www.nuget.org/packages/Ikst.GlobalHotkey/
