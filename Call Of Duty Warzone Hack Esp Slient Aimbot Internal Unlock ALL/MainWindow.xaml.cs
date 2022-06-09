using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoDExtHack
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Calling AllocConsole(); from NativeMethods.cs 
            Calling_Native_Methods.NativeMethods.AllocConsole();

            // If the build has been executed correctly show up welcome message.
            ConsoleMethods.setConsole.WriteLine(ConsoleColor.Green, "CoD Ext Hack Initialized...");
            ConsoleMethods.setConsole.WriteLine(ConsoleColor.Yellow, "Please, run your game in borderless or windowed mode.");

            // Hook call of duty 4 game window. 
            HookMethods.Hook.HookWindow();
        }
    }
}
