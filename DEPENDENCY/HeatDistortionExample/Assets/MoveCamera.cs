using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    public GameObject camera;
    Transform cameraTransform;
    public GameObject target;
    Vector3 targetPosition;
    public float speed;

    void Start() {
        cameraTransform = camera.transform;
        targetPosition = target.transform.position;
        cameraTransform.LookAt(target.transform);
    }

	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow)){
            cameraTransform.RotateAround(targetPosition, Vector3.up, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            cameraTransform.RotateAround(targetPosition, Vector3.up, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            cameraTransform.Translate(Vector3.forward * Time.deltaTime * 3, Space.Self);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            cameraTransform.Translate(Vector3.back * Time.deltaTime * 3, Space.Self);
        }
	}

    void OnGUI() {
        GUI.Label(new Rect(Screen.width - 300 >> 1, Screen.height - 100, 300, 100), 
                  "Use the arrow keys to move the camera");
    }
}
