using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float upForce;
    public Rigidbody playerRb;
    public UserControls userControls;

    
    void Awake()
    {
        userControls = FindObjectOfType<UserControls>();
        userControls.upInput = PlayerPrefs.GetString("UpInput", "W");
        userControls.downInput = PlayerPrefs.GetString("DownInput", "S");
    }
    
    void FixedUpdate()
    {   
        if (Input.GetKey(userControls.upInput.ToString()))
        {
            playerRb.AddForce(0, upForce * Time.deltaTime, 0);    
        }

        if (Input.GetKey(userControls.downInput.ToString()))
        {
            playerRb.AddForce(0, -1 * upForce * Time.deltaTime, 0);
        }

    }
}
