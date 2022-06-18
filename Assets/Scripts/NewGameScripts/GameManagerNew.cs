using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerNew : MonoBehaviour
{
    private Dictionary<Type, IGameState> gameStatesMap;
    private IGameState gameStateCurrent;
    // Start is called before the first frame update
    void Start()
    {
        this.InitGameStates();
        this.SetGameStateByDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameStateCurrent != null)
        {
            this.gameStateCurrent.Update();
        }
    }

    private void InitGameStates()
    {
        this.gameStatesMap = new Dictionary<Type, IGameState>();
        this.gameStatesMap[typeof(GameStateOnPlay)] = new GameStateOnPlay();
        this.gameStatesMap[typeof(GameStateOnPause)] = new GameStateOnPause();
        this.gameStatesMap[typeof(GameStateGameOver)] = new GameStateGameOver();
        this.gameStatesMap[typeof(GameStateOnStartMenu)] = new GameStateOnStartMenu();

    }

    private void SetGameState(IGameState newGameState)
    {
        if (this.gameStateCurrent != null)
        {
            this.gameStateCurrent.Exit();
        }
        this.gameStateCurrent = newGameState;
        this.gameStateCurrent.Enter();
    }

    private void SetGameStateByDefault()
    {
        this.SetGameStateOnPlay();
    }

    private IGameState GetGameState<T>() where T : IGameState
    {
        var type = typeof(T);
        return this.gameStatesMap[type];
    }

    public void SetGameStateOnPlay()
    {
        var gameState = this.GetGameState<GameStateOnPlay>();
        this.SetGameState(gameState);
    }

    public void SetGameStateOnPause()
    {
        var gameState = this.GetGameState<GameStateOnPause>();
        this.SetGameState(gameState);
    }

    public void SetGameStateGameOver()
    {
        var gameState = this.GetGameState<GameStateGameOver>();
        this.SetGameState(gameState);
    }

    public void SetGameStateOnStartMenu()
    {
        var gameState = this.GetGameState<GameStateOnStartMenu>();
        this.SetGameState(gameState);
    }
}
