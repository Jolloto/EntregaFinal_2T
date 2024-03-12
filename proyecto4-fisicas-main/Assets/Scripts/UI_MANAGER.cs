using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_MANAGER : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private GameObject MenuPanel;

    [SerializeField] private GameObject PausaPanel;

    private PlayerController PlayerControllerScript;


    void Start()
    {
        
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

    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }


}
