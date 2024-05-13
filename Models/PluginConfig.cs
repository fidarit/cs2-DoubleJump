using CounterStrikeSharp.API.Core;

namespace DoubleJumpCS2.Models
{
    public class PluginConfig : BasePluginConfig
    {
        public int JumpsCount { get; set; } = 2;
        public float Velocity { get; set; } = 250f;

        public bool AllowInstantJump { get; set; } = true;

        /// <summary>
        /// If <see cref="RequiredPermission"/> is empty, everyone can use multiple jump
        /// </summary>
        public string RequiredPermission { get; set; } = "@css/vip";
    }
}
