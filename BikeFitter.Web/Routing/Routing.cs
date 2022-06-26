namespace BikeFitter.Web.Routing
{
    public class Routes
    {
        public static string Brakes = "brakes";
        public static string BrakesParam(int p) => $"{Brakes}/{p}";

        public static string Cassettes = "cassettes";
        public static string CassettesParam(int p) => $"{Cassettes}/{p}";

        public static string Cranksets = "cranksets";
        public static string CranksetsParam(int p) => $"{Cranksets}/{p}";
    }
}
