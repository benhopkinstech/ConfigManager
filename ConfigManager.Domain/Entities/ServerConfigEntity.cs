namespace ConfigManager.Domain.Entities;

public class ServerConfigEntity
{
    public string Server { get; set; } = default!;

    public List<ConfigEntity> Config { get; set; } = new();
}

