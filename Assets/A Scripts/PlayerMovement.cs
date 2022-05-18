using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isPlaying = false;

    [Header("Movement")]
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    //[SerializeField] private Transform sideMovementRoot;
    [SerializeField] private float sideMovementLimit;


    private float lastFrameFingerPositionX;
    private float moveFactorX;   

    public bool IsPlaying
    {
        get { return isPlaying; }
        set { isPlaying = value; }
    }

    public static PlayerMovement instance;
    private void Awake()
    {
        Singelton();
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (isPlaying)
        {
            MoveForward();           
            HandleSideMovement();
        }
    }
    private void MoveForward()
    {
        transform.Translate(movementDirection * Time.deltaTime * forwardSpeed);
    }
    private void HandleSideMovement()
    {
        GetInput();

        float swerveAmount = swerveSpeed * moveFactorX * Time.deltaTime;
        var currentPos = transform.position; //this.sideMovementRoot.localPosition;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -sideMovementLimit, sideMovementLimit);

        transform.position = currentPos;
        //this.sideMovementRoot.localPosition = currentPos;
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
