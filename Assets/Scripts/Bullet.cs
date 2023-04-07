using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    public float speed = 2f;
    public Vector2 direction;

    public float livingTime = 3;
    public Color initialColor = Color.white;
    public Color finalColor;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private float _startingTime;

    private bool _returning;

   
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;

        Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        float _timeSinceStarted = Time.time - _startingTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;
		Vector2 movement = direction.normalized * speed * Time.deltaTime;

		//transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
		transform.Translate(movement);
        
    {
        
    }
}
    private void FixedUpdate()
    {
        Vector2 movement = direction.normalized * speed;
        _rigidbody.velocity = movement;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (_returning == false && collision.CompareTag("Player")) {
            //tell player to get hurt
            collision.SendMessageUpwards("AddDamage", damage);
                Destroy(gameObject);
        }
        if (_returning == true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("AddDamage");
            Destroy(gameObject);
        }
       
        
        //destruccion de bala
        if (_returning == false && collision.CompareTag("Ground"))
        {
             Debug.Log("Encontre Ground");
            Destroy(gameObject);

           
        }

    }
    public void AddDamage()
    {

        _returning = true;
        direction = direction * -1f;
    }
}
