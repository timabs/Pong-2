using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Transform ball;
    public Rigidbody rb;
    public float speed;
    public float bounceSpeed;
    public Manager gameManager;
    public AudioSource audioSource;
    public AudioSource goalScore;
    public AudioSource goalGivenUp;
    public AudioClip[] paddleSounds;
    public float minCollisionDistance = 1.0f;
    private Vector3 lastCollisionPoint;
     // Last collision point
    // Start is called before the first frame update
    
    public void Start()
    {
        AddStartingForce();

    }
    void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.Range (-1.0f, 1.0f); //changed this at end due to some weird behavior

        Vector3 direction = new Vector3(x , y, 0);
        rb.AddForce(direction * speed, ForceMode.VelocityChange);
    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Paddles")
        {
            BounceBack(0f);
            Vector3 collisionPoint = collisionInfo.contacts[0].point;
            
            if (Vector3.Distance(collisionPoint, lastCollisionPoint) > minCollisionDistance)
            {
                if (paddleSounds.Length > 0) //could probably turn this into its own function and then call it
                                            // like RandomSound(); 
                {
                    int randomIndex = Random.Range(0, paddleSounds.Length);
                    AudioClip randomSound = paddleSounds[randomIndex];
                    audioSource.PlayOneShot(randomSound);
                }
            }

        }
        if (collisionInfo.collider.tag == "Barriers")
        {
            BounceBack(Random.Range(-0.4f , 0.4f));
        }
        
        if (collisionInfo.collider.tag == "CPUGoal")
        {
            gameManager.playerScore += 2;
            goalScore.Play();
            ResetPosition();
        }
        if (collisionInfo.collider.tag == "PlayerGoal")
        {
            gameManager.cpuScore += 2;
            goalGivenUp.Play();
            ResetPosition();
        }
    void BounceBack(float offset)
    {
        Vector3 collisionDirection = collisionInfo.contacts[0].point - ball.position;
        collisionDirection.Normalize(); //scaling the vector to length of 1 while preserving direction

        collisionDirection += new Vector3(0, offset, 0);
        rb.AddForce(collisionDirection * bounceSpeed, ForceMode.VelocityChange);

    }
       
    }
    private void ResetPosition()
        {
            rb.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            Invoke("AddStartingForce", 1.5f);

        }
    


     
}
