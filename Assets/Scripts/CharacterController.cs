using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Joystick joystick;

    public float jumpForce;
    public Rigidbody2D rb2d;

    public bool jumped = false;

    public bool mobileControls;
    //for Gun
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioClip bullet_fired;
    public AudioClip walking;
    public AudioClip jumpedAudio;
    [SerializeField] AudioSource gunAudio;
    public float lowPitch;
    public float highPitch;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //playerAudio = GetComponent<AudioSource>();
        //gunAudio = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!mobileControls)
        {
            float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            rb2d.position = new Vector2(rb2d.position.x + horizontalInput, rb2d.position.y);
        }
        else 
        {
            float horizontalInput = joystick.Horizontal * speed * Time.deltaTime;
            rb2d.position = new Vector2(rb2d.position.x + horizontalInput, rb2d.position.y);
        }

        Jumping();
        if (Input.GetButtonDown("Fire1"))
        {
            ShootingGun();
        }


    }

    public void Jumping()
    {
        if(!mobileControls)
        {
            if ((Input.GetButtonDown("Jump")) && jumped == false)            // Jumping Code
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            }
            if (rb2d.velocity.y < 0)                  // Jump (allows for floaty jump at start and fall quick at end)
            {
                rb2d.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb2d.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        else
        {
            if (joystick.Vertical > 0.1 && jumped == false)            // Jumping Code
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            }
            if (rb2d.velocity.y < 0)                  // Jump (allows for floaty jump at start and fall quick at end)
            {
                rb2d.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb2d.velocity.y > 0 && joystick.Vertical < 0.1f)
            {
                rb2d.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
    public void ShootingGun() 
    {
        gunAudio.pitch = Random.Range(lowPitch, highPitch);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        gunAudio.PlayOneShot(bullet_fired, 0.2F);
    }

}
