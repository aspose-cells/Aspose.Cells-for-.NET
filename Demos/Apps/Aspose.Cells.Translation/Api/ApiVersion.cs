namespace Aspose.Cells.Translation.Api
{
    public class ApiVersion
    {
        public string Version { get; set; }

        private ApiVersion(string version)
        {
            Version = version;
        }

        public static ApiVersion V1 = new ApiVersion("1.0");

        public override string ToString()
        {
            return Version;
        }
    }
}