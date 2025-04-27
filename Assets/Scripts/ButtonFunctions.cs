using Systems.DateTime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public TimeManager timeManager;
    public void ShiftToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShiftToCraftingScene()
    {
        SceneManager.LoadScene("Crafting");
    }

    public void EndDay()
    {
        //timeManager.AdvanceDayManually();
       SceneManager.LoadScene("Calander");
        
    }
}
