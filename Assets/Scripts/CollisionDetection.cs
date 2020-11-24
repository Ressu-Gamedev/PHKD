using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private Collider2D charCollider;
    public CharacterController charControl;
    public GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {

        charCollider = GetComponent<Collider2D>();
        charControl = GetComponentInParent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Dead();
        }

    }


    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy") || enemy.CompareTag("SpecialEnemy"))
        {
            // Begin GameOver screen
            Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("Died");
        charControl.enabled = false;
        gameOverPanel.SetActive(true);
    }

    void OnTriggerStay2D(Collider2D floor)
    {
        if (charControl.jumped)
        {
            if (floor.CompareTag("Ground"))
            {
                Debug.Log("grounded");
                charControl.jumped = false;
            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!charControl.jumped)
            Debug.Log("not grounded");
        charControl.jumped = true;
    }

}