using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    private static SceneTracker instance;
    public int previousSceneBuildIndex;
    public int currentSceneBuildIndex;


    void Awake()
    {
       // Check if an instance of SceneTracker already exists
        if (instance == null)
        {
            // If not, assign this instance as the static reference
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate instance
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    
    }
    void Update()
    {
        if (currentSceneBuildIndex != SceneManager.GetActiveScene().buildIndex)
        {
            previousSceneBuildIndex = currentSceneBuildIndex;
            currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        }
    
    }
    public int GetPreviousSceneBuildIndex()
    {
        return previousSceneBuildIndex;
    }
    public int GetCurrentSceneBuildIndex()
    {
        return currentSceneBuildIndex;
    }
    public static SceneTracker GetInstance()
    {
        return instance;
    }

}
