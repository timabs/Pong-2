using UnityEngine;

public class CPUPaddle : MonoBehaviour
{
    public Transform ballPos;
    public float paddleSpeed;
    public Rigidbody cpuRb;
    
    
    private void FixedUpdate()
    {
        //add random offset to add more of a potential error on AI's part. make range smaller to increase difficulty
        float randomOffset = Random.Range(-1f, 1f);
        //calc direction to move the paddle. basically making up the diff between the ball's Y pos and the paddles Y pos
        float moveDirection = Mathf.Clamp(ballPos.position.y - transform.position.y + randomOffset, -1f, 1f); 

        //actually move the paddle. only moving the Y, X and Z remain unchanged b/c paddles only move on Y.
        cpuRb.velocity = new Vector3(0f, moveDirection * paddleSpeed, 0f);
    }
}
