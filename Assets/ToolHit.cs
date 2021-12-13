using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHit : MonoBehaviour
{
    protected GameManager gameManager;

    public virtual void Hit()
    {
        
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }
}
