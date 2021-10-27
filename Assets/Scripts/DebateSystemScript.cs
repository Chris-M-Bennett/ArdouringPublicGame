using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {Start, Player, Opponent, Won, Lost}
public class DebateSystemScript : MonoBehaviour
{
    [SerializeField, Header("The Player game object in the scene")] private GameObject player;
    [SerializeField, Header("The point where the enemy is placed")] private Transform opponentSpawn;
    [SerializeField] private GameObject opponentPrefab;
    
    public DebateHUDScript playerHUD;
    public DebateHUDScript opponentHUD;
    [HideInInspector] public GameObject opponentGO;
    
    private DebateValuesScript _playerValues;
    private DebateValuesScript _opponentValues;
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
        _playerValues = player.GetComponent<DebateValuesScript>();
        
        opponentGO = Instantiate(opponentPrefab, opponentSpawn);
        _opponentValues = opponentGO.GetComponent<DebateValuesScript>();
        
        playerHUD.SetHUD(_playerValues);
        opponentHUD.SetHUD(_opponentValues);
    }
}
