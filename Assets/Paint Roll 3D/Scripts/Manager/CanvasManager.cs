using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public Image filler;
    public GameObject LevelWinPanel;
    public GameObject LevelFailPanel;
    int levelNo = 0;
    int levelShowNo = 0;
    public TextMeshProUGUI leveltext;
    public LevelSpawner spawner;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        levelNo = PlayerPrefs.GetInt("level", 1);
        levelShowNo = PlayerPrefs.GetInt("levelshow", 1);
        leveltext.text = "Level " + levelShowNo;
    }
    private void Start()
    {
        
    }

    void Update()
    {
        filler.fillAmount = GameManager.Instance.collected / GameManager.Instance.totalCount;
    }
    public void nextlevel()
    {
        //levelNo++;
        //PlayerPrefs.SetInt("level", levelNo);
         int levelSpawnNo = PlayerPrefs.GetInt("levelspawn", 0);
        //if (levelSpawnNo < 199)
            levelSpawnNo++;
        //else
          //  levelSpawnNo = 0;
        levelShowNo++;
        PlayerPrefs.SetInt("levelshow",levelShowNo);
        PlayerPrefs.SetInt("levelspawn", levelSpawnNo);
        LevelWinPanel.SetActive(false);
        spawner.NextLevel();
        leveltext.text = "Level " + levelShowNo;
        // SceneManager.LoadScene(levelNo);
    }

  
    public void retryMethod()
    {
        //CanvasManager.Instance.retryObj = Instantiate(PrevObj);
        //CanvasManager.Instance.retryObj.SetActive(false);

    }


}
