using Systems.DateTime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public TimeManager timeManager;
    public void ShiftToGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ShiftToCraftingScene()
    {
        SceneManager.LoadScene(1);
    }

    public void EndDay()
    {
        timeManager.AdvanceDayManually();
       // SceneManager.LoadScene(2);
        
    }
}
