﻿using UnityEngine.Events;

public class Events
{
    public delegate void DieAction();

    public delegate void CheckpointAchieved(int currentLevel);
    

    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    

}
