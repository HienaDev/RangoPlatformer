using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    //[RequireComponent()]

    // Player Variables (Colliders, speed, rigidbody, animations)

    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private Collider2D groundCollider;
    [SerializeField] private Collider2D airCollider;
    private float defaultSpeed;
    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private Animator animator;


    // Variables to check if the player is on the ground
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 2f;
    [SerializeField] private float groundCheckSeparation;
    [SerializeField] private LayerMask groundMask;
    private bool grounded;
    private float leftGround;


    // Variables related to the player's jump
    [SerializeField] private float jumpMaxTime;
    [SerializeField] private float jumpSpeed = 125f;
    [SerializeField] private float coyoteTime;
    [SerializeField] private int maxJumps;
    [SerializeField] private float jumpGravity;
    [SerializeField] private float defaultGravity;
    private float lastJumpTime;
    private int nJumps;

    // Variables for the cactus power up
    [SerializeField] private bool cactusReady = false;
    [SerializeField] private float cactusSpeed;
    [SerializeField] private float cactusTimer;
    private float cactusWasActivated;

    // Variables for the one shot power up
    [SerializeField] private bool oneShotReady = false;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;

    // Camera Variables 
    private Camera camera;
    private CameraFollow cameraScript;

    // Cameras related to mouse
    [SerializeField] GameObject mouseObject;
    private Vector2 lookDirection;
    private float lookAngle;

    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        defaultSpeed = moveSpeed;
        animator = GetComponent<Animator>();

        camera = Camera.main;

        cameraScript = camera.GetComponent<CameraFollow>();

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (camera.orthographicSize > 160)
                camera.orthographicSize -= 0.5f;

            Cursor.visible = true;
            
        }
        else
        {
            if (camera.orthographicSize < 180)
                camera.orthographicSize += 0.5f;

            Cursor.visible = false;
        }
    }

    private void CheckIfAiming()
    {
        if (Input.GetMouseButton(1))
        {
            if (oneShotReady)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShootOneShot();
                }
            }
        }
    }
    // Update is called once per frame
    private void Update()
    {

        DetectGround();

        groundCollider.enabled = grounded;
        airCollider.enabled = !grounded;

        currentVelocity = rb.velocity;

        CheckIfAiming();

        AimMethod();

        animator.SetFloat("MoveSpeed", Mathf.Abs(currentVelocity.x));

        if (Input.GetKeyDown(KeyCode.C) && cactusReady)
        {
            moveSpeed = cactusSpeed;

            cactusWasActivated = Time.time;

            SetCactusPower(false);
        }

        if ((Time.time - cactusWasActivated) > cactusTimer)
        {
            moveSpeed = defaultSpeed;
        }

        currentVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        
        if (grounded && currentVelocity.y <= 1e-3)
        {
            leftGround = Time.time;
            
        }

        if ((Time.time - leftGround) <= coyoteTime)
        {
            nJumps = maxJumps;
        }
        else
        {
            if (nJumps == maxJumps)
            {
                nJumps = 0;
            }
        }

        if (Input.GetButtonDown("Jump") && (nJumps > 0))
        {
            currentVelocity.y = jumpSpeed;
            lastJumpTime = Time.time;
            rb.gravityScale = jumpGravity;
            leftGround = Time.time - coyoteTime;
            nJumps--;
        }
        else if(Input.GetButton("Jump") && ((Time.time - lastJumpTime) <= jumpMaxTime) && currentVelocity.y > 0)
        {
            rb.gravityScale = jumpGravity;
        }
        else
        {
            rb.gravityScale = defaultGravity;
            lastJumpTime = 0;
        }

        
        rb.velocity = currentVelocity;


        FlipPlayer();

        if (grounded)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void FlipPlayer()
    {
        if (currentVelocity.x < 0 && transform.right.x > 0)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (currentVelocity.x > 0 && transform.right.x < 0)
            transform.rotation = Quaternion.identity;

        // https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html
        var playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (Input.mousePosition.x < playerScreenPoint.x)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            transform.rotation = Quaternion.identity;
        //Debug.Log($"Input.mousePosition: {(Input.mousePosition.x - 615) / 2},{(Input.mousePosition.y - 360) / 2}");
        //Debug.Log($"gameObject.transform.position: {gameObject.transform.position}");
    }

    public bool GetCactusPower() => cactusReady;
    public void SetCactusPower(bool readiness) => cactusReady = readiness;

    public bool GetOneShotPower() => oneShotReady;
    public void SetOneShotPower(bool readiness) => oneShotReady = readiness;
   
    public void ShootOneShot()
    {
        Vector3 target = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = target - transform.position;
        dir.Normalize();
        Vector2 upDir = new Vector2(-dir.y, dir.x);
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = firePoint.position;
        bulletClone.transform.rotation = Quaternion.LookRotation(Vector3.forward, upDir);

        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletClone.transform.right * bulletSpeed;

        
        //SetOneShotPower(false);
    }
    
    private void AimMethod()
    {
        lookDirection = (Input.mousePosition);
        lookDirection.x /= 2;
        lookDirection.y /= 2;

        lookDirection.x -= 320;
        lookDirection.y -= 180;

        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;


        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        

    }

    public void SetMaxJumps(int n)
    {
        maxJumps = n;
    }


    private void DetectGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (collider != null) grounded = true;
        else
        {
            collider = Physics2D.OverlapCircle(groundCheck.position + transform.right * groundCheckSeparation, groundCheckRadius, groundMask);
            if (collider != null) grounded = true;
            else
            {
                collider = Physics2D.OverlapCircle(groundCheck.position - transform.right * groundCheckSeparation, groundCheckRadius, groundMask);
                if (collider != null) grounded = true;
                else
                {
                    grounded = false;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        if(groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position + transform.right * groundCheckSeparation, groundCheckRadius);
            Gizmos.DrawWireSphere(groundCheck.position - transform.right * groundCheckSeparation, groundCheckRadius);
        }
    }
}
