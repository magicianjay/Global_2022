using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inhibitor : MonoBehaviour
{
    public Slider _mySlider;
    public TextMeshProUGUI _textVitality;
    
    public void Initialize(int maxVitality)
    {
        _mySlider.maxValue = maxVitality;
        SetValues(maxVitality);
    }
    
    public void SetValues(int Vitality)
    {
        _mySlider.value = Vitality;
        _textVitality.text = Vitality.ToString();
    }
}
