using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOpponentES : MonoBehaviour
{
    [SerializeField] private GameObject opponent;


    public static void ESDown(GameObject opponent, int damage){
        if (opponent.GetComponent<DebateValuesScript>())
        {
            opponent.GetComponent<DebateValuesScript>().currentES -= damage;
        }else{Debug.LogError("Supplied Game Objects is not an opponent");}
    }
}
