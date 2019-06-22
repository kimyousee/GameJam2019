using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int numEnemies = 1;
    public Canvas winningTextCanvas;

    public string lastLevel = "Level6";

    public void killEnemy()
    {
        if (numEnemies <= 0 {
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
        // Player has completed the level
        if (currentScene == lastLevel)
        {
            // Play winning animation... or just put up some text for now
            // This canvas also has a main menu button
            Instantiate(winningTextCanvas, new Vector3(), Quaternion.identity);
        }
        else
        {
            // Transition to next level
            SceneManager.LoadScene(levelTransitions[SceneManager.GetActiveScene().name]);
        }
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
