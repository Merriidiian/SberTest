using System.Net;

namespace TestSber;

public class IpAddressesParser : IIpAddressesParser
{
    /// <summary>
    /// Returns parsed list of ip addresses
    /// </summary>
    /// <param name="raw">raw list of ip addresses</param>
    /// <param name="separator">ip addresses separator</param>
    /// <returns>List of ip addresses</returns>
    /// <exception cref="ArgumentNullException">Thrown when raw or separator param is null</exception>
    /// <exception cref="ArgumentException">Thrown when separator param is empty string</exception>
    /// <exception cref="FormatException">Thrown when ip address is invalid</exception>
    public IReadOnlyCollection<IPAddress> Parse(string raw, string separator)
    {
        if (raw == null)
            throw new ArgumentNullException(nameof(raw), "Raw param is null");
        switch (separator)
        {
            case null:
                throw new ArgumentNullException(nameof(separator), "Separator param is null");
            case "":
                throw new ArgumentException("Separator param is empty string", nameof(separator));
        }
        var ipAddressArray = raw.Split(separator);
        var resultIpAddressList = new List<IPAddress>();
        foreach (var ipAddressString in ipAddressArray)
        {
            if (!IPAddress.TryParse(ipAddressString, out var ipAddress))
                throw new FormatException($"Ip address '{ipAddressString}' is invalid");
            resultIpAddressList.Add(ipAddress);
        }
        return resultIpAddressList.AsReadOnly();
    }
}