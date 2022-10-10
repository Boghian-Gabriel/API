namespace API.UriApi
{
    public static class BaseUriApi
    {
        public static string BaseUri = "https://localhost:7165/api/";

        public static string GetUriWithController(string controller)
        {
            return BaseUri + controller;
        }
    }
}
