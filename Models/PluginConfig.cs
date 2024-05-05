using CounterStrikeSharp.API.Core;

namespace DoubleJumpCS2.Models
{
    public class PluginConfig : BasePluginConfig
    {
        public int JumpsCount { get; set; } = 2;
        public float Velocity { get; set; } = 250f;
    }
}
