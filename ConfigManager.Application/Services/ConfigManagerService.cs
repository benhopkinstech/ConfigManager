using ConfigManager.Application.Interfaces;
using ConfigManager.Domain.Entities;

namespace ConfigManager.Application.Services;

public class ConfigManagerService : IConfigManagerService
{
    public List<ServerConfigEntity> LoadConfig(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        var serverConfigs = new List<ServerConfigEntity>();

        foreach (var line in lines)
        {
        }

        return serverConfigs;
    }
}
