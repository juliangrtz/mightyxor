using MetroFramework;
using System.Reflection;

namespace MightyXOR.GUI.Utils;

/// <summary>
/// Utility class holding constant values used throughout various forms.
/// </summary>
internal static class Constants
{
    public static bool BetaVersion => true;

    private static Version? AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version;
    public static string Version => $"v{AssemblyVersion?.Major}.{AssemblyVersion?.Minor}.{AssemblyVersion?.Revision}";
    public const int YShift = 3;
    public const MetroLabelSize DefaultLblSizeAfterSelection = MetroLabelSize.Medium;
}