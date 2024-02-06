namespace ConfigManager.Domain.Entities;

public class ServerConfigEntity
{
    public string Server { get; set; } = default!;
    
    public ConfigEntity Config { get; set; } = default!;
}

