using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    //mw ler request oluşurken ve response yollanırken çalışır
    public static class UseCustomExceptionHandler
    {
        //Hata oluştu. Artık kontrol burada response buradan dönecek.
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch 
                    {
                        ClientSideException=>400,
                        NotFoundException=>404,
                        _ => 500,
                    };
                    context.Response.StatusCode = statusCode;
                    //burada log yazdırılabilir.
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    //Controller içerisinde json dönüşümü otomatik fakat burada hata fırlatmayı biz ele aldığımız için Json serialize işlemi yapmamız gerekiyor.
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });

        }
    }
}
