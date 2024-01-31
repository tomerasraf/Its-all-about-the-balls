using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject ball;

    Vector3 initialTouchPosition;
    Touch touch;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialTouchPosition.z = -1.02f;

            SpawnBallOnTouch();
        }
    }

    void SpawnBallOnTouch()
    {
        Instantiate(ball, initialTouchPosition, Quaternion.identity);
    }
}
