using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameController()
    {
        curGameController = this;
    }
    private static GameController curGameController;
    public static GameController instance => curGameController;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private UIController uiController;

    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForEndOfFrame();
        uiController.SetCurLevelUI(SceneLoader.instance.curLevel);
        StartGame();
    }

    public void StartGame()
    {
        playerController.Run();
        playerController.player.spline.enabled = true;
        uiController.SetGameState(GameState.game);
    }
    public void CompleteGame()
    {
        playerController.Complete();
        uiController.SetGameState(GameState.complete);
    }
    public void LoseGame()
    {
        playerController.Lose();
        StartCoroutine(StaticClass.CustomDelay(1, (() => { uiController.SetGameState(GameState.lose); })));

    }


}

public static class StaticClass
{
    public static IEnumerator CustomDelay(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}

