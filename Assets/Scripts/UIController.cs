using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    private static UIController curUIController;
    public static UIController instance => curUIController;

    [SerializeField] private WindowElement[] windowElements;
    private Dictionary<string, WindowElement> windowElementsDic = new Dictionary<string, WindowElement>();

    private void Start()
    {
        curUIController = this;
        for (int i = 0; i < windowElements.Length; i++)
        {
            windowElementsDic.Add(windowElements[i].name, windowElements[i]);
        }

        windowElementsDic["gameWindow"].uiElements[1].GetComponent<Button>().onClick.AddListener(SceneLoader.instance.Restart);
        windowElementsDic["completeWindow"].uiElements[0].GetComponent<Button>().onClick.AddListener(SceneLoader.instance.Next);
        windowElementsDic["loseWindow"].uiElements[0].GetComponent<Button>().onClick.AddListener(SceneLoader.instance.Restart);
    }

    public void SetCurLevelUI(int curLevel)
    {
        windowElementsDic["gameWindow"].uiElements[0].GetComponent<Text>().text = $"Level:{curLevel}";
    }

    public void SetGameState(GameState gameState)
    {
        windowElementsDic["gameWindow"].window.SetActive(false);
        windowElementsDic["completeWindow"].window.SetActive(false);
        windowElementsDic["loseWindow"].window.SetActive(false);
        switch (gameState)
        {
            case GameState.lose:
                windowElementsDic["loseWindow"].window.SetActive(true);
                break;
            case GameState.complete:
                windowElementsDic["completeWindow"].window.SetActive(true);
                break;
            case GameState.game:
                windowElementsDic["gameWindow"].window.SetActive(true);
                break;
        }
    }
}

[Serializable]
public struct WindowElement
{
    public string name;
    public GameObject window;
    public GameObject[] uiElements;

}

public enum GameState
{
    lose,
    complete,
    game
}
