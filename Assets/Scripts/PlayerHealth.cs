using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int totalHealth = 3;
    public RectTransform heartUI;

   

    //game over
    public RectTransform gameOverMenu;
    public GameObject enemigos;
 
    private int health;
    private float heartSize = 36f;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;



 

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();

    }
   void Start()
    {
        health = totalHealth;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
 

    public void AddDamage(int amount)
    {
        health = health - amount;
        //visual Feedback
        StartCoroutine("VisualFeedback");
        //Game over

        if (health <= 0){
            health = 0;
            gameObject.SetActive(false);
        }

        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

        Debug.Log("Player got damaged. Gis current health is" + health);
    }
     //efectorebote
   public void AddDamage(float daño, Vector2 posicion)
    {

        StartCoroutine("VisualFeedback");
        //perderControl
        Debug.Log("DAÑOOOOOOOOOOOOOOOOOOO" );

    }
    public void AddHealth(int amount)
    {
        health = health + amount;
        //max health
        if (health > totalHealth){
            health = totalHealth;
        }
        
            heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

        Debug.Log("Player got some life. His current health is" + health);
    }

    
     
   
    private IEnumerator VisualFeedback()
    {
       
        _renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }
    //aca esta el problema cuando activo esto me dice gameobjec destruido se intenta llamar nuevamente :(

   

    private void OnEnable()
    {
        health = totalHealth;
    }
    private void OnDisable()
    {
        //solucion
        if (gameOverMenu == null)return;
        //solucion
        gameOverMenu.gameObject.SetActive(true);
        if (enemigos == null) return;
        enemigos.SetActive(false);
        
        _animator.enabled = false;
        _controller.enabled = false;
    }

}

