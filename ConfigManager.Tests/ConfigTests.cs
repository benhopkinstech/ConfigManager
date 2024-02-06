using ConfigManager.Application.Interfaces;
using ConfigManager.Application.Services;
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
    }
}