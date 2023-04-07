using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.5f;
    public float jumpForce = 2.5f;
    //salto doble
    [SerializeField] private int _nJumps = 1;
    private int _nJumpsValue;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    //referencia
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    //movimiento
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _grounded;

    //attacking
    private bool _attacking;

   

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
       if (_attacking == false) {
            
                 float horizontalInput = Input.GetAxisRaw("Horizontal");
                   _movement = new Vector2(horizontalInput, 0f);
            //flipc character
      
                 if (horizontalInput < 0f && _facingRight == true)
                  {
                    flip();
                  }
                  else if (horizontalInput > 0f && _facingRight == false)
                   {
                    flip();
                   }
           
            //doblesalto
            if (_grounded)
            {
                _nJumpsValue = _nJumps;
            }



        }



        _grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //is jumping?
        //codigo sin doble salto
        //if (Input.GetButtonDown("Jump") && _grounded == true && _attacking == false)
        
        if (Input.GetButtonDown("Jump") && _nJumpsValue > 0) {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _nJumpsValue--;
        }
        
        //wanna Attack?
        if (Input.GetButtonDown("Fire1") && _grounded == true && _attacking == false)
            
               { 
                    _movement = Vector2.zero;
                    _rigidbody.velocity = Vector2.zero;
                    _animator.SetTrigger("atack");
                }

    }
    private void FixedUpdate()
    {
        
        
       
            if (_attacking == false) { 
                float horizontalVelocity = _movement.normalized.x * speed;
                _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        
            }
        
    }
    private void LateUpdate()
    {
        _animator.SetBool("idle", _movement == Vector2.zero);
        _animator.SetBool("Grounded", _grounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
        //animator
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {

            _attacking = true;
        }
        else {
            _attacking = false;
        }
        
    }
    private void flip() {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    //para poder mantenernos encima de la plataforma en movimiento. nos hacemos hijo de la plataforma mediante colisiones.
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Plataforma_move")
        {
            transform.parent = collision.transform;
        }
    }
    //collision de salida de la plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma_move")
        {
            transform.parent =null;
        }
    }
    
}
