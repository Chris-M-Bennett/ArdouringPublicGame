using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOverworldControls : MonoBehaviour
{
    private Vector3 _currentPosition;
    private bool _isRunning = false;
    [SerializeField] private float moveSpeed = 0.001f;
    [SerializeField] private float runSpeedDif = 0.004f;
    [SerializeField] private int debateScene;
    [SerializeField] private LayerMask opponentMask;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        _currentPosition = transform.position;
        if (Input.GetAxis("Vertical") != 0)
        {//Moves the player on the vertical axis in the direction of the input
            _currentPosition.y += moveSpeed*Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Horizontal") != 0)
        {//Moves the player on the horizontal axis in the direction of the input
            _currentPosition.x += moveSpeed*Input.GetAxis("Horizontal");
        }
        if(Input.GetButtonDown("Run")){
            if(_isRunning){
                moveSpeed -= runSpeedDif;
            }
            else{moveSpeed += runSpeedDif;}
            _isRunning = !_isRunning;
        }
        transform.position = _currentPosition;
        
        //Changed to overlap circle
        //RaycastHit2D hit = Physics2D.Raycast(_currentPosition, new Vector2(0,1),  2f,
        //    LayerMask.NameToLayer("Opponent"), transform.localScale.y);
        
        Collider2D hit = Physics2D.OverlapCircle(_currentPosition, 0.5f, opponentMask);
        if (Input.GetButtonDown("Activate") && hit){
            Debug.Log("hit");
            GameManager.currentOpponent = hit.gameObject;
            SceneManager.LoadSceneAsync(debateScene);
        }
    }
}
