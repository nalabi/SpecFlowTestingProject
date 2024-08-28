using System.Text;

namespace SpecFlowTestingProject.Methods
{
    public class Randomer
    {
        public static string GenerateRandomEmail()
        {
            StringBuilder sb = new StringBuilder();
            string randUser = "abcdefghijklmnopqrstuvwxyz1234567890";
            Random rand = new Random();
            int length = 10; // Random username length

            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(randUser.Length);
                char randomChar = randUser[index];
                sb.Append(randomChar);
            }

            // Append a domain to the random username
            sb.Append("@hotterRT.com");

            return sb.ToString();
        }


        public static string GenerateRandomUser()
        {
            StringBuilder sb  = new StringBuilder();
            string randUser = "abcdefghijklmnopqrstuvwxyz1234567890";
            Random rand = new Random();
            int length = 10; // Random username length

            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(randUser.Length);
                char randomChar = randUser[index];
                sb.Append(randomChar);
            }

       

            return sb.ToString();
        }
    }
}
