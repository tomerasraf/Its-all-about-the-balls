using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    Vector3 initialTouchPosition;

    GameObject ballObject;
    Ball ball;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialTouchPosition.z = -1.02f;

            SpawnBallOnTouch();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("s0");
            ball.ReleaseBall();
        }
    }

    void SpawnBallOnTouch()
    {
        if(initialTouchPosition.y > 5.9f)
        {
           ballObject = Instantiate(ballPrefab, initialTouchPosition, Quaternion.identity);
            ball = ballObject?.GetComponent<Ball>();
            ball.InitBall();
        }  
    }
}
