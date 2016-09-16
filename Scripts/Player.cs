using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float speed = 3.0F;
    public float jumpForce = 15.0F;
    public float slowDelta = 0.5f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public string namePlatform = "Platform";
    public bool onColisionPlatform;
    public Text countText;

    public Image btnUpImage;
    public Image btnLeftImage;
    public Image btnRightImage;


    private bool doubleJump = false;
    private float groundRadius = 0.2f;
    private bool facingRight = true;
    private bool grounded = false;
    private int count = 0;
    private float move = 0;
    public GameObject bulletObject;
    GameObject newBullet;


    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        countText.text = "Score: 0";
        newBullet = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        

        //float move = Input.GetAxis("Horizontal");
       
        rig.velocity = new Vector2(move * speed, rig.velocity.y);
        //rig.velocity = new Vector2(speed * move, rig.velocity.y);
        jumpPlayer();
        fireBullet();
        
    }

    
    void fireBullet()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {

            newBullet = Instantiate(bulletObject, transform.position, bulletObject.transform.rotation) as GameObject;
           
            
            //Rigidbody2D rBullet2D = newBullet.GetComponent<Rigidbody2D>();
            //rBullet2D.AddForce(transform.forward*10f);
        }
    }


    public string movePlayer(int m)
    {
        move = m;
        if ((move < 0) && facingRight) { Flip(); }
        else if ((move > 0) && !facingRight) { Flip(); }

        return "MOVE";
    }

    public void jumpPlayer()
    {

        if (grounded)
        {
            doubleJump = false;
            
        }else
        {
            transform.parent = null;
        }

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rig.AddForce(new Vector2(0, jumpForce));
            }else
            {
                doubleJump = !doubleJump;
            }
           
            
        }
        else
        {

            if (doubleJump)
            {                
                rig.velocity = rig.velocity * slowDelta; ;
                //rig.angularVelocity = rig.angularVelocity * slowDelta;
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
         {
             if (grounded)
             {
                 rig.AddForce(new Vector2(0, jumpForce));
                 doubleJump = true;
             }else
             {
                 if (doubleJump)
                 {
                     rig.gravityScale = .1f;
                     rig.AddForce(new Vector2(0, jumpForce));
                     doubleJump = false;
                 }
             }
         }
         */
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == namePlatform)
        {
            transform.parent = collision.transform ;
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) {
            count++;
            countText.text = "Score: "+count.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Entity"))
        {
            
            GameObject.Find("HeartInfo").transform.GetComponentInChildren<HeartInfo>().removeHeart();
            SceneManager.LoadScene("Test");

        }
        if (other.gameObject.CompareTag("Water"))
        {

            GameObject.Find("HeartInfo").transform.GetComponentInChildren<HeartInfo>().removeHeart();
            SceneManager.LoadScene("Test");

        }
        if (other.gameObject.CompareTag("Heart"))
        {
            if (Opt.numHeart<5)
            {
                Destroy(other.gameObject);
                GameObject.Find("HeartInfo").transform.GetComponentInChildren<HeartInfo>().addHeart();
            }
            

        }
    }



}
