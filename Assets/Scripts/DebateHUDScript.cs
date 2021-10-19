using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebateHUDScript : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Slider esSlider;
    
    public void SetHUD(DebateValuesScript debater){
        nameText.text = debater.debaterName;
        levelText.text = "Level: "+debater.debaterLevel;
        esSlider.value = debater.currentES;
        esSlider.maxValue = debater.maxES;
    }
    
    private void SetES(int es){
        esSlider.value += es;
    }
}
