using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IState
{
    float timer = 0;
    public void OnEnter(GameManager gameManager)
    {
        LevelManager.Instance.DrawMap();
    }
    public void OnExecute(GameManager gameManager)
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            gameManager.ChangeState(new PlayState());
        }
    }
    public void OnExit(GameManager gameManager)
    {
        

    }
}
