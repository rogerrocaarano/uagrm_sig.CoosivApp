using System.Globalization;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Parsers;

public static class NumberParser
{
    public static decimal? ParseNullableDecimal(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        return null;
    }

    public static int? ParseNullableInt(string? value)
    {
        return int.TryParse(value, out var result) ? result : null;
    }
}