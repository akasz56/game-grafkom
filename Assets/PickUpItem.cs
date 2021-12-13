using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    GameManager gameManager;
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] bool autoDestroy = true;
    [SerializeField] float ttl = 10f;

    private void Start()
    {
        gameManager = GameManager.instance;
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        if (autoDestroy)
        {
            ttl -= Time.deltaTime;
            if (ttl < 0) { Destroy(gameObject); }
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
            );

        if (distance < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this.tag == "SampahDrop")
        {
            gameManager.updateSampah();
        }
    }

}
