using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Vuforia;

public class Inputtemp : MonoBehaviour
{
    InputField field;
    InputField Hum;
    public VirtualButtonBehaviour Vb_on;
 
    void Start()
    {
        field = GameObject.Find("Inputtemp").GetComponent<InputField>();
        
        Hum = GameObject.Find("Inputhum").GetComponent<InputField>();

        Vb_on.RegisterOnButtonPressed(OnButtonPressed_on);

    }

    public void OnButtonPressed_on(VirtualButtonBehaviour Vb_on)
    {
        GetData_tem();
        GetData_hum();
        Debug.Log("Click");
    }
 
    void GetData_tem() => StartCoroutine(GetData_Coroutine1());
    void GetData_hum() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine1()
    {
        Debug.Log("Getting Data");
        field.text = "Loading...";
        string uri = "https://blynk.cloud/external/api/get?token=JHhdYSdSwcstn3ZLrJrroTD4lqHpUEAx&v1";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                field.text = request.error;
            else
            {

                field.text = request.downloadHandler.text;
                field.text = field.text.Substring(2,2);
            }
        }
    }
    IEnumerator GetData_Coroutine()
    {
        Debug.Log("Getting Data");
        Hum.text = "Loading...";
        string uri = "https://blynk.cloud/external/api/get?token=JHhdYSdSwcstn3ZLrJrroTD4lqHpUEAx&v2";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Hum.text = request.error;
            else
            {

                Hum.text = request.downloadHandler.text;
                Hum.text = Hum.text.Substring(2,2);
            }
        }
    }
}