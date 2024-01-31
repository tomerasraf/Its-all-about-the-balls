using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    [SerializeField] float touchHightLimit = 5.9f;

    [SerializeField]
    [Range(1, 2)] float minRange = 1.2f;

    [SerializeField]
    [Range(2,4)] float maxRange = 3f;

    Vector3 initialTouchPosition;
    Vector3 currentMousePos;
    Vector3 shotVector;
    float distanceFromBall;

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
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePos.z = 0;

            distanceFromBall = Vector3.Distance(initialTouchPosition, currentMousePos);
            shotVector = currentMousePos - initialTouchPosition;

            shotVector.z = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ball?.ReleaseBall();


            if (distanceFromBall > minRange)
            {
                ball.shotBall(shotVector *-1);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(initialTouchPosition, currentMousePos);
    }

    private void ConvertMouseInputFromScreenToWorldView()
    {
        initialTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initialTouchPosition.z = -1f;
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
