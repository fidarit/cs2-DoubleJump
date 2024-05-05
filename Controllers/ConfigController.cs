using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Cvars;

namespace DoubleJumpCS2.Controllers
{
    internal class ConfigController : BaseController
    {
        public readonly FakeConVar<int> JumpsCountCvar = new("dj_count", "Max jumps count", flags: ConVarFlags.FCVAR_SERVER_CAN_EXECUTE);
        public readonly FakeConVar<float> JumpVelocityCvar = new("dj_velocity", "Jump velocity", flags: ConVarFlags.FCVAR_SERVER_CAN_EXECUTE);

        public ConfigController(Plugin plugin) : base(plugin)
        {
            JumpsCountCvar.ValueChanged += (_, value) => Config.JumpsCount = value;
            JumpVelocityCvar.ValueChanged += (_, value) => Config.Velocity = value;

            Plugin.RegisterFakeConVars(this);
            Plugin.OnConfigInit += OnConfigUpdate;
        }

        private void OnConfigUpdate()
        {
            JumpsCountCvar.Value = Config.JumpsCount;
            JumpVelocityCvar.Value = Config.Velocity;
        }
    }
}
