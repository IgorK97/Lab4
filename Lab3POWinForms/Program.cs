using Interfaces.Services;
using Lab4POWinForms.Util;
using Ninject;

namespace Lab3POWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("dbPizzaDelivery"));
            IOrderLineService ols = kernel.Get<IOrderLineService>();
            IOrderService os = kernel.Get<IOrderService>();
            IReportService report = kernel.Get<IReportService>();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(ols,os,report));
        }
    }
}