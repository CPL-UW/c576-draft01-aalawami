using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public Text textFeild;

    public UnityEvent buttonClick;

    public ClockUI clockui;

    public void SetText(string text)
    {
        textFeild.text = text;
        
    }

    void Awake()
    {
        if (buttonClick == null) { buttonClick = new UnityEvent(); }
    }

    void OnMouseUp()
    {
        buttonClick.Invoke();
        
    }
}


