using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_Environment : MonoBehaviour
{
    Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "Time : " + Environment.TimeString() + System.Environment.NewLine + 
            "Weather : " + Environment.Instance.currentWeather + System.Environment.NewLine + 
            Environment.Instance.WeatherLast.ToString();
    }
}
