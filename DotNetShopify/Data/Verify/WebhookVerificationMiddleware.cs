using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Data.Verify;

public class WebhookVerificationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _webhookSecret;
    private StringValues hmacHeader;

    public WebhookVerificationMiddleware(RequestDelegate next, string webhookSecret)
    {
        _next = next;
        _webhookSecret = webhookSecret;
    }

    public async Task Invoke(HttpContext context)
    {
        string webhookData = // Get the webhook data from the request.
        hmacHeader = context.Request.Headers["X-Shopify-Hmac-SHA256"];

        if (VerifyWebhook(webhookData, hmacHeader, _webhookSecret))
        {
            // Request is valid; continue processing.
            await _next(context);
        }
        else
        {
            // Invalid request; return an unauthorized response.
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
    }

    private bool VerifyWebhook(string webhookData, string hmacHeader, string secret)
    {
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
        {
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(webhookData));
            string calculatedHmac = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return calculatedHmac == hmacHeader;
        }
    }
}

public static class WebhookVerificationMiddlewareExtensions
{
    public static IApplicationBuilder UseWebhookVerification(this IApplicationBuilder builder, string webhookSecret)
    {
        return builder.UseMiddleware<WebhookVerificationMiddleware>(webhookSecret);
    }
}


