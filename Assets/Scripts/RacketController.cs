using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _myPosition;
    private float _positionY;
    public float speed = 5f;
    public float limitY = 3.5f;

    public bool isPlayer;
    public string playerName;
    public KeyCode keyToUp;
    public KeyCode keyToDown;
    public KeyCode keyPlayerBotStatus;

    public Transform ballTransform;
    
    void Start()
    {
        _myPosition = transform.position;
    }

    // Update is called once per frame
    // The deltaTime is a period between frames
    void Update()
    {
        SetPosition();
        LimitControl();
        SetPlayerBotStatus();
    }

    void SetPosition()
    {
        _myPosition.y = _positionY;
        transform.position = _myPosition;

        if (isPlayer)
        {
            PlayerController();
        }
        else
        {
            BotController();
        }
    }

    void LimitControl()
    {
        if (_positionY > limitY)
        {
            _positionY = limitY;
        }

        if (_positionY < -limitY)
        {
            _positionY = -limitY;
        }
    }
    
    void PlayerController()
    {
        if (Input.GetKey(keyToUp))
        {
            _positionY += speed * Time.deltaTime;
        }
        if (Input.GetKey(keyToDown))
        {
            _positionY -= speed * Time.deltaTime;
        }
    }
    
    void BotController()
    {
        //_positionY = Mathf.Lerp(_positionY, ballTransform.position.y, 0.03f);
        if (ballTransform.position.y > _positionY && _positionY < limitY)
        {
            _positionY += speed * Time.deltaTime;
        }
        if (ballTransform.position.y < _positionY && _positionY > -limitY)
        {
            _positionY -= speed * Time.deltaTime;
        }
    }

    void SetPlayerBotStatus()
    {
        if (Input.GetKeyDown(keyPlayerBotStatus))
        {
            isPlayer = !isPlayer;
        }
    }

}
