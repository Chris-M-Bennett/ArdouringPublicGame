using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {Start, Player, Opponent, Won, Lost}
public class DebateSystemScript : MonoBehaviour
{
    [SerializeField] private GameObject opponentObject;
    [SerializeField] private Transform opponentspawn;
    protected BattleState state = BattleState.Start;
    
    // Start is called before the first frame update
    void Start(){
        DebateSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void DebateSetup(){
        Instantiate(opponentObject, opponentspawn);
    }
}
