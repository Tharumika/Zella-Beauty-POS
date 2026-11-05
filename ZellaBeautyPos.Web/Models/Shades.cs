using System.Globalization;

namespace ZellaBeautyPos.Web.Models;

/// <summary>Lacquer colours per category, plus small display helpers.</summary>
public static class Shades
{
    public static string Hex(ServiceCategory c) => c switch
    {
        ServiceCategory.Hair => "#7B5CD6",
        ServiceCategory.Nails => "#D63E7A",
        ServiceCategory.NailArt => "#E8892B",
        ServiceCategory.Skin => "#1E8C8A",
        _ => "#8A7F90",
    };

    public static string Label(ServiceCategory c) => c switch
    {
        ServiceCategory.NailArt => "Nail art",
        _ => c.ToString(),
    };

    static readonly string[] Palette = ["#7B5CD6", "#D63E7A", "#E8892B", "#1E8C8A", "#C9A24B", "#4F6BD8"];

    public static string ForName(string name) =>
        Palette[(name ?? "").Aggregate(0, (h, ch) => (h * 31 + ch) & 0x7fffffff) % Palette.Length];

    public static string Initials(string name)
    {
        var parts = (name ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return parts.Length switch
        {
            0 => "?",
            1 => parts[0][..1].ToUpperInvariant(),
            _ => (parts[0][..1] + parts[^1][..1]).ToUpperInvariant(),
        };
    }

    public static string Money(decimal v) => "Rs " + v.ToString("N0", CultureInfo.InvariantCulture);
}
