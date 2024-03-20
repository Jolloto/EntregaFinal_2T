using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class UI_MANAGER : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private GameObject MenuPanel;

    [SerializeField] private Button playButton;

    [SerializeField] private GameObject PausaPanel;

    [SerializeField] private int currentRound = 1;

    [SerializeField] public TextMeshProUGUI roundText;
    
    public static GameController instance;

    private PlayerController playerControllerScript;


    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        playButton.onClick.AddListener(() => {playerControllerScript.StartGame();});

        UpdateRoundText(currentRound);

    }

    void Awake()
    {
        instance = this;
        UpdateRoundText();
    }

    public void AdvanceToNextRound()
    {
        currentRound++;
        UpdateRoundText();
    }

    public void UpdateRoundText()
    {
        roundText.text = "Ronda " + currentRound;
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
    }

    public void HideMenuPanel()
    {
        MenuPanel.SetActive(false);
    }

    public void ShowPausaPanel()
    {
        PausaPanel.SetActive(true);
    }

    public void HidePausaPanel()
    {
        PausaPanel.SetActive(false);
    }

    public void ShowGameOverPanel(int lives)
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }

}
