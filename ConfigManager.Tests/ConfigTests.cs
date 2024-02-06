using ConfigManager.Application.Interfaces;
using ConfigManager.Application.Services;
using ConfigManager.Domain.Entities;
using FluentAssertions;

namespace ConfigManager.Tests
{
    public class ConfigTests
    {
        private readonly IConfigManagerService _configManagerService;

        private const string ConfigFilePath = "../../../../ConfigManager/config.txt";
        private const string DefaultServer = "DEFAULTS";
        private List<string> OtherServers = new List<string>
        {
            "SRVTST0003",
            "SRVTST0006",
            "SRVTST0009",
            "SRVTST0012",
            "SRVTST0016",
            "SRVTST0019",
        };

        public ConfigTests()
        {
            _configManagerService = new ConfigManagerService();
        }

        [Fact]
        public void LoadConfig_ServerCountShouldBe7()
        {
            var serverConfigs = _configManagerService.LoadConfig(ConfigFilePath);
            serverConfigs.Should().HaveCount(7);
        }

        [Fact]
        public void LoadConfig_DefaultServerCountShouldBe1()
        {
            var serverConfigs = _configManagerService.LoadConfig(ConfigFilePath);
            serverConfigs.Where(x => x.Server.Equals(DefaultServer)).Should().HaveCount(1);
        }

        [Fact]
        public void LoadConfig_OtherServersCountShouldBe6()
        {
            var serverConfigs = _configManagerService.LoadConfig(ConfigFilePath);
            serverConfigs.Where(x => OtherServers.Contains(x.Server)).Should().HaveCount(6);
        }

        [Fact]
        public void UpdateConfigForServer_BlankServerConfigShouldReturnFalse()
        {
            var success = _configManagerService.UpdateConfigForServer(ConfigFilePath, new ServerConfigEntity());
            success.Should().BeFalse();
        }

        [Fact]
        public void UpdateConfigForServer_DefaultServerShouldUpdate()
        {
            UpdateServerConfig(DefaultServer);
        }

        [Fact]
        public void UpdateConfigForServer_OtherServersShouldUpdate()
        {
            foreach (var server in OtherServers)
            {
                UpdateServerConfig(server);
            }
        }

        private void UpdateServerConfig(string server)
        {
            var updateServerConfig = new ServerConfigEntity()
            {
                Server = server,
                Config = new List<ConfigEntity> {
                    new ConfigEntity { Key = "SERVER_NAME", Value = "TEST-SERVER-NAME" },
                    new ConfigEntity { Key = "URL", Value = "http://test-server-url" }
                },
            };

            var serverConfigs = _configManagerService.LoadConfig(ConfigFilePath);
            var serverConfig = serverConfigs.Where(x => x.Server.Equals(server));
            serverConfig.Should().HaveCount(1);
            var currentServerConfig = serverConfig.First();

            var success = _configManagerService.UpdateConfigForServer(ConfigFilePath, updateServerConfig);
            success.Should().BeTrue();

            var newServerConfigs = _configManagerService.LoadConfig(ConfigFilePath);
            var newServerConfig = newServerConfigs.Where(x => x.Server.Equals(server));
            newServerConfig.Should().HaveCount(1);
            var updatedServerConfig = newServerConfig.First();

            updatedServerConfig.Config.Should().HaveCount(2);

            success = _configManagerService.UpdateConfigForServer(ConfigFilePath, currentServerConfig);
            success.Should().BeTrue();
        }
    }
}