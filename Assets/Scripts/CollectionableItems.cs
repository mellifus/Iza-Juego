using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableItems : MonoBehaviour
{
    public int healthRestoration = 1;
    [SerializeField] GameObject lightinParticles;
    [SerializeField] GameObject burstParticles;

    private SpriteRenderer _renderer;
    private Collider2D _collider;
    private AudioSource _audio;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 

            // cure player
             collision.SendMessageUpwards("AddHealth", healthRestoration);
           
            _audio.Play();

                //disable collider
                _collider.enabled = false;
                
        _renderer.enabled = false;
        lightinParticles.SetActive(false);
        burstParticles.SetActive(true);

        Destroy(gameObject, 2f);
        }
    }
}
