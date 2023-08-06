using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScoreVidChanger : MonoBehaviour
{
    public VideoClip[] videoClips;
    public VideoPlayer[] videoPlayers;
    public GameObject[] topMidObjects;
    public Manager gameManager;
    private List <int> cpuScoreThresholds = new List<int>() {10,20,30};
    private List <int> playerScoreThresholds = new List<int>() {10,20,30};

    private HashSet<int> scoredThresholds = new HashSet<int>();
    



    public void Update()
    {
        CheckScoreThreshold(gameManager.cpuScore, cpuScoreThresholds, scoredThresholds);
        CheckScoreThreshold(gameManager.playerScore, playerScoreThresholds, scoredThresholds);
    }
    
    
    private void CheckScoreThreshold(int score, List<int> scoreThresholds, HashSet<int> scoredThresholds)
    {
        
        foreach (int threshold in scoreThresholds)
        {
            if (score == threshold && !scoredThresholds.Contains(threshold))
            {
                
                Debug.Log("Threshold reached " + threshold);
                ExecuteThreshold(threshold);
                scoredThresholds.Add(threshold); 
                
            }
            
            
        }
    }

    private void ExecuteThreshold(int threshold)
    {
        //calc index based on threshold value. thresholds are in increments of 10. -1 insures we start at 0 and not 1

        int index = (threshold / 10) - 1;
//check if index is within valid range for topMidObjects array
        if (index >= 0 && index < topMidObjects.Length)
        {
            GameObject gameObjectToHide = topMidObjects[index];

            Debug.Log("Game Object " + index + "  hidden");

            gameObjectToHide.SetActive(false);
//after destroying current gameObj, check for index being less than clips array length
//we set a VideoClip var called clipToPlay to whatever the current index of the videoClips array is
//we then set videoPlayer.clip to that var we just set to the array
//then play whatever is in the video player which should be the current clip in the videoClips array
            if (index < videoClips.Length)
            {
                VideoClip clipToPlay = videoClips[index];
    
                VideoPlayer currentPlayer = videoPlayers[index];
                currentPlayer.clip = videoClips[index];
                currentPlayer.Play();
                Debug.Log("Video clip #" + index + " played");
    
            }
        }
    }
  


}
