namespace ConfigManager.Domain.Entities;

public class ServerEntity
{
    public string Server { get; set; } = default!;
    
    public ConfigEntity Config { get; set; } = default!;
}

