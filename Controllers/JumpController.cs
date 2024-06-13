using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using DoubleJumpCS2.Extensions;
using DoubleJumpCS2.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoubleJumpCS2.Controllers
{
    internal class JumpController : BaseController
    {
        private readonly Dictionary<int?, UserInfo> Users = new();

        public JumpController(Plugin plugin) : base(plugin)
        {
            Plugin.RegisterListener<Listeners.OnTick>(OnTick);
            Plugin.RegisterListener<Listeners.OnMapStart>(OnMapStart);

            Plugin.AddCommand("dj", "A command to enable/disable Double jump", OnCommand);
        }

        public void OnCommand(CCSPlayerController player, CommandInfo info)
        {
            if (player == null)
                return;

            var userId = player.UserId;
            if (!Users.TryGetValue(userId, out var userInfo))
            {
                userInfo = new();
                Users.Add(userId, userInfo);
            }

            userInfo.DoubleJumpEnabled = !userInfo.DoubleJumpEnabled;

            if (userInfo.DoubleJumpEnabled)
                player.PrintMessageToCenter(Plugin, "dj.enabled");
            else
                player.PrintMessageToCenter(Plugin, "dj.disabled");
        }

        private void OnTick()
        {
            if (Config.JumpsCount <= 1)
                return;

            foreach (var player in Utilities.GetPlayers().Where(PlayerControllerEx.IsValid))
            {
                OnTick(player);
            }
        }

        private void OnMapStart(string name)
        {
            Users.Clear();
        }

        private void OnTick(CCSPlayerController player)
        {
            var playerPawn = player.PlayerPawn.Value;
            if (playerPawn == null)
                return;

            if (!string.IsNullOrWhiteSpace(Config.RequiredPermission) && !AdminManager.PlayerHasPermissions(player, Config.RequiredPermission))
                return;

            var userId = player.UserId;
            if (!Users.TryGetValue(userId, out var userInfo))
            {
                userInfo = new();
                Users.Add(userId, userInfo);
            }

            var currentFlags = (PlayerFlags)playerPawn.Flags;
            var currentButtons = player.Buttons;

            var wasGrounded = (userInfo.PrevFlags & PlayerFlags.FL_ONGROUND) != 0;
            var isGrounded = (currentFlags & PlayerFlags.FL_ONGROUND) != 0;

            var jumpWasPressed = (userInfo.PrevButtons & PlayerButtons.Jump) != 0;
            var jumpIsPressed = (currentButtons & PlayerButtons.Jump) != 0;

            if (isGrounded)
                userInfo.JumpsCount = 0;
            else if (userInfo.JumpsCount < 1)
                userInfo.JumpsCount = 1;

            if (userInfo.DoubleJumpEnabled
                && !jumpWasPressed && jumpIsPressed
                && !wasGrounded && !isGrounded
                && userInfo.JumpsCount < Config.JumpsCount)
            {
                userInfo.JumpsCount++;

                if (Config.AllowInstantJump || playerPawn.CanForceJump())
                    playerPawn.ForceJump(Config.Velocity);
            }

            userInfo.PrevFlags = currentFlags;
            userInfo.PrevButtons = currentButtons;
        }
    }
}
