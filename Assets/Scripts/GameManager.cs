using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int MaxNumberOfShots = 3;

    private int _usedNumberOfShots;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UseShot()
    {
        _usedNumberOfShots++;
    }

    public bool HasEnoughShots()
    {
        if(_usedNumberOfShots < MaxNumberOfShots)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
