using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
  
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   


    public void AddDamage() {

        _animator.SetTrigger("death");

        Destroy(gameObject,0.5f);

    }

}
