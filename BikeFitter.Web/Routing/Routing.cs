namespace BikeFitter.Web.Routing
{
    public class Routes
    {
        public static string Bikes = "bikes";
        public static string BikesParam(int p) => $"{Bikes}/{p}";

        public static string Brakes = "brakes";
        public static string BrakesParam(int p) => $"{Brakes}/{p}";

        public static string Cassettes = "cassettes";
        public static string CassettesParam(int p) => $"{Cassettes}/{p}";

        public static string Cranksets = "cranksets";
        public static string CranksetsParam(int p) => $"{Cranksets}/{p}";

        public static string Derailleurs = "derailleurs";
        public static string DerailleursParam(int p) => $"{Derailleurs}/{p}";

        public static string Forks = "forks";
        public static string ForksParam(int p) => $"{Forks}/{p}";

        public static string Manufacturers = "manufacturers";
        public static string ManufacturersParam(int p) => $"{Manufacturers}/{p}";

        public static string Rims = "rims";
        public static string RimsParam(int p) => $"{Rims}/{p}";

        public static string Shifters = "shifters";
        public static string ShiftersParam(int p) => $"{Shifters}/{p}";

        public static string Stems = "stems";
        public static string StemsParam(int p) => $"{Stems}/{p}";

        public static string Tires = "tires";
        public static string TiresParam(int p) => $"{Tires}/{p}";
    }
}
