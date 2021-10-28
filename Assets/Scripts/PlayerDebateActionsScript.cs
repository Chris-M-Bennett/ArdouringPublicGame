using UnityEngine;
using UnityEngine.UI;

public enum States { Neutral, Persuade, Argue, Act, Items, 
    Emotions, Happy, Angry, Sad, Anxious}
public partial class PlayerDebateActionsScript : MonoBehaviour
{
    public States state = States.Neutral;
    public GameObject choicePanel;
    [SerializeField] private GameObject choice1;
    [SerializeField] private GameObject choice2;
    [SerializeField] private GameObject choice3;
    [SerializeField] private GameObject choice4;
    [SerializeField] private Slider opponentESSlider;
    private GameObject _opponentGO;
    private Button _choice1Button;
    private Button _choice2Button;
    private Button _choice3Button;
    private Button _choice4Button;
    private Text _choice1Text;
    private Text _choice2Text;
    private Text _choice3Text;
    private Text _choice4Text;
    private bool _isArguing;

    void Start()
    {
        _choice1Button = choice1.GetComponent<Button>();
        _choice2Button = choice2.GetComponent<Button>();
        _choice3Button = choice3.GetComponent<Button>();
        _choice4Button = choice4.GetComponent<Button>();
        _choice1Text = choice1.transform.GetComponentInChildren<Text>();
        _choice2Text = choice2.transform.GetComponentInChildren<Text>();
        _choice3Text = choice3.transform.GetComponentInChildren<Text>();
        _choice4Text = choice4.transform.GetComponentInChildren<Text>();
        _opponentGO = GetComponentInParent<DebateSystemScript>().opponentGO;
        //ClosePanels();
    }


    void SetButtonUnlock(bool state)
    {
        _choice4Button.enabled = state;
        choice4.GetComponent<Image>().color = state ? Color.white : Color.gray;
    }

    // Update is called once per frame
    void Update(){
        switch(state){
            case States.Act:
                ChangeState(ACT_1, States.Neutral, ACT_2, States.Neutral, ACT_3,
                    States.Neutral, ACT_4, States.Neutral);
                SetButtonUnlock(false);
                break;
            case States.Persuade:
                _isArguing = false;
                ChangeState(PER_1_VARIED,States.Emotions, PER_2, States.Emotions,  PER_3,  
                    States.Emotions, PER_4,States.Emotions);
                SetButtonUnlock(false);
                // choice4Button.GetComponent<Button>().enabled = false;
                // choice4Button.GetComponent<Image>().color = Color.gray;
                break;
            
            case States.Argue:
                _isArguing = true;
                ChangeState(ARG_1_VARIED,States.Emotions, ARG_2, States.Emotions,  ARG_3,  
                    States.Emotions, ARG_4,States.Emotions);
                SetButtonUnlock(false);

                break;
            
            case States.Emotions:
                ChangeState(HAPPY,States.Happy, ANGRY, States.Angry,  "Sad",  
                    States.Sad, ANXIOUS,States.Anxious);
                SetButtonUnlock(true);
                break;
            case States.Happy:
                if (_isArguing)
                {
                    ChangeAction(HAPPY_ARG_1, ARG_CHANGE_1, HAPPY_ARG_2, ARG_CHANGE_2, HAPPY_ARG_3,
                        ARG_CHANGE_3, EMPTY, ARG_CHANGE_4);
                }
                else
                {
                    ChangeAction(HAPPY_PER_1, PER_CHANGE_1, HAPPY_PER_2, PER_CHANGE_2,
                        HAPPY_PER_3, PER_CHANGE_3, EMPTY, PER_CHANGE_4);
                }

                break;
            case States.Angry:
                if(_isArguing){
                        ChangeAction(ANGRY_ARG_1, ARG_CHANGE_1, ANGRY_ARG_2, ARG_CHANGE_2, 
                            ANGRY_ARG_3, ARG_CHANGE_3, EMPTY, ARG_CHANGE_4);
                }else
                {
                    ChangeAction(ANGRY_PER_1, PER_CHANGE_1, ANGRY_PER_2, PER_CHANGE_2, 
                        ANGRY_PER_3, PER_CHANGE_3, EMPTY, PER_CHANGE_4);
                }
                break;
            case States.Sad:
                if(_isArguing){
                        ChangeAction(SAD_ARG_1, ARG_CHANGE_1,SAD_ARG_2, ARG_CHANGE_2,
                            SAD_ARG_3, ARG_CHANGE_3, EMPTY, ARG_CHANGE_4);
                }else
                {
                    ChangeAction(SAD_PER_1, PER_CHANGE_1, SAD_PER_2, PER_CHANGE_2,
                        SAD_PER_3,PER_CHANGE_3, EMPTY, PER_CHANGE_4);
                }
                break;
            case States.Anxious:
                if(_isArguing){
                        ChangeAction(ANXIOUS_ARG_1, ARG_CHANGE_1,ANXIOUS_ARG_2, ARG_CHANGE_2,
                            ANXIOUS_ARG_3, ARG_CHANGE_3, EMPTY, ARG_CHANGE_4);
                }else
                {
                    ChangeAction(ANXIOUS_PER_1, PER_CHANGE_1, ANXIOUS_PER_2, PER_CHANGE_2,
                        ANXIOUS_PER_3,PER_CHANGE_3, EMPTY, PER_CHANGE_4);
                }
                break;
        }
    }


    private void PanelButton(States changeState){
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
    
    void ChangeTexts(string text1, string text2, string text3, string text4){
       //Removes listeners previous added to buttons
        _choice1Button.onClick.RemoveAllListeners();
        _choice2Button.onClick.RemoveAllListeners();
        _choice3Button.onClick.RemoveAllListeners();
        _choice4Button.onClick.RemoveAllListeners();
        
        //Checks text for buttons to see if they should be active
        choice1.SetActive(text1 != "");
        choice2.SetActive(text2 != "");
        choice3.SetActive(text3 != "");
        choice4.SetActive(text4 != "");
        
        _choice1Text.text = text1;
        _choice2Text.text = text2;
        _choice3Text.text = text3;
        _choice4Text.text = text4;
    }
    
    void ChangeState(string text1, States state1, string text2, States state2,
        string text3, States state3, string text4, States state4)
    {
        ChangeTexts(text1, text2, text3, text4);
        _choice1Button.onClick.AddListener(()=>PanelButton(state1));
        _choice2Button.onClick.AddListener(()=>PanelButton(state2));
        _choice3Button.onClick.AddListener(()=>PanelButton(state3));
        _choice4Button.onClick.AddListener(()=>PanelButton(state4));
    }
    
    void ChangeAction(string text1, int change1,string text2, int change2,
        string text3, int change3, string text4, int change4){
        ChangeTexts(text1, text2, text3, text4);
        //Gets opponent's ES value before change for comparison
        int startES = _opponentGO.GetComponent<DebateValuesScript>().currentES;
        _choice1Button.onClick.AddListener(()=>ChangeOpponentES.OpponentESChange(startES, _choice1Button, choicePanel, _opponentGO, change1, opponentESSlider));
        _choice2Button.onClick.AddListener(()=>ChangeOpponentES.OpponentESChange(startES, _choice2Button, choicePanel,_opponentGO, change2, opponentESSlider));
        _choice3Button.onClick.AddListener(()=>ChangeOpponentES.OpponentESChange(startES, _choice3Button, choicePanel,_opponentGO, change3, opponentESSlider));
        _choice4Button.onClick.AddListener(()=>ChangeOpponentES.OpponentESChange(startES, _choice4Button, choicePanel,_opponentGO, change4, opponentESSlider));
    }
}
