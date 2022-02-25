using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Rotation")]
    public float rotationSensibility = 30f;

    private float cameraVerticalAngle;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
    CharacterController characterController;
    [SerializeField] private Animator PlayerShooter;

    private void Awake()
    {

        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {

        Look();
        Fire();
        Reload();
        Point();

    }

    private void Look()
    {


        rotationinput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;

        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;


        cameraVerticalAngle += rotationinput.y;

        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);

        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);

    }

    private void Fire()
    {

    }
    private void Reload()
    {
        if (Input.GetKey(KeyCode.R))

        {
            PlayerShooter.SetBool("Reload", true);

        }

        if (Input.GetKeyUp(KeyCode.R))

        {
            PlayerShooter.SetBool("Reload", false);

        }
    }
    private void Point()
    {
        if (Input.GetKey(KeyCode.Mouse1))

        {
            PlayerShooter.SetBool("Point", true);

        }

        if (Input.GetKeyUp(KeyCode.Mouse1))

        {
            PlayerShooter.SetBool("Point", false);

        }
        
        if (Input.GetKey(KeyCode.Mouse0))

        {
            PlayerShooter.SetBool("Fire", true);

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            PlayerShooter.SetBool("Fire", false);

        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerShooter.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerShooter.SetBool("Run", false);
        }
    }
}
