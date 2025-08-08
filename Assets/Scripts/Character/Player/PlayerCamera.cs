using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera instance;

    public Camera cameraObject;

    public PlayerManager player;


    [Header("Camera Settings")]
    private float cameraSmoothSpeed = 1;
    [SerializeField] float leftAndRightRotationSpeed = 220;
    [SerializeField] float upAndDownLookRotationSpeed = 220;
    [SerializeField] float minimumpivot = -30;
    [SerializeField] float maximumpivot = 60;


    [Header("Camera Values")]
    private Vector3 cameraVelocity;
    [SerializeField] float leftAndRightLookAngle;
    [SerializeField] float upAndDownLookAngle;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        cameraObject = Camera.main;
        DontDestroyOnLoad(gameObject);
    }

    public void HandleAllCameraActions()
    {
        if(player != null)
        {
            HandleFollowTarget();
        }
    }

    private void HandleFollowTarget()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
        transform.position = targetCameraPosition;
    }

    private void HandleRotations()
    {
        //kilitlenmede rotasyonu zorla

        //leftAndRightLookAngle += (PlayerInputManager.instance.cameraHorizontalInput);

    }
}
