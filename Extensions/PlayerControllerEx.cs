using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;

namespace DoubleJumpCS2.Extensions
{
    internal static class PlayerControllerEx
    {
        public static bool IsValid(this CCSPlayerController player)
        {
            return player is { IsValid: true, IsBot: false, PawnIsAlive: true };
        }


        public static void PrintMessageToChat(this CCSPlayerController player, Plugin plugin, string message, params object[] args)
        {
            using (new WithTemporaryCulture(player.GetLanguage()))
            {
                player.PrintToChat(string.Format(plugin.Localizer[message], args));
            }
        }


        public static void PrintMessageToCenter(this CCSPlayerController player, Plugin plugin, string message, params object[] args)
        {
            using (new WithTemporaryCulture(player.GetLanguage()))
            {
                player.PrintToCenter(string.Format(plugin.Localizer[message], args));
            }
        }
    }
}
