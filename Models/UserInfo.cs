using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Utils;

namespace DoubleJumpCS2.Models
{
    internal class UserInfo
    {
        public bool DoubleJumpEnabled { get; set; } = true;

        public PlayerButtons PrevButtons { get; set; }
        public PlayerFlags PrevFlags { get; set; }
        public int JumpsCount { get; set; }
    }
}
