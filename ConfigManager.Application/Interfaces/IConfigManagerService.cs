﻿using ConfigManager.Domain.Entities;

namespace ConfigManager.Application.Interfaces;

public interface IConfigManagerService
{
    List<ServerConfigEntity> LoadConfig(string filePath);

    bool UpdateConfigForServer(string filePath, ServerConfigEntity serverConfig);
}
