using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanamable : ToolHit
{
    [SerializeField] GameObject nextObject;

    public override void Hit()
    {
        Destroy(gameObject);

        Vector3 position = transform.position;
        GameObject go = Instantiate(nextObject);
        position.y += 0.5f;
        go.transform.position = position;
        go.tag = "TanamanSiramable";
    }

    private void OnDestroy()
    {
        gameManager.updateTanamable();
    }
}
