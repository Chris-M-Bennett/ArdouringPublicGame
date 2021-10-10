using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverworldControls : MonoBehaviour
{
    private Vector3 _currentPosition;
    [SerializeField] private float moveSpeed = 0.001f;
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
        transform.position = _currentPosition;
    }
}
