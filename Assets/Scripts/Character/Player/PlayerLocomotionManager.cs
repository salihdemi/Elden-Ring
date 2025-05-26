using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    PlayerManager player;
    public float vert, hori, moveamount;

    private Vector3 moveDirection, targetRotationDirection;
    [SerializeField] float walkingSpeed = 2, runningSpeed = 5;
    [SerializeField] float rotationSpeed = 15;
    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<PlayerManager>();
    }
    public void HandleAllMovement()
    {
        HandleGroundedMovement();
        HandleRotation();

    }
    private void GetHorizontalAndVerticalInputs()
    {
        vert = PlayerInputManager.instance.vert;
        hori = PlayerInputManager.instance.hori;
        // clamp
    }
    public void HandleGroundedMovement()
    {
        GetHorizontalAndVerticalInputs();

        moveDirection = PlayerCamera.instance.transform.forward * vert + PlayerCamera.instance.transform.right * hori;
        moveDirection.Normalize();

        moveDirection.y = 0;

        if(PlayerInputManager.instance.moveAmount > 0.5f)
        {
            player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
        }
        else if(PlayerInputManager.instance.moveAmount <= 0.5f)
        {
            player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
        }
    }

    private void HandleRotation()
    {
        targetRotationDirection = PlayerCamera.instance.cameraObject.transform.forward * vert + PlayerCamera.instance.cameraObject.transform.right * hori;
        targetRotationDirection.Normalize();
        targetRotationDirection.y = 0;

        if(targetRotationDirection == Vector3.zero)
        {
            targetRotationDirection = transform.forward;
        }
        Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }
}
