using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Wave : MonoBehaviour
{
    public Slider _mySlider;
    public TextMeshProUGUI _textPercent;
    public TextMeshProUGUI _waveText;
    
    public void Initialize(float percentDone, int numberWave)
    {
        _mySlider.maxValue = percentDone;
        SetValues(percentDone,numberWave);
    }
    
    public void SetValues(float percentDone, int numberWave)
    {
        _mySlider.value = percentDone;
        _textPercent.text = String.Concat(percentDone.ToString(),"%");
        _waveText.text = String.Concat("Wave : ",numberWave.ToString());
        
    }
}
