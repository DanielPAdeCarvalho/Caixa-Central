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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfR11mSH1SdUBmWHtXeQ==;Mgo+DSMBPh8sVXJ1S0R+X1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jTH5Wd0ZiWnpbcXJQTw==;ORg4AjUWIQA/Gnt2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtTc0RgWHxbdXVdRGk=;MTkzODAxNUAzMjMxMmUzMjJlMzNCNmJ6d2NhcitCUjlaRVVvdmdhMUV4V3NzcVBwMDBucVlkWXRYcmdMcks0PQ==;MTkzODAxNkAzMjMxMmUzMjJlMzNIZW9jNWtVdG9uQ0RkSTY0bk95bWdZYlNLWmNRd1dBYUQwaVBsOUVQY1dvPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5WdkBiWn5ddXFXQWBV;MTkzODAxOEAzMjMxMmUzMjJlMzNsS2k3WEhZSVdvNUlyTk4zNmJGeDNUeXNFcmYwUlNRK1lxdlJZa1lMMUYwPQ==;MTkzODAxOUAzMjMxMmUzMjJlMzNRRUxkdlJVb3JzcTJ4amZWeHU2Qjc1VnBBeW1nL1Z1TGM5dWNrTkwwL29vPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtTc0RgWHxbdXdQQmM=;MTkzODAyMUAzMjMxMmUzMjJlMzNpZ3F6M21VdkhjRjlPbDRVaC9PbXZlb0Y4V1hpOHdta2l0QitkSkJxdFpFPQ==;MTkzODAyMkAzMjMxMmUzMjJlMzNUU2kzTjF2d2VMcHpVWDIzWjd4bFVQcEVyRDRQaFJaR0VMbW90eVVVUXh3PQ==;MTkzODAyM0AzMjMxMmUzMjJlMzNsS2k3WEhZSVdvNUlyTk4zNmJGeDNUeXNFcmYwUlNRK1lxdlJZa1lMMUYwPQ==");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Metodo padrão, substituir por esse quando for para produção
            //Application.Run(new Login());

            //Entra direto na janela de teste para não dar trabalho de logar toda vida
            Application.Run(new JanelaCentral("===Testes==="));
        }
    }
}