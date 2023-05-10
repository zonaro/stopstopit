

namespace StopstopIt
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ProcessChecker.IsOnlyProcess("Program Window Text"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationConfiguration.Initialize(); 
                Application.Run(new Form1());
            }
        
        }
    }
}