using System;
using System.Windows.Forms;
using Autofac;

namespace SySTarjetas.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<FormIoCModule>();

            var container = builder.Build();

            var main = new MainTarjetas { IoCContainer = container };

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(main);
        }
    }
    
}
