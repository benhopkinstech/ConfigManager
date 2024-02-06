namespace ConfigManager.Domain.Entities;

public class ConfigEntity
{
    public string ServerName { get; set; } = default!;

    public string Url { get; set; } = default!;

    public string Db { get; set; } = default!;

    public string IpAddress { get; set; } = default!;

    public string Domain { get; set; } = default!;

    public string CookieDomain { get; set; } = default!;
}