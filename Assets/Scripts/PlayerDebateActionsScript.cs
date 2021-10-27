using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum States { Neutral, Persuade, Argue, Act, Items, 
    OpPersuade, Emotions, OnTopic, Ethos,
    Happy, Angry, Sad, Anxious}
public class PlayerDebateActionsScript : MonoBehaviour
{
    public const string CHECK = "Check";
    public const string GIFT = "Gift";
    public const string RUN = "Run";
    public const string OVERLOADPACIFY = "Overload/Pacify";
    public const string PERSUADEVARIED = "Varying";
    public const string THANK = "Thank";
    public const string ONTOPIC = "On Topic";
    public const string ETHOS = "Ethos";
    public const string ARGUEVARIED = "Varying";
    public const string PROVOKE = "Provoke";
    private const string CONFUSE = "Confuse";
    public const string PATHOS = "Pathos";

    public States state = States.Neutral;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private GameObject choice1Button;
    [SerializeField] private GameObject choice2Button;
    [SerializeField] private GameObject choice3Button;
    [SerializeField] private GameObject choice4Button;
    [SerializeField] private Slider opponentESSlider;
    private GameObject _opponentGO;
    private Text _choice1Text;
    private Text _choice2Text;
    private Text _choice3Text;
    private Text _choice4Text;
    private bool _isArguing;
    private bool _clicked = false;
    private int _persuade1Change = 2;

    void Start()
    {
        _choice1Text = choice1Button.transform.GetComponentInChildren<Text>();
        _choice2Text = choice2Button.transform.GetComponentInChildren<Text>();
        _choice3Text = choice3Button.transform.GetComponentInChildren<Text>();
        _choice4Text = choice4Button.transform.GetComponentInChildren<Text>();
        _opponentGO = GetComponentInParent<DebateSystemScript>().opponentGO;
        // _panelsArray = new GameObject[4];
        // _panelsArray[0] = persuadePanel;
        // _panelsArray[1] = arguePanel;
        // _panelsArray[2] = actPanel;
        //_panelsArray[3] = itemsPanel;
        //Ensures no panels are showed when scene is started
        //ClosePanels();
    }


    void SetButtonUnlock(GameObject button, bool state)
    {
        button.GetComponent<Button>().enabled = state;
        button.GetComponent<Image>().color = state ? Color.white : Color.gray;
    }

    void SetButtonOnClick(GameObject button, int change)
    {
        button.GetComponent<Button>().onClick.AddListener(()=>ChangeOpponentES.OpponentESChange(_opponentGO, change, opponentESSlider));
        _clicked = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        switch(state){
            case States.Act:
                ChangeTextChoices(CHECK, GIFT, RUN, OVERLOADPACIFY);
                SetButtonUnlock(choice4Button, true);
                break;
            case States.Persuade:
                _isArguing = false;
                /*_choice1Text.text = "Varying";
                //choice1Button.GetComponent<Button>().onClick.AddListener(OpponentUniquePersuade);
                _choice2Text.text = "Thank";
                choice2Button.GetComponent<Button>().onClick.AddListener(delegate{PanelButton(States.Thank);});
                _choice3Text.text = "On Topic";
                //choice3Button.GetComponent<Button>().onClick.AddListener(OnTopic);
                _choice4Text.text = "Ethos";
                //choice4Button.GetComponent<Button>().onClick.AddListener(Ethos);*/
                ChangeState(PERSUADEVARIED,States.Neutral, THANK, States.Emotions,  ONTOPIC,  
                    States.Neutral, ETHOS,States.Neutral);
                SetButtonUnlock(choice4Button, false);
                // choice4Button.GetComponent<Button>().enabled = false;
                // choice4Button.GetComponent<Image>().color = Color.gray;
                break;
            
            case States.Argue:
                _isArguing = true;
                ChangeState(ARGUEVARIED,States.Neutral, PROVOKE, States.Emotions,  CONFUSE,  
                    States.Neutral, PATHOS,States.Neutral);
                SetButtonUnlock(choice4Button, false);

                break;
            
            case States.Emotions:
                ChangeState("Happy",States.Happy, "Angry", States.Angry,  "Sad",  
                    States.Sad, "Anxious",States.Anxious);
                break;
            case States.Happy:
                if (!_clicked)
                {
                    if (_isArguing)
                    {
                        ChangeTextChoices("Mock", "Tease", "Laugh", "");
                    }
                    else
                    {
                        ChangeTextChoices("Pet", "Dance", "Motivate", "");
                        SetButtonOnClick(choice1Button, _persuade1Change);

                    }
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

    private void ChangeTextChoices(string c1, string c2, string c3, string c4)
    {

        choice1Button.SetActive(c1 != "");
        choice2Button.SetActive(c2 != "");
        choice3Button.SetActive(c3 != "");
        choice4Button.SetActive(c4 != "");

        _choice1Text.text = c1;
        _choice2Text.text = c2;
        _choice3Text.text = c3;
        _choice4Text.text = c4;
        
    }

    public void PanelButton(States changeState){
        choicePanel.SetActive(true);
        state = changeState;
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
    
    void Change(){}
    void ChangeState(string text1, States state1, string text2, States state2,
        string text3, States state3, string text4, States state4)
    {
        _clicked = false;
        _choice1Text.text = text1;
        choice1Button.GetComponent<Button>().onClick.AddListener(()=>PanelButton(state1));
        _choice2Text.text = text2;
        choice2Button.GetComponent<Button>().onClick.AddListener(()=>PanelButton(state2));
        _choice3Text.text = text3;
        choice3Button.GetComponent<Button>().onClick.AddListener(()=>PanelButton(state3));
        _choice4Text.text = text4;
        choice4Button.GetComponent<Button>().onClick.AddListener(()=>PanelButton(state4));
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
