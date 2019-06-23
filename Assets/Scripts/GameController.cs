using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int numEnemies = 1;
    public Canvas winningTextCanvas;
    public Canvas startScreen;
    public GameObject eventSystem;
    public Sprite menuButtonImage;
    public Sprite nextButtonImage;
    public Material endGameSkybox;

    public string lastLevel = "Level9";


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
        Image buttonImage = nextButton.GetComponent<Image>();
        Text buttonText = winCanvas.GetComponentInChildren<Text>();

        // Player has completed the last level
        if (currentScene == lastLevel)
        {
            buttonImage.sprite = menuButtonImage;
            //RenderSettings.skybox = endGameSkybox;
            foreach (Text textComponent in winningTexts)
            {
                if (textComponent.name == "TitleText")
                {
                    textComponent.text = "ALL TARGETS ERATICATED";
                    break;
                }
            }
        }
        else
        {
            buttonImage.sprite = nextButtonImage;
            foreach (Text textComponent in winningTexts)
            {
                if (textComponent.name == "TitleText")
                {
                    textComponent.text = "Target Eliminated!";
                    break;
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
        { "Level6", "Level7" },
        { "Level7", "Level8" },
        { "Level8", "Level9" },
        { "Level9", "Menu" },
    };
}
