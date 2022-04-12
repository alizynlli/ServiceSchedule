using NBA.ServiceSchedule.Forms;
using System;
using System.Windows.Forms;

namespace NBA.ServiceSchedule
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppSetting.Initialize();
                Application.Run(new LoginForm());
                //Application.Run(new TestForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
