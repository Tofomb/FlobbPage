namespace FlobbPage.Models
{
    public sealed class Utils 

    {
        private Utils() { } 



        public static string Fever(double temp)
        {
            if (temp > 37.8)
                return "Har feber";
            else
                return "Har inte feber";
        }
    }
}
