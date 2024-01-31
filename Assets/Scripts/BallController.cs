using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] Rigidbody ballRb;

    [Header("Vars")]
    [SerializeField] float ballFource = 5f;
}
