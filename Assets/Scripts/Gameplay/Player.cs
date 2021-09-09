using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int restartLevel;

    public Animator sceneSwitch;

    public float speed = 5f;

    private bool facingRight = true;
    private Animator anim;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    //variable for how high player jumps//
    [SerializeField]
    private float jumpForce = 300f;

    public Rigidbody2D rb { get; set; }

    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        float horizontal = Input.GetAxis("Horizontal");
        if (!dead)
        {
            anim.SetFloat("vSpeed", rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(horizontal));
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        if (horizontal > 0 && !facingRight && !dead)
        {
            Flip(horizontal);
        }

        else if (horizontal < 0 && facingRight && !dead)
        {
            Flip(horizontal);
        }
    }

    //jumping//
    private void Inputs()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneSwitch.SetTrigger("Switch");
            StartCoroutine(Restart());
        }

    }

    private void Flip(float horizontal)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(restartLevel);
    }
}
