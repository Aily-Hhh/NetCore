namespace Task_1
{
    public class Product
    {
        public float price;

        public static float operator +(Product a, Product b)
        {
            return a.price + b.price;
        }
    }
}
