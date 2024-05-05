using System.Reflection;

namespace DoubleJumpCS2.Extensions
{
    internal static class AssemblyInfoEx
    {
        public static string GetVersion()
        {
            return Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyVersionAttribute>()
                .Version;
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
