using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
class Program
{
    static async Task Main(string[] args)
    {
        string webhookUrl = "https://hooks.slack.com/services/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"; // 여기에 Slack Webhook URL을 입력하세요
        string message = "Slack 메시지를 전송합니다~!";

        await SendSlackNotification(webhookUrl, message);
    }

    static async Task SendSlackNotification(string webhookUrl, string message)
    {
        using (HttpClient client = new HttpClient())
        {
            var payload = new { text = message };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(webhookUrl, content);

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Slack으로 메시지를 성공적으로 보냈습니다.");
            } else {
                Console.WriteLine("Slack으로 메시지를 보내지 못했습니다. 오류 코드: " + response.StatusCode);
            }
        }
    }
}
