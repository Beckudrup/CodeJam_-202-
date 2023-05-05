using System;

public static class GameEvents
{
    public static event Action TimeIsUp;
    public static event Action GameEnded;
    public static event Action FinishGameAnimPlayed;

    public static void OnTimeIsUp() => TimeIsUp?.Invoke();
    public static void OnGameEnded() => GameEnded?.Invoke();
    public static void OnFinishGameAnimPlayed() => FinishGameAnimPlayed?.Invoke();
}
