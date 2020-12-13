using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartSimulation()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowPanelSettings()
    {
        print("Showed Panel Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
