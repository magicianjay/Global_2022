using System.Collections;
using System.Collections.Generic;
using MiscUtil.Collections.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerUI : MonoBehaviour
{
    public Slider _mySlider;
    public TextMeshProUGUI _textVitality;
    
    public void Initialize(int maxVitality)
    {
        _mySlider.maxValue = maxVitality;
        SetValues(maxVitality);
    }
    
    
    public void SetValues(int vitality)
    {
        _mySlider.value = vitality;
        _textVitality.text = vitality.ToString();
    }
}
