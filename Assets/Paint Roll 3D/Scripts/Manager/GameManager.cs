using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoingKit;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform bushParent;
    public Color ParticleColor;
    public float totalCount,collected;
    public GameObject player;
    public ParticleSystem[] colorEffect;
    public bool gameOver = false;
    public List<GameObject> _BGs;
    public int count = 0;
    public List<Color> startColor;
    public List<Color> platColor;
    public List<Color> lastColor;
    public List<Color> fogColor;
    public Material[] playerMat;
    public int selectedNo = 0;
    public BoingReactorField reactTransform;
    public ParticleSystem popEffect;
   
    private void Awake()
    {
        if (!Instance)
            Instance = this;
       
        ParticleColor = Color.white;
        RenderSettings.fog = true;
        selectedNo = Random.Range(0, startColor.Count);
        // totalCount = 0;
    }
    void Start()
    {
        RenderSettings.fogColor = fogColor[selectedNo];
        CanvasManager.Instance.filler.color = lastColor[selectedNo];
        if(Audiomanager.Instance)
        Audiomanager.Instance.AudioClip.volume = 0;
        totalCount = FindObjectsOfType<BoingReactorFieldCPUSampler>().Length;
        SpawnBg();
        // reactTransform.gameObject.SetActive(false);
        // popEffect.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
    }

    public void DisableReactor(BoingReactorField bF,Transform spawnParent)
    {
        selectedNo = Random.Range(0, startColor.Count);
        player = FindObjectOfType<RotateScript>().gameObject;
        reactTransform = spawnParent.GetComponentInChildren<BoingReactorField>();
        bF.transform.position = reactTransform.transform.position;
        bF.transform.rotation = reactTransform.transform.rotation;
        bF.CellsX = reactTransform.CellsX;
        bF.CellsY = reactTransform.CellsY;
        bF.Effectors = reactTransform.Effectors;

    }
    public void StartGameMethod()
    {
      //  totalCount = 0;
        collected = 0;
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColor[selectedNo];
        CanvasManager.Instance.filler.color = lastColor[selectedNo];
        gameOver = false;
        print("addingValue");
    }

    public void RetryGame()
    {
        collected = 0;
        CanvasManager.Instance.filler.color = lastColor[selectedNo];
        gameOver = false;
    }
    public  void SpawnBg()
    {
        foreach (GameObject bgPrefab in _BGs)
        {
            bgPrefab.SetActive(false);
        }
        _BGs[selectedNo].SetActive(true);
        //GameObject spawnBg = Instantiate(_BGs[selectedNo], _BGs[selectedNo].transform.position, _BGs[selectedNo].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(collected>=totalCount&&!gameOver)
        {
            gameOver = true;
            //RotateScript rs =  player.GetComponent<RotateScript>();
            //rs.transform.parent = null;
            //rs.popeffects.Play();
            //   Destroy(player);
           // player.GetComponent<RotateScript>().rotSpeed = 0f;
            print("Level Completed!");
            CanvasManager.Instance.LevelWinPanel.SetActive(true);
            if (Audiomanager.Instance)
            Audiomanager.Instance.AudioClip.volume = 0;
            Vector3 newpos = new Vector3(popEffect.transform.position.x, 3f, popEffect.transform.position.z);
            Invoke("CallAdd", 1f);
            
        }
    }

    void CallAdd()
    {
        
    }

    public void ColorMethod(Collider other)
    {
        colorEffect[count].transform.position = other.transform.position;
        colorEffect[count].GetComponent<ParticleSystem>().startColor = ParticleColor;
        colorEffect[count].Play();
        colorEffect[count].GetComponent<AudioSource>().Play();
        if (count < colorEffect.Length-1)
            count++;
        else
            count = 0;
    }
}
