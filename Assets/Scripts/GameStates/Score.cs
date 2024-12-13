using UnityEngine;
using System;

public static class Score                                                               //static class that isn't attached to any object
{
    private static int _score;


    public static Action<int> OnScoreEvent;                                             //ACTIONS -> way to register several methods in same place and then call them
    
    public static void AddToScore(int increaseScoreBy)
    {
        _score += increaseScoreBy;                                                      //increase score
        OnScoreEvent?.Invoke(_score);                                                   //check if OnScoreEvent is null.            Inoke -> registers listeners. When called, trigger all events attached to it
    }

    public static void ResetScore()
    {
        _score = 0;
    }

    public static int GetScore()
    { 
        return _score;
    }


}
