using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBase : MonoBehaviour
{
    [SerializeField]

    [Header("Player Stats")]
    public float walkspeed;
    public float runspeed;
    public float speed = 10f;
    public float jumpforce = 5f;
    public float maxHp = 10f;
    private float currentHp;
    public float spiritualPoints;
    
    private Rigidbody2D rb;
    private float horizontal;


    private LayerMask groundLayer;
    private bool isJumping;
    private bool isGrounded;
    public Transform groundDetector;

    #region "animation"
    private Animator anim;
    public SpriteRenderer sprite;
    private bool isFacingRight = true;
    #endregion




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        anim = GetComponent<Animator>();

    }

    void Update()
    {


        playermove();
        playerjump();

        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Menu");
        }


    }

    void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            isJumping = false;

        }


    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void playerjump()
    {
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.3f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

    }


    private void playermove()
    {


        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal") != 0))

        {
            speed = runspeed;
            anim.SetBool("isRuning", true);
        }
        else
        {
            speed = walkspeed;
            anim.SetBool("isRuning", false);
        }

    }

    void CantMove()
    {
        speed = 0;
        runspeed = 0;
        walkspeed = 0;
    }

    public void Dead()
    {

        if (currentHp <= 0)
        {
            
        }


    }

    void Inventory()
    {
        if (Input.GetKey(KeyCode.I))
        {

        }


    }



}






