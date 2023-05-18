using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;

public class servo : MonoBehaviour
{
    public string authToken = "YOUR_AUTH_TOKEN";
    public string pinNumber = "YOUR_PIN";
    public Slider slider;
    public float requestDelay = 0.5f;

    private async void Start()
    {
        slider.value =0;

        while (true)
        {
            int angle = (int)Mathf.Lerp(0, 180, slider.value);

            string apiUrl = $"https://blynk.cloud/external/api/update?token=JHhdYSdSwcstn3ZLrJrroTD4lqHpUEAx&v6={angle}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Debug.LogError($"Failed to set servo angle to {angle}. Status code: {response.StatusCode}");
                }
            }
            await Task.Delay((int)(requestDelay * 1000));
        }
    }
}
