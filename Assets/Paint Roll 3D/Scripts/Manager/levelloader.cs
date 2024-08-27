using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelloader : MonoBehaviour
{
    public int levelNo ;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        levelNo = PlayerPrefs.GetInt("level", 1);
       StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(LoadingScreen(1));
    }

    IEnumerator LoadingScreen(int index)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(1);
        while (!Operation.isDone)
        {
            float progress = Mathf.Clamp01(Operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
