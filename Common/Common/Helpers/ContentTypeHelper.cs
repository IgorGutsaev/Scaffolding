namespace Scaffolding.Common.Helpers.Helpers
{
    public static class ContentTypeHelper
    {
        public static string GetFileExtension(this string contentType)
        {
            contentType = contentType.ToLower();
            if (contentType.Contains("json"))
                return ".json";
            else if (contentType.Contains("plain"))
                return ".txt";
            else if (contentType.Contains("html"))
                return ".html";
            else if (contentType.Contains("binary"))
                return ".bin";
            else if (contentType.Contains("gif"))
                return ".gif";
            else if (contentType.Contains("jpeg"))
                return ".jpg";
            else if (contentType.Contains("pdf"))
                return ".pdf";
            else if (contentType.Contains("xml"))
                return ".xml";
            else if (contentType.Contains("msword"))
                return ".doc";
            else if (contentType.Contains("zip"))
                return ".zip";
            else if (contentType.Contains("gzip"))
                return ".gzip";
            else if (contentType.Contains("png"))
                return ".png";
            else if (contentType.Contains("msexcel"))
                return ".xls";
            else if (contentType.Contains("csv"))
                return ".csv";

            return string.Empty;
        }
    }
}
