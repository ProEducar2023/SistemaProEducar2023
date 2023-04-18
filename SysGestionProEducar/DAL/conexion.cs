using System.Configuration;
namespace DAL
{
    public class conexion
    {
        public static string _sql;
        public static string _sqlGestion;
        private static string user = "raton";
        private static string password = "main";
        public static string con
        {
            //get { return @"server=WIND8; Database=BD_GCO03; User Id=miguel; Password=main"; }
            //get { return @"server=TOSHIBA-PC; Database=BD_GCO03; User Id=miguel; Password=main"; }//el servidor de laptop
            //get { return @"server=SERVER-MG; Database=BD_GCO03; User Id=miguel; Password=main"; }//el servidor
            get { return @"server=TEACHER04; Database=BD_GCO05; Integrated Security=Yes"; }//servidor AES
            //get { return ConfigurationManager.ConnectionStrings["Presentacion.Properties.Settings.BD_GCO03ConnectionString"].ConnectionString; }
        }
        public static string con2
        {
            //get { return @"server=WIND8; Database=BD_GENERAL_COI; User Id=miguel; Password=main"; }
            //get { return @"server=TOSHIBA-PC; Database=BD_GENERAL_COI; User Id=miguel; Password=main"; }//el servidor de laptop
            //get { return @"server=SERVER-MG; Database=BD_GENERAL_COI; User Id=miguel; Password=main"; }//el servidor
            get { return @"server=TEACHER04; Database=BD_GENERAL_COI; Integrated Security=Yes"; }//servidor AES
            //get { return ConfigurationManager.ConnectionStrings["Presentacion.Properties.Settings.BD_GENERAL_COIConnectionString"].ConnectionString; }
        }
        //ESTO ES UN COMENTARIO
        //public static string con2
        //{
        //    get
        //    {
        //        if (_sql == null)
        //        {
        //            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        //            ConfigurationSectionGroup userSetting = config.GetSectionGroup("userSettings");
        //            ClientSettingsSection settings = (ClientSettingsSection)userSetting.Sections.Get(0);
        //            SettingElement srvElem = settings.Settings.Get("SERVIDOR");
        //            string ServerName = string.Empty;
        //            if (srvElem != null)
        //                ServerName = srvElem.Value.ValueXml.InnerText;

        //            _sql = string.Format("Data Source={0};Initial Catalog=BD_GENERAL_COI;User={1};password={2}", ServerName, user, password);
        //            //_sql = string.Format("Data Source={0};Initial Catalog=BD_GENERAL_COI;Integrated Security = True", ServerName);
        //        }
        //        return _sql;
        //    }
        //}
        //public static string con
        //{
        //    get
        //    {
        //        if (_sqlGestion == null)
        //        {
        //            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        //            ConfigurationSectionGroup userSetting = config.GetSectionGroup("userSettings");
        //            ClientSettingsSection settings = (ClientSettingsSection)userSetting.Sections.Get(0);
        //            SettingElement srvElem = settings.Settings.Get("SERVIDOR");
        //            SettingElement bdElem = settings.Settings.Get("BD_COD");
        //            string BdCod = string.Empty;
        //            string ServerName = string.Empty;
        //            if (srvElem != null)
        //                ServerName = srvElem.Value.ValueXml.InnerText;
        //            if (bdElem != null)
        //                BdCod = bdElem.Value.ValueXml.InnerText;

        //            _sqlGestion = string.Format("Data Source={0};Initial Catalog=BD_GCO{1};User={2};password={3}", ServerName, BdCod, user, password);
        //        }
        //        return _sqlGestion;
        //    }
        //}
    }
}

