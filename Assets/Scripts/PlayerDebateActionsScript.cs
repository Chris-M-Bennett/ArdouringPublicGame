using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States { Neutral, Persuade, Argue, Act, Items}
public class PlayerDebateActionsScript : MonoBehaviour
{
    public States state = States.Neutral;
    //Game Objects
    [SerializeField] private GameObject actPanel;
    [SerializeField] private GameObject persuadePanel;
    [SerializeField] private GameObject arguePanel;
    [SerializeField] private GameObject itemsPanel;
    [SerializeField] private GameObject[] panelsArray;

    void Start()
    {
        panelsArray = new GameObject[4];
        panelsArray[0] = persuadePanel;
        panelsArray[1] = arguePanel;
        panelsArray[2] = actPanel;
        panelsArray[3] = itemsPanel;
        //Ensures no panels are showed when scene is started
        ClosePanels();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PanelButton(GameObject panel, States changeState){
        ClosePanels();
        panel.SetActive(true);
        state = changeState;
    }
    
    public void ActButton(){
        PanelButton(actPanel, States.Act);
    }
    
    public void PersuadeButton(){
        PanelButton(persuadePanel, States.Persuade);
    }
    
    public void ArgueButton(){
        PanelButton(arguePanel, States.Argue);
    }
    
    public void ItemsButton(){
        PanelButton(itemsPanel, States.Items);
    }

    /// <summary>
    /// Hides all panels in the panels array
    /// </summary>
    void ClosePanels(){
        foreach (var i in panelsArray)
        {
            i.SetActive(false);
        }
    }
}
