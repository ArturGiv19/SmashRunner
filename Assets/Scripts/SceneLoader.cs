using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneLoader()
    {
        sceneLoader = this;
    }

    private static SceneLoader sceneLoader;
    public static SceneLoader instance => sceneLoader;
    public int curLevel;
    

    private void Start()
    {        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            curLevel = 1;
            PlayerPrefs.SetInt("curLevel", curLevel);
            SceneManager.LoadScene(curLevel);
        }
        curLevel = PlayerPrefs.GetInt("curLevel");
        if (SceneManager.GetActiveScene().buildIndex != curLevel)
        {
            SceneManager.LoadScene(curLevel);
        }


    }    
    public void Restart()
    {
        SceneManager.LoadScene(curLevel);
    }
    public void Next()
    {
        curLevel++;
        if (curLevel > 3)
        {
            curLevel = 1;
        }
        PlayerPrefs.SetInt("curLevel", curLevel);        
        SceneManager.LoadScene(curLevel);
    }
}
