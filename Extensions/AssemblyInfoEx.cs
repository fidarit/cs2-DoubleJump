using System.Reflection;

namespace DoubleJumpCS2.Extensions
{
    internal static class AssemblyInfoEx
    {
        public static string GetVersion()
        {
            return typeof(AssemblyInfoEx).Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        }

        public static string GetAuthor()
        {
            return Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyCopyrightAttribute>()
                .Copyright;
        }
    }
}
