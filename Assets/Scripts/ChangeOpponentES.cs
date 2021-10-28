using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeOpponentES : MonoBehaviour
{
    public static void OpponentESChange(int startES, Button choiceButton, GameObject choicePanel, GameObject opponent, int damage, Slider esMeter){
        if (opponent.GetComponent<DebateValuesScript>())
        {
            DebateValuesScript opponentValues = opponent.GetComponent<DebateValuesScript>();
            int opponentES = opponentValues.currentES;
            if(opponentES == startES){
                opponentValues.currentES += damage;
                if (opponentES > opponentValues.maxES)
                {
                    opponentES = opponentValues.maxES;
                }
                else if (opponentES < 0)
                {
                    opponentES = 0;
                }
                esMeter.value = opponentES;
                choicePanel.SetActive(false);
                Debug.Log("sfd");
            }
        }else{Debug.LogError("Supplied Game Object is not an opponent");}
    }
}
