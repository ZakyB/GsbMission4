﻿namespace GSBTickFiches
{
    class Fabrique
    {
        // Informations de connexion de la base de données
        private static string providerMysql = "localhost";

        private static string dataBaseMysql = "gsb";

        private static string uidMysql = "root";

        private static string mdpMysql = "";

        public static string ProviderMysql { get => providerMysql; }
        public static string DataBaseMysql { get => dataBaseMysql; }
        public static string UidMysql { get => uidMysql; }
        public static string MdpMysql { get => mdpMysql; }
    }
}
