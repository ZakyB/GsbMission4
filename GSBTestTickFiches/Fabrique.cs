namespace GSBTickFiches
{
    class Fabrique
    {
        private static string providerMysql = "127.0.0.1";

        private static string dataBaseMysql = "gsb";

        private static string uidMysql = "root";

        private static string mdpMysql = "";

        public static string ProviderMysql { get => providerMysql; }
        public static string DataBaseMysql { get => dataBaseMysql; }
        public static string UidMysql { get => uidMysql; }
        public static string MdpMysql { get => mdpMysql; }
    }
}
