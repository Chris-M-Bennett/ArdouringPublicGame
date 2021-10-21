using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateValuesScript : MonoBehaviour  
{
    [SerializeField] public string debaterName;
    [SerializeField] public int debaterLevel;
    [SerializeField] public int debaterDamage;
    [SerializeField] public int maxES;
    [SerializeField] public int currentES;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Player")) {
            maxES = PlayerPrefs.GetInt("playerMax", 100);
            currentES = PlayerPrefs.GetInt("playerES", maxES);
        }
    }
}
