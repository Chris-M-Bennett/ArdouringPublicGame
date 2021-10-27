using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeOpponentES : MonoBehaviour
{
    public static DebateHUDScript opponentHUD;


    // ReSharper disable Unity.PerformanceAnalysis
    public static void OpponentESChange(GameObject opponent, int damage, Slider esMeter){
        if (opponent.GetComponent<DebateValuesScript>())
        {
            DebateValuesScript opponentValues = opponent.GetComponent<DebateValuesScript>();
            opponentValues.currentES += damage;
            if (opponentValues.currentES > opponentValues.maxES)
            {
                opponentValues.currentES = opponentValues.maxES;
            }
            else if (opponentValues.currentES < 0)
            {
                opponentValues.currentES = 0;
            }

            esMeter.value = opponentValues.currentES;
        }else{Debug.LogError("Supplied Game Objects is not an opponent");}
    }
}
