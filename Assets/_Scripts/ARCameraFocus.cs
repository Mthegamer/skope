using UnityEngine;
using System.Collections;

public class ARCameraFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
