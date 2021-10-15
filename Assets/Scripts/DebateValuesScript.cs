using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateValuesScript : MonoBehaviour  
{
    [SerializeField] public string battlerName;
    [SerializeField] public int battlerLevel;
    [SerializeField] public int battlerDamage;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
