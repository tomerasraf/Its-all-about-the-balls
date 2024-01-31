using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float touchHightLimit = 5.9f;

    Vector3 initialTouchPosition;
    Vector3 currentMousePos;

    GameObject ballObject;
    Ball ball;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConvertMouseInputFromScreenToWorldView();
            SpawnBallOnTouch();
        }

        if (Input.GetMouseButton(0))
        {
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            ball.ReleaseBall();
        }
    }

    private void ConvertMouseInputFromScreenToWorldView()
    {
        initialTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initialTouchPosition.z = -1.02f;
    }

    void SpawnBallOnTouch()
    {
        if (initialTouchPosition.y > touchHightLimit)
        {
            ballObject = Instantiate(ballPrefab, initialTouchPosition, Quaternion.identity);
            ball = ballObject?.GetComponent<Ball>();
            ball.InitBall();
        }
    }
}
