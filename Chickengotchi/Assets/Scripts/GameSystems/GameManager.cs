using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject settingsPannel;
    public Button openSettingsButton;
    private void Awake()
    {
        instance = this;   
    }

    public void ShowSettingsPanel()
    {
        openSettingsButton.gameObject.SetActive(false);
        settingsPannel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        openSettingsButton.gameObject.SetActive(true);
        settingsPannel.SetActive(false);
    }
}
