namespace InternationalSpaceStation.Middleware
{
    public static class KeyBasedAuthorizationExtensions
    {
        public static void UseKeyAuthorization(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Headers["x-key"] == "verysecret")
                    await next.Invoke();

                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                }
            });
        }
    }
}
