using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody ballRb;

    [Header("Vars")]
    public float ballFource = 5f;

    public bool isBallActive = false; 

    public void InitSimiulationBall(Vector3 velocity)
    {
        ballRb.AddForce(velocity, ForceMode.Impulse);
    }

    public void InitBall()
    {
        ballRb.useGravity = false;
    }

    public void ReleaseBall()
    {
        isBallActive = true;
        ballRb.useGravity = true;
    }

    public void BallReachTheEnd()
    {
        isBallActive = false;
        Destroy(gameObject);
    }

    public void shotBall(Vector3 shotDiraction)
    {
        ballRb.AddForce(shotDiraction * ballFource);
    }
}
