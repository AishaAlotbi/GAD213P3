using Systems.DateTime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        SceneManager.LoadScene(2);
        TimeManager.DateTime.AdvanceDay();
    }
}
