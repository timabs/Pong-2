using UnityEngine;

public class Rope2Spring : MonoBehaviour
{
    public SpringJoint playerRopeJoint;
    public SpringJoint cpuRopeJoint;
    [SerializeField] public SpringJoint overlookerR;
    [SerializeField] public SpringJoint overlookerL;
    public Manager gameManager;
    public float upperYBoundary;
    public float lowerYBoundary;
    public float defaultSpring = 1000f;
    public float defaultDamper = 0f;
    private float initialSpring;
    private float initialDamper;
    public float minSpringLimit = 50f;
    private float minDamperLimit = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        

    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerSJConfig();
        CpuSJConfig();

        
    }

    void PlayerSJConfig()
    {
        initialSpring = playerRopeJoint.spring;
        initialDamper = playerRopeJoint.damper;

        
        if (gameManager.jermaRopeRight.transform.position.y >= upperYBoundary) 
        {
            float t  = Mathf.InverseLerp(upperYBoundary, upperYBoundary + 7, gameManager.jermaRopeRight.transform.position.y);
            
            playerRopeJoint.spring = Mathf.Lerp(initialSpring, minSpringLimit, t);
            playerRopeJoint.damper = Mathf.Lerp(initialDamper, minDamperLimit, t);
            overlookerR.spring = Mathf.Lerp(initialSpring, minSpringLimit, t);
            overlookerR.damper = Mathf.Lerp(initialDamper, minDamperLimit, t);
 
        }
        else if (gameManager.jermaRopeRight.transform.position.y <= lowerYBoundary)
        {
            playerRopeJoint.spring = 175f;
            overlookerR.spring = 175f;
        }
        else
        {
            playerRopeJoint.spring = defaultSpring;
            playerRopeJoint.damper = defaultDamper;
            overlookerR.spring = defaultSpring;
            overlookerR.damper = defaultDamper;
        }
    }
    void CpuSJConfig()
    {
        initialSpring = cpuRopeJoint.spring;
        initialDamper = cpuRopeJoint.damper;

        
        if (gameManager.jermaRopeLeft.transform.position.y >= upperYBoundary) 
        {
            float t  = Mathf.InverseLerp(upperYBoundary, upperYBoundary + 7, gameManager.jermaRopeLeft.transform.position.y);
            
            cpuRopeJoint.spring = Mathf.Lerp(initialSpring, minSpringLimit, t);
            cpuRopeJoint.damper = Mathf.Lerp(initialDamper, minDamperLimit, t);
            overlookerL.spring = Mathf.Lerp(initialSpring, minSpringLimit, t);
            overlookerL.damper = Mathf.Lerp(initialDamper, minDamperLimit, t);
 
        }
        else if (gameManager.jermaRopeRight.transform.position.y <= lowerYBoundary)
        {
            cpuRopeJoint.spring = 175f;
            overlookerL.spring = 175f;
        }
        else
        {
            cpuRopeJoint.spring = defaultSpring;
            cpuRopeJoint.damper = defaultDamper;
            overlookerL.spring = defaultSpring;
            overlookerL.damper = defaultDamper;
        }
    }
}
