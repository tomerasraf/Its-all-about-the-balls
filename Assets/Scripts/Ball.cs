using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] Rigidbody ballRb;

    [Header("Vars")]
    [SerializeField] float ballFource = 5f;


    public void InitBall()
    {
        ballRb.useGravity = false;
    }

    public void ReleaseBall()
    {
      ballRb.useGravity = true;
    }

    public void shotBall(Vector3 shotDiraction)
    {
        ballRb.AddForce(shotDiraction * ballFource);
    }
}
