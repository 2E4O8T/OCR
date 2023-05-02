using ExpressV.Options;

namespace ExpressV.Services
{
    public class PathService
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public PathService(IConfiguration configuration, IWebHostEnvironment environment) 
        {
            this.configuration = configuration;
            this.environment = environment;
        }
        public string GetUploadsPath(string? filename = null, bool withWebRootPath = true)
        {
            var pathOptions = new PathOptions();
            
            configuration.GetSection(PathOptions.Path).Bind(pathOptions);

            var uploadsPath = pathOptions.FruitsImages;

            if (null != filename)
                uploadsPath = Path.Combine(uploadsPath, filename);

            return withWebRootPath ? Path.Combine(environment.WebRootPath, uploadsPath) : uploadsPath;

        }
    }
}
