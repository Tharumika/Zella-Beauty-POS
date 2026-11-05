using System.Globalization;

namespace ZellaBeautyPos.Web.Models;

/// <summary>Lacquer colours per category, plus small display helpers.</summary>
public static class Shades
{
    public static string Hex(ServiceCategory c) => c switch
    {
        ServiceCategory.Hair => "#7A4A6B",
        ServiceCategory.Nails => "#C0607A",
        ServiceCategory.NailArt => "#D08A5E",
        ServiceCategory.Skin => "#5E8C7B",
        _ => "#9A8790",
    };

    public static string Label(ServiceCategory c) => c switch
    {
        ServiceCategory.NailArt => "Nail art",
        _ => c.ToString(),
    };

    static readonly string[] Palette = ["#7A4A6B", "#C0607A", "#D08A5E", "#5E8C7B", "#C9977C", "#8C6A9A"];

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
