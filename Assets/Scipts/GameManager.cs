using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool canPush=true;
    // Start is called before the first frame update
    
    

    protected void setCanPush(bool canPush)
    {
        GameManager[] gameManager=FindObjectsOfType<GameManager>();
        foreach(GameManager child in gameManager)
        {
            child.canPush=canPush;
        }
    }
}
