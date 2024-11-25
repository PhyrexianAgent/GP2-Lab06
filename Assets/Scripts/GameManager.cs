using UnityEngine;

public class GameManager
{
    public static int Score {get; private set;}

    public static void AddScore(int amount) => Score += amount;
}
