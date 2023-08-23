namespace Caixa_Central
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF5cXmRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXhed3VRRWZdWEBxWEQ=");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");

            //Metodo padrão, substituir por esse quando for para produção
            //Application.Run(new Login());

            //Entra direto na janela de teste para não dar trabalho de logar toda vida
            Application.Run(new JanelaCentral("===Testes==="));
        }
    }
}