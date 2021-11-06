using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject onPauseGame;

    [Header("Look Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Clamping")]
    public float minY;
    public float maxY;

    [Header("Specatator")]
    public float spectatorMoveSpeed;

    public float rotX;
    public float rotY;

    private bool isSpecatator;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isSpecatator = true;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPauseGame.SetActive(true);
            Time.timeScale = 0;
            isSpecatator = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (isSpecatator)
        {
            // get the mouse movement inputs
            rotX += Input.GetAxis("Mouse X") * sensX;
            rotY += Input.GetAxis("Mouse Y") * sensY;

            // clam the vertical rotation
            rotY = Mathf.Clamp(rotY, minY, maxY);

            // are we spectator?

            // rotate cam vertically
            transform.rotation = Quaternion.Euler(-rotY, rotX, 0);

            // movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0;

            if (Input.GetKey(KeyCode.E))
                y = 1;
            else if (Input.GetKey(KeyCode.Q))
                y = -1;

            Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
            transform.position += dir * spectatorMoveSpeed * Time.deltaTime;
        }
    }

    public void UnPauseGame()
    {
        onPauseGame.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isSpecatator = true;
        Time.timeScale = 1;
    }
}
