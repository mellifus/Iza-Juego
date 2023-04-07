using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewPause : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;

    void Start()
    {
        Invoke("Reanudar", 3f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
               Reanudar();
            }
        
              else 
            {
                Pausa();
            }
         }
    }
    public void Pausa()
    {
        juegoPausado = true;

        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }
    public void Reanudar() 
    {
        juegoPausado = false;
        
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Reiniciar() {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
}
