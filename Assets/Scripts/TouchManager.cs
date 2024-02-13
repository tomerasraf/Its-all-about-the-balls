using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    [SerializeField] float touchHightLimit = 5.9f;

    [SerializeField]
    [Range(1, 2)] float minRange = 1.2f;

    [SerializeField] LineRenderer lineRenderer;

    Vector3 initialTouchPosition;
    Vector3 currentMousePos;
    Vector3 distanceDir;
    float distanceFromBall;

    GameObject ballObject;
    Ball ball;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        MouseButtonIsPressedDown();


        if (ball != null)
        {
            if (!ball.isBallActive)
            {
                MouseButtonOnHold();
                MouseButtonRelese();
            } 
        }   
    }

    private void MouseButtonRelese()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ball?.ReleaseBall();


            // Remove line renderer on release;
            lineRenderer.positionCount = 0;

            if (distanceFromBall > minRange)
            {
                ball.shotBall(distanceDir * -1); // Get the opposite Vector;
            }
        }
    }

    private void MouseButtonOnHold()
    {
        if (Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePos.z = 0;

            distanceFromBall = Vector3.Distance(initialTouchPosition, currentMousePos);
            distanceDir = currentMousePos - initialTouchPosition;
            distanceDir.Normalize();

            distanceDir.z = 0;

            // Indicating the diraction and power of the shot;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, ball.transform.position);
            lineRenderer.SetPosition(1, ball.transform.position + (distanceDir * 2));
        }
    }

    private void MouseButtonIsPressedDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConvertMouseInputFromScreenToWorldPoint();
            SpawnBallOnTouch();
        }
    }

    private void ConvertMouseInputFromScreenToWorldPoint()
    {
        initialTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initialTouchPosition.z = -1f;
    }

    void SpawnBallOnTouch()
    {
        if (initialTouchPosition.y > touchHightLimit & ball == null)
        {
            ballObject = Instantiate(ballPrefab, initialTouchPosition, Quaternion.identity);
            ball = ballObject?.GetComponent<Ball>();
            ball.InitBall();
        }
    }
}
