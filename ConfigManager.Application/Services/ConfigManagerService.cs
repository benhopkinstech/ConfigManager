using ConfigManager.Application.Interfaces;
using ConfigManager.Domain.Entities;

namespace ConfigManager.Application.Services;

public class ConfigManagerService : IConfigManagerService
{
    private const string StartPrefix = ";START";
    private const string EndPrefix = ";END";
    private const char SpaceCharacter = ' ';
    private const char OpeningBraceCharacter = '{';
    private const char EqualsCharacter = '=';

    public List<ServerConfigEntity> LoadConfig(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        var serverConfigs = new List<ServerConfigEntity>();
        ServerConfigEntity? currentServerConfig = null;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (line.StartsWith(StartPrefix))
            {
                currentServerConfig = new ServerConfigEntity();
                currentServerConfig.Server = line.Substring(line.IndexOf(SpaceCharacter) + 1);
            }
            else if (line.StartsWith(EndPrefix))
            {
                if (currentServerConfig is not null)
                {
                    serverConfigs.Add(currentServerConfig);
                    currentServerConfig = null;
                }
            }
            else
            {
                var configProperties = line.Split(EqualsCharacter);

                var key = configProperties[0];
                var value = configProperties[1];

                if (key.Contains(OpeningBraceCharacter))
                {
                    key = key[..key.IndexOf(OpeningBraceCharacter)];
                }

                if (currentServerConfig is not null)
                {
                    currentServerConfig.Config.Add(new ConfigEntity 
                    { 
                        Key = key, 
                        Value = value 
                    });
                }
            }
        }

        return serverConfigs;
    }
}
