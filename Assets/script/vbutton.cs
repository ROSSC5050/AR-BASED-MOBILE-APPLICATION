using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Vuforia;

public class vbutton : MonoBehaviour
{
    VirtualButtonBehaviour vb;
    public string url="https://blynk.cloud/external/api/update?token=2IjhxllOdsvGs1Lqr5tmMDnz4X42QFxo&v0=1";
    // Start is called before the first frame update
    public void Start()
    {
        
        vb =GetComponentInChildren<VirtualButtonBehaviour>();
    }
    void onButtonPressed(VirtualButtonBehaviour vbon){
        StartCoroutine(GetRequest("https://blynk.cloud/external/api/update?token=2IjhxllOdsvGs1Lqr5tmMDnz4X42QFxo&v0=1"));
        IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
 
        }
    }
    }
    void onButtonReleased (VirtualButtonBehaviour vboff){
        StartCoroutine(GetRequest("https://blynk.cloud/external/api/update?token=2IjhxllOdsvGs1Lqr5tmMDnz4X42QFxo&v0=0"));
        IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
 
        }
    }}
    }
