using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siramable : ToolHit
{
    [SerializeField] GameObject nextObject;

    public override void Hit()
    {
        Destroy(gameObject);

        Vector3 position = transform.position;
        GameObject go = Instantiate(nextObject);
        go.transform.position = position;
        go.tag = "TanamanDone";
    }

    private void OnDestroy()
    {
        gameManager.updateSiramable();
    }
}
