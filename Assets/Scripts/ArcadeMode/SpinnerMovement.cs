using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerMovement : MonoBehaviour
{
	public float rotationSpeed = 50f;
	private void FixedUpdate()
	{
		transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
	}
}
