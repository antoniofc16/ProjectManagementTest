using MudBlazor;
using TimeZoneConverter;

namespace FullStackTest.Client.Configuration
{
    public static class Utilities
    {
        public static DateTime ToPeruTimeZone(this DateTime time)
        {
            var tzi = TZConvert.GetTimeZoneInfo("SA Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(time, tzi);
        }

        public static void AddSnackBar(this ISnackbar context, string message, Severity severity, int durationInSeconds = 3)
        {
            int duration = durationInSeconds * 1000;
            context.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            context.Add(
                         message: message,
                         severity: severity,
                         config =>
                         {
                             config.VisibleStateDuration = duration;
                         }
                         );
        }
    }
}
