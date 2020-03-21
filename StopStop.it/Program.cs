using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopStop.it
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (ProcessChecker.IsOnlyProcess("Program Window Text"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }

    class LockIt
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern void LockWorkStation();
    }
}
