using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activator;
    public GameObject entity;
    public bool isAnimation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activator)
        {
            if (collision.CompareTag("Player"))
            {
                entity.SetActive(true);
            }
        }
        else if (isAnimation)
        {
            if (collision.CompareTag("Player"))
            {
                entity.SetActive(true);
                Time.timeScale = 0f;

            }
        }

        else
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(entity);
            }
        }
    }
}

