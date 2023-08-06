using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Manager : MonoBehaviour

{
    public int playerScore = 0;
    public int cpuScore = 0;
    public Text playerScoreText;
    public Text cpuScoreText;
    public GameObject cpuPaddle;
    public GameObject playerPaddle;
    public GameObject playerPaddleRope;
    public GameObject cpuPaddleRope;
    public GameObject jermaPic;
    public GameObject jermaRopeRight;
    public GameObject jermaRopeLeft;
    public BallBehavior ball;
    public ScoreVidChanger scoreVidChanger;



    void Awake()
    {
        
        Invoke("JermaRopeStart", 2000f);
        Invoke("AttachRopeStart", 2000f);
        ball.Start();
    }
    
    void Start()
    {
        

    }
    void AttachRopeStart()
    {
        playerPaddleRope.transform.rotation = Quaternion.Euler(0,0,0);
        playerPaddleRope.transform.position = new Vector3(17.60f,4.63f,34.95f);
        cpuPaddleRope.transform.rotation = Quaternion.Euler(0,0,0);
        cpuPaddleRope.transform.position = new Vector3(-17.60f,4.63f,34.95f);
    }

    void JermaRopeStart()
    {
        Vector3 ropeRightPos = new Vector3(9.90999985f,6.94999981f,34.95f);
        Vector3 ropeRightRotate = new Vector3(0f,0f,104.274925f);
        Vector3 ropeScale = new Vector3(61.1521835f,155.279785f,98.3708038f);
        jermaRopeRight.transform.position = ropeRightPos;
        jermaRopeRight.transform.rotation = Quaternion.Euler(ropeRightRotate);
        jermaRopeRight.transform.localScale = ropeScale;

        jermaRopeLeft.transform.position = new Vector3(-9.90999985f,6.94999981f,34.95f);
        jermaRopeLeft.transform.rotation = Quaternion.Euler(0,0,78.686f);
        jermaRopeLeft.transform.localScale = ropeScale;

        
    }
    
    
    void Update()
    {
        playerScoreText.text = playerScore.ToString();
        cpuScoreText.text = cpuScore.ToString();
        AttachRopeToPlayer();
        AttachRopeToCpu();
        scoreVidChanger.Update();
    }

    void AttachRopeToPlayer()
    {
        Vector3 playerPosition = playerPaddle.transform.position;

        Vector3 playerPaddleRopePos = playerPaddleRope.transform.position;
        Vector3 attachmentOffset = new Vector3(-1 * 0.165f , 5.5f, 0f);
        playerPaddleRopePos = playerPosition + attachmentOffset;

        playerPaddleRope.transform.position = playerPaddleRopePos;

        

    }
    void AttachRopeToCpu()
    {
        Vector3 cpuPos = cpuPaddle.transform.position;
        Vector3 cpuRopePos = cpuPaddleRope.transform.position;
        Vector3 attachmentOffset = new Vector3(0.165f, 5.5f, 0f);
        cpuRopePos = cpuPos + attachmentOffset;
        cpuPaddleRope.transform.position = cpuRopePos;
    }
    
    
}
