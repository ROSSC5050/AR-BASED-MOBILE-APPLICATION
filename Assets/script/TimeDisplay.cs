using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeDisplay : MonoBehaviour
{
    public Text timeText;
    public void Update(){
        timeText.text = " "+ System.DateTime.Now.ToString("h:mm:ss tt");

    }
}