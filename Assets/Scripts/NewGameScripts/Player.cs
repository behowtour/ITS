using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Controller controller;
    public delegate void PlayerHandler(object sender, int ordDiff);
    public event PlayerHandler OnOrdinateChangedEvent;

    private float lastOrdValue;
    private Dictionary<Type, IPlayerState> playerStatesMap;
    private IPlayerState playerStateCurrent;

    void Start()
    {
        lastOrdValue = this.transform.position.y;
        InitPlayerStates();
        SetPlayerStateByDefault();
    }

    // Update is called once per frame
    void Update()
    {
        int coordDiff = (int)(this.transform.position.y - lastOrdValue);
        if (coordDiff >= 1)
        {
            //ScoreUp(coordDiff);
            this.OnOrdinateChangedEvent?.Invoke(this, coordDiff);
            lastOrdValue = this.transform.position.y;
        }

        if (this.playerStateCurrent != null)
        {
            this.playerStateCurrent.Update(this, coordDiff);
        }
    }

    private void SetPlayerState(IPlayerState newPlayerState)
    {
        if (this.playerStateCurrent != null)
        {
            this.playerStateCurrent.Exit(this);
        }
        this.playerStateCurrent = newPlayerState;
        this.playerStateCurrent.Enter(this);
    }

    private void InitPlayerStates()
    {
        this.playerStatesMap = new Dictionary<Type, IPlayerState>();
        this.playerStatesMap[typeof(PlayerStateIdle)] = new PlayerStateIdle();
        this.playerStatesMap[typeof(PlayerStateStartJump)] = new PlayerStateStartJump();
        this.playerStatesMap[typeof(PlayerStateReleasePoint)] = new PlayerStateReleasePoint();
        this.playerStatesMap[typeof(PlayerStateFallDown)] = new PlayerStateFallDown();
        this.playerStatesMap[typeof(PlayerStateClickPoint)] = new PlayerStateClickPoint();
    }

    private void SetPlayerStateByDefault()
    {
        this.SetPlayerStateIdle();
    }

    private IPlayerState GetPlayerState<T>() where T : IPlayerState
    {
        var type = typeof(T);
        return this.playerStatesMap[type];
    }

    public void SetPlayerStateIdle()
    {
        var playerState = this.GetPlayerState<PlayerStateIdle>();
        this.SetPlayerState(playerState);
    }

    public void SetPlayerStateStartJump()
    {
        var playerState = this.GetPlayerState<PlayerStateStartJump>();
        this.SetPlayerState(playerState);
    }

    public void SetPlayerStateReleasePoint()
    {
        var playerState = this.GetPlayerState<PlayerStateReleasePoint>();
        this.SetPlayerState(playerState);
    }

    public void SetPlayerStateFallDown()
    {
        var playerState = this.GetPlayerState<PlayerStateFallDown>();
        this.SetPlayerState(playerState);
    }

    public void SetPlayerStateClickPoint()
    {
        var playerState = this.GetPlayerState<PlayerStateClickPoint>();
        this.SetPlayerState(playerState);
    }
}
