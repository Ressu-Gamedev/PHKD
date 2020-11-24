using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool enemy;
    public bool canMove;
    public AudioSource boxSource;
    [SerializeField] AudioClip boxBreak;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
            if (canMove)
            {
                rb.position = new Vector2(rb.position.x + speed * (-1), rb.position.y);
            }
    }
    private void OnTriggerEnter2D(Collider2D see)
    {
        if (see.CompareTag("Player"))
        {
            canMove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D see)
    {
        if (see.CompareTag("Player"))
        {
            canMove = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            if (!canMove)
            {
                boxSource.PlayOneShot(boxBreak);
                Destroy(gameObject, 1f);
            }
            else
            {
                Destroy(gameObject, 1f);
            }
        }
    }
}
