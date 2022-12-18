using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NotImplementedException = System.NotImplementedException;

public class BallController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    private Vector2 _mySpeed;
    private bool _started = false;

    private float horizontalLimit = 8.5f;
    public float speed = 5f;
    public float delayToStart = 2f;
    public Transform cameraTransform;
    public AudioClip ballCollisionSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartDelay();
        CheckHorizontalPosition();
    }

    void StartDelay()
    {
        delayToStart -= Time.deltaTime;
        if (!_started && delayToStart <= 0)
        {
            RandomStartDirection();
            myRigidBody.velocity = _mySpeed;
            _started = true;
        }
    }
    
    void RandomStartDirection()
    {
        bool randomX = Random.Range(0, 2).Equals(0);
        bool randomY = Random.Range(0, 2).Equals(0);
        _mySpeed.x = randomX ? speed : -speed;
        _mySpeed.y = randomY ? speed : -speed;
    }

    void CheckHorizontalPosition()
    {
        if (transform.position.x > horizontalLimit)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Player A Ganhou");
        }
        if (transform.position.x < -horizontalLimit)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Player B Ganhou");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(ballCollisionSound, cameraTransform.position);  
    }
    
}
