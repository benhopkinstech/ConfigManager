using ConfigManager.Application.Interfaces;
using ConfigManager.Application.Services;
using ConfigManager.Domain.Entities;
using FluentAssertions;
using System.Linq;

namespace ConfigManager.Tests
{
    public class ConfigTests
    {
        private readonly IConfigManagerService _configManagerService;
        private readonly List<ServerConfigEntity> _serverConfigs;

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
            _serverConfigs = _configManagerService.LoadConfig(ConfigFilePath);
        }

        [Fact]
        public void LoadConfig_ServerCountShouldBe7()
        {
            _serverConfigs.Should().HaveCount(7);
        }

        [Fact]
        public void LoadConfig_DefaultServerCountShouldBe1()
        {
            _serverConfigs.Where(x => x.Server.Equals(DefaultServer)).Should().HaveCount(1);
        }

        [Fact]
        public void LoadConfig_OtherServersCountShouldBe6()
        {
            _serverConfigs.Where(x => OtherServers.Contains(x.Server)).Should().HaveCount(6);
        }
    }
}