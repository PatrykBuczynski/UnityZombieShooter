using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private Text textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = "" + sliderUI.value;
        textSliderValue.text = sliderMessage;
    }
}
