using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galiable : ToolHit
{
    [SerializeField] GameObject nextObject;

    public override void Hit()
    {
        Destroy(gameObject);

        Vector3 position = transform.position;
        GameObject go = Instantiate(nextObject);
        go.transform.position = position;
        go.tag = "TanahTanamable";
    }

    private void OnDestroy()
    {
        gameManager.updateGaliable();
    }
}
