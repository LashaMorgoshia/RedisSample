// See https://aka.ms/new-console-template for more information
using ServiceStack.Redis;

public class Program
{
    public static void Main()
    {
        SaveData("localhost", "test", "demoValue");

        Console.WriteLine(GetData("localhost", "test"));

        Console.ReadLine();
    }


    private static void SaveData(string host, string key, string value)
    {
        using (RedisClient client = new RedisClient(host))
        {
            if (client.Get(key) == null)
                client.Set(key, value);
        }
    }

    private static string GetData(string host, string key)
    {
        using (RedisClient client = new RedisClient(host))
        {
            return client.Get<string>(key);
        }
    }
}