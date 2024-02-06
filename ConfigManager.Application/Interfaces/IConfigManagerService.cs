using ConfigManager.Domain.Entities;

namespace ConfigManager.Application.Interfaces;

public interface IConfigManagerService
{
    List<ServerEntity> LoadConfig(string filePath);
}
