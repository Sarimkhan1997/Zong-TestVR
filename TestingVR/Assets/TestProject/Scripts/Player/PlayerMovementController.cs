using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Transform playerSpawnPoint;
	[SerializeField] private float RotationAngle = 45.0f;
	[SerializeField] private float Speed = 0.0f;
	[SerializeField] private OVRCameraRig cameraRig;

	private bool ReadyToSnapTurn;
	private Rigidbody playerRb;

	private void Awake()
	{
		playerRb = GetComponent<Rigidbody>();
		playerSpawnPoint = transform;
		if (cameraRig == null) cameraRig = GetComponent<OVRCameraRig>();
	}
    private void OnEnable()
    {
		EventsManager.onResetState += ResetState;
	}
    private void OnDestroy()
    {
		EventsManager.onResetState -= ResetState;
	}
    private void FixedUpdate()
    {
		Move();
		SnapTurn();
	}
	void Move()
	{
		Quaternion ort = cameraRig.centerEyeAnchor.rotation;
		Vector3 ortEuler = ort.eulerAngles;
		ortEuler.z = ortEuler.x = 0f;
		ort = Quaternion.Euler(ortEuler);

		Vector3 moveDir = Vector3.zero;
		Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
		moveDir += ort * (primaryAxis.x * Vector3.right);
		moveDir += ort * (primaryAxis.y * Vector3.forward);
		playerRb.MovePosition(playerRb.position + moveDir * Speed * Time.fixedDeltaTime);
	}

	void SnapTurn()
	{
		if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
		{
			if (ReadyToSnapTurn)
			{
				ReadyToSnapTurn = false;
				transform.RotateAround(cameraRig.centerEyeAnchor.position, Vector3.up, -RotationAngle);
			}
		}
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            if (ReadyToSnapTurn)
            {
                ReadyToSnapTurn = false;
                transform.RotateAround(cameraRig.centerEyeAnchor.position, Vector3.up, RotationAngle);
            }
        }
        else
		{
			ReadyToSnapTurn = true;
		}
	}
	public void OnHoverObject()
    {
		print("HOVERING>>>>>>");
    }
	private void ResetState()
    {
		//transform.position = playerSpawnPoint.position;
		//transform.rotation = playerSpawnPoint.rotation;
    }
}
