using UnityEngine;
using System.Collections;

public class ThirdPersonChaseCamera : MonoBehaviour
{
    #region Public Configuration

    public Transform TargetTransform;
    public Vector2 TargetOffset;
    public float RotationRate;

    #endregion

    #region Private Configuration

    private Vector3 mForward = new Vector3(0,0,1);
    private Vector3 mUp = Vector3.up;

    #endregion

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float input = Input.GetAxisRaw("HorizontalRight");

        Quaternion rotation = Quaternion.AngleAxis(input * RotationRate * Time.smoothDeltaTime, mUp);
        mForward = rotation * mForward;
        this.transform.rotation = rotation * this.transform.rotation;

        this.transform.position = TargetTransform.position - mForward * TargetOffset.x + mUp * TargetOffset.y;
	}
}
