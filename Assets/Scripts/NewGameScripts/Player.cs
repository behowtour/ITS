using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public PlayerAnimator playerAnimator;
    public Controller controller;
    public delegate void PlayerHandler(object sender, int ordDiff);
    public event PlayerHandler OnOrdinateChangedEvent;

    private float lastOrdValue, lastVelocity, maxOrdValue;
    private Dictionary<Type, IPlayerState> playerStatesMap;
    private IPlayerState playerStateCurrent;

    void Start()
    {
        lastOrdValue = this.transform.position.y;
        lastVelocity = 0;
        //InitPlayerStates();
        //SetPlayerStateByDefault();
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = (this.transform.position.y - lastOrdValue);
        float accelerate = velocity - lastVelocity;
        if (this.transform.position.y >= maxOrdValue + 1)
        {
            
            //ScoreUp(coordDiff);
            this.OnOrdinateChangedEvent?.Invoke(this, 1);
            maxOrdValue = this.transform.position.y;
            
        }
        lastOrdValue = this.transform.position.y;
        lastVelocity = velocity;
        this.animator.SetFloat("velocity", velocity);
        this.animator.SetFloat("accelerate", accelerate);
        Debug.Log( "Velocity = " +this.animator.GetFloat("velocity")+" | Accelerate = "+ this.animator.GetFloat("accelerate"));
        //this.playerAnimator.SetVelocity(velocity);
        //this.playerAnimator.SetAccelerate(accelerate);
        //if (this.playerStateCurrent != null)
        //{
        //    this.playerStateCurrent.Update(this, velocity,accelerate);
        //}
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
