using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBTickFiches
{
    class Fabrique
    {
        private static string providerMysql = "localhost";

        private static string dataBaseMysql = "gsb";

        private static string uidMysql = "root";

        private static string mdpMysql = "root";

        public static string ProviderMysql { get => providerMysql; }
        public static string DataBaseMysql { get => dataBaseMysql; }
        public static string UidMysql { get => uidMysql; }
        public static string MdpMysql { get => mdpMysql; }
    }
}
