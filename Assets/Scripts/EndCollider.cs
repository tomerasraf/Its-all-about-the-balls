using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Ball>().BallReachTheEnd();
    }
}
