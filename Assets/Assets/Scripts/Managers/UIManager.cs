using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;     
    }
    #endregion

    [Header("Panels")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject nextLevelPanel;
    [SerializeField] GameObject gameInPanel;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI levelText;

    public void UpdateLevelText()
    {
        //if (PlayerPrefs.GetInt("FakeLevel") == default(int))
        //{
        //    PlayerPrefs.SetInt("FakeLevel", 1);
        //}

        levelText.text = "LEVEL " + PlayerPrefs.GetInt("FakeLevel").ToString();
    }

    public void OpenClosePanels(int panelType) //  0 start // 1 fail // 2 nexxtLevel
    {
        switch (panelType)
        {
            case 0:
                startPanel.SetActive(!startPanel.activeInHierarchy);
                gameInPanel.SetActive(true);

                Debug.LogError("SET USER ACTIVE");

                GameManager.instance.gameSituation = GameManager.GameSituation.isStarted;

                break;

            case 1:
                failPanel.SetActive(!failPanel.activeInHierarchy);
                gameInPanel.SetActive(true);

                Debug.LogError("SET USER PASSIVE");

                break;

            case 2:
                nextLevelPanel.SetActive(!nextLevelPanel.activeInHierarchy);
                gameInPanel.SetActive(true);

                Debug.LogError("SET USER PASSIVE");

                break;
        }
    }
}
