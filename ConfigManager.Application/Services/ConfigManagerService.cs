using ConfigManager.Application.Interfaces;
using ConfigManager.Domain.Entities;

namespace ConfigManager.Application.Services;

public class ConfigManagerService : IConfigManagerService
{
    public List<ServerEntity> LoadConfig(string filePath)
    {
        throw new NotImplementedException();
    }
}
