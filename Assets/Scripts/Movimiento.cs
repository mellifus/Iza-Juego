using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjetoAmover;

    public Transform StarPoint;
    public Transform EndPoint;

    public float Velocidad;
    private Vector3 MoverHacia;

    void Start()
    {
        MoverHacia = EndPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);
       
        if (ObjetoAmover.transform.position == EndPoint.position)
        { MoverHacia = StarPoint.position;
        }

        if (ObjetoAmover.transform.position == StarPoint.position)
        {
            MoverHacia = EndPoint.position;
        }
    }
}
