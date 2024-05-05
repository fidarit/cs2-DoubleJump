using CounterStrikeSharp.API.Core;

namespace DoubleJumpCS2.Extensions
{
    internal static class PlayerPawnEx
    {
        public static bool CanForceJump(this CCSPlayerPawn playerPawn)
        {
            return playerPawn.AbsVelocity.Z < 0;
        }

        public static void ForceJump(this CCSPlayerPawn playerPawn, float jumpVelocity)
        {
            playerPawn.AbsVelocity.Z = jumpVelocity;
        }
    }
}
