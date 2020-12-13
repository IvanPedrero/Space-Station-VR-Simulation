using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour {

    private GameManager gameManager;

    public GameObject menuPanel;
    public GameObject scoresSettings;
    public GameObject settingsPanel;

    private float distanceOfPlayer;
    public float activationDistance;

    public GameObject terminal;

    public Text engineeringText;

    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();

        ActivateMenuPanel();
	}

    void ActivateOnDistance()
    {
        //Get the distance of the player.
        this.distanceOfPlayer = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        if (this.distanceOfPlayer <= this.activationDistance)
        {
            this.terminal.SetActive(true);
        }
        else
        {
            this.terminal.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        ActivateOnDistance();

    }

    private void SetScores()
    {
        engineeringText.text = "Engineering Score : " + gameManager.engineeringActivityTimeText.text;

    }

    //Accessed from buttons.
    public void ActivateMenuPanel()
    {
        menuPanel.SetActive(true);
        scoresSettings.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ActivateScoresPanel()
    {
        menuPanel.SetActive(false);
        scoresSettings.SetActive(true);
        settingsPanel.SetActive(false);

        SetScores();
    }

    public void ActivateSettingsPanel()
    {
        menuPanel.SetActive(false);
        scoresSettings.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
