using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SongAPI
{
    public class FormFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check for IFormFile parameters
            foreach (var parameter in operation.Parameters)
            {
                var fileParameter = parameter as OpenApiParameter;
                if (fileParameter?.Schema?.Type == "file")
                {
                    // Update the parameter schema to use the appropriate format for IFormFiles
                    fileParameter.Schema.Type = "string";
                    fileParameter.Schema.Format = "binary";
                }
            }
        }
    }
}
