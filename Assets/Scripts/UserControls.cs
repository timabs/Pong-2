using UnityEngine;

public class UserControls : MonoBehaviour
{
    
    //instead of making these public, make getters for PlayerMovement to call on
    public string upInput;
    public string downInput;

    public void ReadUpInput(string up)
    {
        upInput = up;
        PlayerPrefs.SetString("UpInput" , up);
    }

    public void ReadDownInput(string down)
    {
        downInput = down;
        PlayerPrefs.SetString("DownInput" , down);
    }
}
