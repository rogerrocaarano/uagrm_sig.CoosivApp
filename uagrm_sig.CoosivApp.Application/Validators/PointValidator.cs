using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Application.Validators;

public static class PointValidator
{
    public static bool IsValidPoint(Point point)
    {
        return ValidLatitude(point) && ValidLongitude(point);
    }
    
    public static bool ValidLatitude(Point point)
    {
        return point.Latitude is >= -90 and <= 90 && point.Latitude != 0;
    }
    
    public static bool ValidLongitude(Point point)
    {
        return point.Longitude is >= -180 and <= 180 && point.Latitude != 0;
    }
}