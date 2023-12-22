using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IState
{
    float timer = 0;
    public void OnEnter(GameManager gameManager)
    {
        timer += Time.deltaTime;
        LevelManager.Instance.DrawMap();
        if(timer >= 0.5f)
        {
            gameManager.ChangeState(new PlayState());
        }
    }
    public void OnExecute(GameManager gameManager)
    {

    }
    public void OnExit(GameManager gameManager)
    {
        

    }
}
