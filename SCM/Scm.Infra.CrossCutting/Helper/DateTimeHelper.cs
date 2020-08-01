using System;

namespace Scm.Infra.CrossCutting.Helper
{
    public static class DateTimeHelper
    {
        public static string DefaultDateTimeFormat(this DateTime dateTime) =>
            dateTime.ToString("dd/MM/yyyy");
    }
}