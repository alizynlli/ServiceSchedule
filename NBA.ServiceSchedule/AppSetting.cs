using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Constants;
using NBA.ServiceSchedule.Core.Global;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NBA.ServiceSchedule
{
    public static class AppSetting
    {
        private const string ConnStringName = "ConnectionString";
        private const string SaleInvoiceSeries = "SaleInvoiceSeries";

        public static void Initialize()
        {
            GlobalParameters.ConnectionString = GetConnectionString();
            GlobalParameters.DatabaseName = new SqlConnectionStringBuilder(GlobalParameters.ConnectionString).InitialCatalog;

            var appSettings = ConfigurationManager.AppSettings;
            GlobalParameters.SaleInvoiceSeries = Convert.ToString(appSettings[SaleInvoiceSeries]);

            PermissionKeys.Keys.Clear();
            PermissionKeys.FillKeys(typeof(PermissionKeys));
        }

        public static Task<ActionResult> SaveConnectionString(string conString, string key = ConnStringName)
        {
            return Task.Run(() =>
            {
                try
                {
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings[key].ConnectionString = conString;
                    config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    GlobalParameters.ConnectionString = GetConnectionString(key);

                    return ActionResult.Succeed();
                }
                catch (ConfigurationErrorsException)
                {
                    return ActionResult.Failed("Konfiqurasiya faylına müraciət uğursuzdur. Zəhmət olmasa, proqramı idarəçi rejimində çalışdırın.");
                }
                catch (Exception e)
                {
                    return ActionResult.Failed(e.GetType() + " " + e);
                }
            });
        }

        public static void SaveSaleInvoiceSeries(string series)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = config.AppSettings;
            appSettings.Settings[SaleInvoiceSeries].Value = series;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private static string GetConnectionString(string key = ConnStringName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
    }
}
