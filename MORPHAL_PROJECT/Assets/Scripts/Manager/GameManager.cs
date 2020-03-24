using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public DifficultyLevel difficulty;

    private void Awake()
    {
        if (inst)
        {
            Destroy(gameObject);
        }
        else
        {
            inst = this;
        }
    }

}

public enum DifficultyLevel
{
    Easy,
    Normal,
    Hard
}
