using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpSpeed = 4;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public bool win = false;
    public TextMeshPro scoreText;
    public static int score = 0;
    public Animator anim;
    public float reloadTime = 0.5f;
    public GameObject bulletPrefab;

    private int jumps = 1;
    private bool isGrounded = true;
    private Rigidbody2D rb2d;
    private float elapsedTime = 0f;
    public GameObject background;
    public GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        UpdateScore();
        Shoot();
    }

    void Movement()
    {
        AdjustJumps();
        if (win)
            return;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            anim.SetFloat("Speed", speed);
            if (transform.localScale.x > 0)
            {
                Vector3 tmpVect = transform.localScale;
                tmpVect.x *= -1;
                transform.localScale = tmpVect;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
            anim.SetFloat("Speed", speed);
            if (transform.localScale.x < 0)
            {
                Vector3 tmpVect = transform.localScale;
                tmpVect.x *= -1;
                transform.localScale = tmpVect;
            }
        }
        else 
        {
            anim.SetFloat("Speed", 0.0f);
        }
    }

    void AdjustJumps() 
    {
        if (isGrounded)
        {
            jumps = 1;
        }
    }
    
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        anim.SetBool("isGrounded", isGrounded);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (jumps > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                jumps--;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.SetText(score.ToString());
    }

    void Shoot()
    {
        elapsedTime += Time.deltaTime;
        if ((Input.GetButton("Jump")) && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            Vector3 spawnPosBullet = spawnPos + new Vector3(0.0f, 0.1f, 0);
            Instantiate(bulletPrefab, spawnPosBullet, Quaternion.identity);
            elapsedTime = 0f;
        }
    }
}