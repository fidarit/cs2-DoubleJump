using CounterStrikeSharp.API.Core;
using DoubleJumpCS2.Controllers;
using DoubleJumpCS2.Extensions;
using DoubleJumpCS2.Models;
using System;

namespace DoubleJumpCS2
{
    public class Plugin : BasePlugin, IPluginConfig<PluginConfig>
    {
        #region Plugin info
        public override string ModuleName => "CS2_DoubleJump";
        public override string ModuleAuthor => AssemblyInfoEx.GetAuthor();
        public override string ModuleVersion => AssemblyInfoEx.GetVersion();
        #endregion

        public PluginConfig Config { get; set; } = new();
        
        internal ConfigController ConfigController { get; private set; }
        internal JumpController JumpController  { get; private set; }

        internal event Action OnConfigInit;

        public override void Load(bool hotReload)
        {
            if (hotReload)
                return;

            ConfigController = new(this);
            JumpController = new(this);
        }

        public void OnConfigParsed(PluginConfig config)
        {
            this.Config = config;
            OnConfigInit?.Invoke();
        }
    }
}
