using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum States { Neutral, Persuade, Argue, Act, Items, 
    OpPersuade, Thank, OnTopic, Ethos,
    Happy, Angry, Sad, Anxious}
public class PlayerDebateActionsScript : MonoBehaviour
{
    public States state = States.Neutral;
    //Game Objects
    //[SerializeField] private GameObject actPanel;
    //[SerializeField] private GameObject persuadePanel;
    //[SerializeField] private GameObject arguePanel;
    //[SerializeField] private GameObject itemsPanel;
    //private GameObject[] _panelsArray;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private GameObject choice1Button;
    [SerializeField] private GameObject choice2Button;
    [SerializeField] private GameObject choice3Button;
    [SerializeField] private GameObject choice4Button;
    private Text _choice1Text;
    private Text _choice2Text;
    private Text _choice3Text;
    private Text _choice4Text;
    private bool _isArguing;

    void Start()
    {
        _choice1Text = choice1Button.transform.GetChild(0).GetComponent<Text>();
        _choice2Text = choice2Button.transform.GetChild(0).GetComponent<Text>();
        _choice3Text = choice3Button.transform.GetChild(0).GetComponent<Text>();
        _choice4Text = choice4Button.transform.GetChild(0).GetComponent<Text>();
       // _panelsArray = new GameObject[4];
       // _panelsArray[0] = persuadePanel;
       // _panelsArray[1] = arguePanel;
       // _panelsArray[2] = actPanel;
        //_panelsArray[3] = itemsPanel;
        //Ensures no panels are showed when scene is started
        //ClosePanels();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case States.Act:
                _choice1Text.text = "Check";
                //choice1Button.GetComponent<Button>().onClick.AddListener(Check);
                _choice2Text.text = "Gift";
                //choice1Button.GetComponent<Button>().onClick.AddListener(Gift);
                _choice3Text.text = "Run";
                //choice1Button.GetComponent<Button>().onClick.AddListener(Run);
                _choice4Text.text = "Overload/Pacify";
                //choice1Button.GetComponent<Button>().onClick.AddListener(Overload/Pacify);
                choice4Button.GetComponent<Button>().enabled = false;
                break;
            case States.Persuade:
                _isArguing = false;
                _choice1Text.text = "Varying";
                //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniquePersuade);
                _choice2Text.text = "Thank";
                choice2Button.GetComponent<Button>().onClick.AddListener(delegate{PanelButton(States.Thank);});
                _choice3Text.text = "On Topic";
                //choice3Button.GetComponent<Button>().onClick.AddListener(OnTopic);
                _choice4Text.text = "Ethos";
                //choice4Button.GetComponent<Button>().onClick.AddListener(Ethos);
                choice4Button.GetComponent<Button>().enabled = false;
                //ChangeState("Varying",PanelButton(States.Neutral), "Thank", PanelButton(States.Thank),
                //    "On Topic",  PanelButton(States.Neutral), "Ethos",PanelButton(States.Neutral));
                break;
            
            case States.Argue:
                _isArguing = true;
                _choice1Text.text = "Varying";
                //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                _choice2Text.text = "Provoke";
                //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                _choice3Text.text = "Confuse";
                //choice3Button.GetComponent<Button>().onClick.AddListener();
                _choice4Text.text = "Pathos";
                //choice4Button.GetComponent<Button>().onClick.AddListener();
                choice4Button.GetComponent<Button>().enabled = false;
                break;
            case States.Thank:
                _choice1Text.text = "Happy";
                choice1Button.GetComponent<Button>().onClick.AddListener(delegate{PanelButton(States.Happy);});
                _choice2Text.text = "Angry";
                choice2Button.GetComponent<Button>().onClick.AddListener(delegate{PanelButton(States.Angry);});
                _choice3Text.text = "Sad";
                choice3Button.GetComponent<Button>().onClick.AddListener(delegate{PanelButton(States.Sad);});
                _choice4Text.text = "Anxious";
                choice4Button.GetComponent<Button>().onClick.AddListener(delegate{PanelButton(States.Anxious);});
                break;
            case States.Happy:
                if(_isArguing){
                    _choice1Text.text = "Mock";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Tease";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Laugh at";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                    
                }else
                {
                    _choice1Text.text = "Pet";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Dance";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Motivate";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                    
                }
                break;
            case States.Angry:
                if(_isArguing){
                    _choice1Text.text = "Intimidate";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Rant";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Shout";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                }else
                {
                    _choice1Text.text = "Assert";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Work out";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Timeout";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                }
                break;
            case States.Sad:
                if(_isArguing){
                    _choice1Text.text = "Guilt";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Crocodile Tears";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Be Numb";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                }else
                {
                    _choice1Text.text = "Cry With";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Write Poetry";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Comfort";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                }
                break;
            case States.Anxious:
                if(_isArguing){
                    _choice1Text.text = "Freak Out";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Overthink";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Induce Dread";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                }else
                {
                    _choice1Text.text = "Ask About";
                    //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniqueArgue);
                    _choice2Text.text = "Give Idea";
                    //choice2Button.GetComponent<Button>().onClick.AddListener(Provoke);
                    _choice3Text.text = "Deep Breaths";
                    //choice3Button.GetComponent<Button>().onClick.AddListener();
                    choice4Button.SetActive(false);
                }
                break;
        }
    }

    UnityAction PanelButton(States changeState){
        choicePanel.SetActive(true);
        state = changeState;
        return null;
    }
    
    public void ActButton(){
        PanelButton( States.Act);
    }
    
    public void PersuadeButton(){
        PanelButton( States.Persuade);
    }
    
    public void ArgueButton(){
        PanelButton( States.Argue);
    }
    
    public void ItemsButton(){
        //PanelButton( States.Items);
    }
    
    void ChangeState(string text1, UnityAction method1, string text2, UnityAction method2,
        string text3, UnityAction method3, string text4, UnityAction method4){
        _choice1Text.text = text1;
        choice1Button.GetComponent<Button>().onClick.AddListener(method1);
        _choice2Text.text = text2;
        choice2Button.GetComponent<Button>().onClick.AddListener(method2);
        _choice3Text.text = text3;
        choice3Button.GetComponent<Button>().onClick.AddListener(method3);
        _choice4Text.text = text4;
        choice4Button.GetComponent<Button>().onClick.AddListener(method4);
    }

    /// <summary>
    /// Hides all panels in the panels array
    /// </summary>
    /*void ClosePanels(){
        foreach (var i in _panelsArray)
        {
            i.SetActive(false);
        }*/
}
