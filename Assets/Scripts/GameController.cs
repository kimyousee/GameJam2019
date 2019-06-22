using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int numEnemies = 1;
    public Canvas winningTextCanvas;
    public GameObject eventSystem;

    public string lastLevel = "Level6";

    public void killEnemy()
    {
        if (numEnemies <= 0 ){
            return;
        }
        numEnemies--;
        if (numEnemies > 0)
        {
            return;
        }
        // There are no more enemies.
        // Get the scene we're in
        string currentScene = SceneManager.GetActiveScene().name;

        // Play winning animation... or just put up some text for now
        // This canvas also has a button for the next level
        Canvas winCanvas = Instantiate(winningTextCanvas);
        Instantiate(eventSystem);

        Text[] winningTexts = winCanvas.GetComponentsInChildren<Text>();
        Button nextButton = winCanvas.GetComponentInChildren<Button>();
        Text buttonText = winCanvas.GetComponentInChildren<Text>();

        // Player has completed the level
        if (currentScene == lastLevel)
        {
            foreach (Text textComponent in winningTexts)
            {
                if (textComponent.name == "TitleText")
                {
                    textComponent.text = "You Win!";
                }
                else if (textComponent.name == "ButtonText")
                {
                    textComponent.text = "Main Menu";
                }
            }
        }
        else
        {
            foreach (Text textComponent in winningTexts)
            {
                if (textComponent.name == "TitleText")
                {
                    textComponent.text = "Target Eliminated!";
                }
                else if (textComponent.name == "ButtonText")
                {
                    textComponent.text = "Next Level";
                }
            }
        }

        nextButton.onClick.AddListener(onNextButtonClick);
    }

    void onNextButtonClick() {
        SceneManager.LoadScene(levelTransitions[SceneManager.GetActiveScene().name]);
    }



    public static Dictionary<string, string> levelTransitions = new Dictionary<string, string>
    {
        { "Level1", "Level2" },
        { "Level2", "Level3" },
        { "Level3", "Level4" },
        { "Level4", "Level5" },
        { "Level5", "Level6" },
        { "Level6", "Menu" },
    };
}
