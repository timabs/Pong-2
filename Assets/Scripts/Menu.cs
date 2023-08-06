using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public SceneTracker sceneTracker;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void SettingsBack()
    {
        sceneTracker = SceneTracker.GetInstance();
        if (sceneTracker.GetPreviousSceneBuildIndex() == 2 )
        {
            SceneManager.LoadScene(2);

        }
        else if (sceneTracker.GetPreviousSceneBuildIndex() == 0)
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void SelectSettings()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
   {
        Debug.Log("QUIT!");
        Application.Quit();
   }
}
