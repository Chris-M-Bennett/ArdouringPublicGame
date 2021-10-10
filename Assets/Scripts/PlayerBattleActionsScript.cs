using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States { Neutral, General, Persuade, Argue, Items}
public class PlayerBattleActionsScript : MonoBehaviour
{
    public States state = States.Neutral;
    //Game Objects
    /*[SerializeField] private Button generalButton;
    [SerializeField] private Button persuadeButton;
    [SerializeField] private Button argueButton;
    [SerializeField] private Button itemsButton;
    [SerializeField] private Button checkButton;
    [SerializeField] private Button giftButton;
    [SerializeField] private Button runButton;
    [SerializeField] private Button endBattleButton;
    [SerializeField] private Button varyingButton;
    [SerializeField] private Button thankButton;
    [SerializeField] private Button onTopicButton;
    [SerializeField] private Button ethosButton;*/
    [SerializeField] private GameObject generalPanel;
    [SerializeField] private GameObject persuadePanel;
    [SerializeField] private GameObject arguePanel;
    [SerializeField] private GameObject itemsPanel;
    [SerializeField] private GameObject[] panelsArray;

    void Start()
    {
        panelsArray = new GameObject[4];
        panelsArray[0] = generalPanel;
        panelsArray[1] = persuadePanel;
        panelsArray[2] = arguePanel;
        panelsArray[3] = itemsPanel;
        //Ensures no panels are showed when scene is started
        ClosePanels();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            
        }  
    }

    void PanelButton(GameObject panel, States changeState){
        ClosePanels();
        panel.SetActive(true);
        state = changeState;
    }
    
    public void GeneralButton(){
        PanelButton(generalPanel, States.General);
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
