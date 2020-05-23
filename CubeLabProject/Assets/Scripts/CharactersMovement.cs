using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    Character[] charactersArray;
    public int remainingMoves = 50;

    bool isInputAllowed = true;


    private void Awake()
    {
        charactersArray = FindObjectsOfType<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Door.isAllOpen)
        {
            isInputAllowed = false;
        }
        else
        {
            isInputAllowed = true;
        }

        if (isInputAllowed)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (isAllCharMovedSW())
                {
                    remainingMoves -= 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (isAllCharMovedSE())
                {
                    remainingMoves -= 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (isAllCharMovedNW())
                {
                    remainingMoves -= 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isAllCharMovedNE())
                {
                    remainingMoves -= 1;
                }
            }
        }
    }

    bool isAllCharMovedSW()
    {
        foreach (Character c in charactersArray)
        {
            if (!c.SWMovement())
            {
                return false;
            }
        }
        return true;
    }
    bool isAllCharMovedSE()
    {
        foreach (Character c in charactersArray)
        {
            if (!c.SEMovement())
            {
                return false;
            }
        }
        return true;
    }
    bool isAllCharMovedNW()
    {
        foreach (Character c in charactersArray)
        {
            if (!c.NWMovement())
            {
                return false;
            }
        }
        return true;
    }
    bool isAllCharMovedNE()
    {
        foreach (Character c in charactersArray)
        {
            if (!c.NEMovement())
            {
                return false;
            }
        }
        return true;
    }
}
