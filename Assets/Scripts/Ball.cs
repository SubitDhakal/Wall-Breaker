using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    //Config parameters
    
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.5f;
    [SerializeField] AudioClip[] ballSounds;

    

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached References
    AudioSource myAudioSource;
    Rigidbody2D myrigidBody2D;



    // Start is called before the first frame update
    void Start()
    {
       paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myrigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted )
        {
            LockBallOnPaddle();
            LaunchBallOnClick();
        }
       

    }
    private void LaunchBallOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myrigidBody2D.velocity = new Vector2(xPush,yPush);

           

        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myrigidBody2D.velocity += velocityTweak;

        }
    }


    private void LockBallOnPaddle()
    {

        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }
}
