using CounterStrikeSharp.API.Core;
using DoubleJumpCS2.Extensions;

namespace DoubleJumpCS2
{
    public class Plugin : BasePlugin
    {
        public override string ModuleName => "CS2_DoubleJump";
        public override string ModuleAuthor => AssemblyInfoEx.GetAuthor();
        public override string ModuleVersion => AssemblyInfoEx.GetVersion();

        public override void Load(bool hotReload)
        {
            
        }
    }
}
