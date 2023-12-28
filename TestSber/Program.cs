using TestSber;

/*1) Тестовый случай, когда входные параметры не равны null и не пустые. raw = "192.168.0.1,192.168.0.2,192.168.0.3", separator = ","
Ожидаемый результат: 
192.168.0.1
192.168.0.2
192.168.0.3.

2) Тестовый случай, когда raw равен null, а separator не равен null. raw = null, separator = ","
Ожидаемый результат: System.ArgumentNullException : Raw param is null (Parameter 'raw')

3) Тестовый случай, когда raw не равен null, а separator равен null. raw = "192.168.0.1,192.168.0.2,192.168.0.3", separator = null
Ожидаемый результат: Separator param is null (Parameter 'separator')

4) Тестовый случай, когда raw не равен null, а separator равен пустой строке. raw = "192.168.0.1,192.168.0.2,192.168.0.3", separator = ""
Ожидаемый результат: System.ArgumentException : Separator param is empty string (Parameter 'separator')

5) Тестовый случай, когда raw равен пустой строке, а separator не равен null. raw = "", separator = ","
Ожидаемый результат: System.FormatException : Ip address  is invalid
.
6) Тестовый случай, когда raw равен "192.168.0.1" и separator не равен null. raw = "192.168.0.1", separator = ","
Ожидаемый результат: 192.168.0.1

7) Тестовый случай, когда raw содержит некорректный IP-адрес. raw = "192.168.0.1,test", separator = ","
Ожидаемый результат: System.FormatException : Ip address 'test' is invalid
*/
static class Program
{
    public static void Main(string[] args)
    {
        var numberTest = 1;
        Test("192.168.0.1,192.168.0.2,192.168.0.3", ",");
        Test(null, ",");
        Test("192.168.0.1,192.168.0.2,192.168.0.3", null);
        Test("192.168.0.1,192.168.0.2,192.168.0.3", "");
        Test("", ",");
        Test( "192.168.0.1", ",");
        Test("192.168.0.1,test", ",");
    }

    private static void Test(string raw, string separator)
    {
        var ipAddressesParser = new IpAddressesParser();
        try
        {
            var test = ipAddressesParser.Parse(raw, separator);
            test.ToList().ForEach(Console.WriteLine);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.GetType()} : {e.Message}");
        }
        finally
        {
            Console.WriteLine();
        }
    }
}