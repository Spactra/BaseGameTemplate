using ElephantSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;

        //UpdatePlayerPerfs();
    }
    #endregion

    public enum GameSituation
    {
        notStarted, isStarted, onLevelEnd, isEnded
    } 

    public int fakeLevelNum = 1; // ekranda gözüken (yani fake olmasınn nedeni aslında aynı levellerin dönmesi ama yeni elvelmiş gibi gösterilmesi)
    public int levelNum = 1; // gerçek level sayımız index e göre

    public GameSituation gameSituation;

    private void Start()
    {
        gameSituation = GameSituation.notStarted;
        UpdatePlayerPerfs();
    }

    void UpdatePlayerPerfs()
    {
        fakeLevelNum = PlayerPrefs.GetInt("FakeLevel",1);
        levelNum = PlayerPrefs.GetInt("Level",1);

        UIManager.instance.UpdateLevelText();
    }

    public void RecordLevel()
    {
        PlayerPrefs.SetInt("Level", levelNum); 
    }

    public void RecordFakeLevel()
    {
        PlayerPrefs.SetInt("FakeLevel", fakeLevelNum);  
    }

    public void EndGame(int endType) // 2 success // 1 fail
    {
        gameSituation = GameSituation.isEnded;

        switch (endType)
        {
            case 2:
                UIManager.instance.OpenClosePanels(2);
                Elephant.LevelCompleted(fakeLevelNum); // düzenlenecek
                break;
            case 1:
                UIManager.instance.OpenClosePanels(1);
                Elephant.LevelFailed(fakeLevelNum); // düzenlenecek
                break;
        }
    }

    public void NextLevel()
    {
        fakeLevelNum++;
        levelNum++;

        RecordLevel();
        RecordFakeLevel();

        if (levelNum == SceneManager.sceneCountInBuildSettings-1)
        {
            levelNum = 1;
            RecordLevel();
        }

        SceneManager.LoadScene(levelNum);
    }

    public void RetryLevel()
    {
        //if (PlayerPrefs.GetInt("Level") == default(int))
        //{
        //    PlayerPrefs.SetInt("Level", 1);
        //}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
