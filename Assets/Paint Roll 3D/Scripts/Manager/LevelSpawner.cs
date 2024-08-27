using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoingKit;
using UnityEngine.SceneManagement;

public class LevelSpawner : MonoBehaviour
{
    public List<GameObject> levels;
   // public int levelsNo = 0;
    GameObject PrevObj;
    public BoingReactorField reactor;
    bool restarted;
    int levelName = 1;

    private void Awake()
    {
        levelName = PlayerPrefs.GetInt("scene", 1);
        if (levelName > 111)
        {
            levelName = Random.Range(10, 112);
        }
      
       // levels[levelsNo].SetActive(true);
        // levels[levelsNo] = CanvasManager.Instance.retryObj;
        GameObject objToLoad = Resources.Load<GameObject>("levels/Level"+levelName);
        print("correct!");
        GameObject spawn = Instantiate(objToLoad, objToLoad.transform.position, objToLoad.transform.rotation);
        //  levels.Remove(levels[levelsNo]);
        PrevObj = spawn;
        GameManager.Instance.DisableReactor(reactor,spawn.transform);
        GameManager.Instance.StartGameMethod();

    }

   
    public void retryMethod()
    {
        restarted = true;
        DestroyImmediate(PrevObj);
        GameObject objToLoad = Resources.Load<GameObject>("levels/Level" + levelName);
        print("correct!");
        GameObject spawn = Instantiate(objToLoad, objToLoad.transform.position, objToLoad.transform.rotation);
        GameManager.Instance.DisableReactor(reactor, spawn.transform);
        GameManager.Instance.StartGameMethod();
        CanvasManager.Instance.LevelFailPanel.SetActive(false);
        PrevObj = spawn;
    }
    void Start()
    {

        GameManager.Instance.totalCount = FindObjectsOfType<BoingReactorFieldCPUSampler>().Length;
        BoingEffector[] boinglist = FindObjectsOfType<BoingEffector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        levelName++;
        DestroyImmediate(PrevObj);
        // Destroy(GameObject.Find("Boing Kit manager (don't delete)"));
        if (levelName > 149 - 1)
        {
            levelName = Random.Range(10, 149 - 1);
        }
        GameObject objToLoad = Resources.Load<GameObject>("levels/Level" + levelName);
        print("correct!");
        GameObject spawn = Instantiate(objToLoad, objToLoad.transform.position, objToLoad.transform.rotation);
        GameManager.Instance.DisableReactor(reactor, spawn.transform);
        GameManager.Instance.StartGameMethod();
        GameManager.Instance.totalCount = FindObjectsOfType<BoingReactorFieldCPUSampler>().Length;
        GameManager.Instance.SpawnBg();
        PrevObj = spawn;
        PlayerPrefs.SetInt("scene", levelName);

    }

}
