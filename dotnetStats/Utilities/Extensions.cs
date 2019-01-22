namespace dotnetStats.Utilities
{
    public static class Extensions
    {
        public static double Factorial(this int n)
        {
            for (int i = 1; i <= n; i--)
            {
                n = n * i;
            }

            return n;
        }
    }
}
