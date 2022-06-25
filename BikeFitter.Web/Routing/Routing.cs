namespace BikeFitter.Web.Routing
{
    public class Routes
    {
        public static string Brakes = "brakes";
        public static string BrakesParam(int p) => $"{Brakes}/{p}";
    }
}
