using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class barra_de_vida : MonoBehaviour
{
    // Start is called before the first frame update

    public Image _barraDeVida;

    public int  _vidaActual = 100;

    public int _vidaMaxima = 100;

    //color cuando recibe daño 

    private SpriteRenderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    

    public void AddHealth(int amount)
    {
        _vidaActual = _vidaActual + amount;
        //max health
        if (_vidaActual > _vidaMaxima)
        {
            _vidaActual = _vidaMaxima;
        }
        Debug.Log("Player got some life. His current health is" + _vidaActual);
    }

    void Update()
    {
        _barraDeVida.fillAmount = _vidaActual / _vidaMaxima;
    }
}
