using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class allofff : MonoBehaviour
{
    public string[] urls = new string[] {"https://blynk.cloud/external/api/update?token=JHhdYSdSwcstn3ZLrJrroTD4lqHpUEAx&v7=0", "https://blynk.cloud/external/api/update?token=JHhdYSdSwcstn3ZLrJrroTD4lqHpUEAx&v8=0", "https://blynk.cloud/external/api/update?token=JHhdYSdSwcstn3ZLrJrroTD4lqHpUEAx&v9=0"};
    public void open()
    {
        foreach (string url in urls){
            StartCoroutine(GetRequest(url));

        }
        
    }
 
    IEnumerator GetRequest(string uri)
    {
        foreach (string url in urls){
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
 
        }

        }
        
    }
}