using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CameraScrollingCS))]
public class CameraFocusCS : MonoBehaviour {
	
	
	// An internal reference to the attached CameraScrolling script
	private CameraScrollingCS cameraScrolling = null ;
	
	// Who is the player controlling
	private int selected = 0;
	
	// List of objects to control
	public Transform[] targets ;
	
	// What to display on the buttons in the window
	public string[] targetButtonNames ;
		
	
	// On start up, we send the SetControllable () message to turn the different players on and off.
	void Awake () {
	
		// Get the reference to our CameraScrolling script attached to this camera;
		cameraScrolling = GetComponent<CameraScrollingCS>() ;
		
		// Set the scrolling camera's target to be our character at the start.
		cameraScrolling.SetTarget (targets[0], true);
		
		// tell all targets (except the first one) to switch off.
		for (int i=0; i < targets.Length; i++) 
			targets[i].gameObject.SendMessage ("SetControllable", (i == 0), SendMessageOptions.DontRequireReceiver);
	}
	
	
	private Rect windowRect = new Rect (20, 20, 250, 50);
	// Make the onscreen GUI to let the player switch control between Lerpz and the spaceship.
	void OnGUI () {
		// Make a popup window
		windowRect = GUILayout.Window (0, windowRect, DoControlsWindow, "Controls");
		
		// The window can be dragged around by the users - make sure that it doesn't go offscreen.
		windowRect.x = Mathf.Clamp (windowRect.x, 0.0f, Screen.width - windowRect.width);
		windowRect.y = Mathf.Clamp (windowRect.y, 0.0f, Screen.height - windowRect.height);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	// Make the contents of the window
	void DoControlsWindow ( int windowID ) {
		// Make the window be draggable in the top 20 pixels.
		GUI.DragWindow ( new Rect (0,0, (float)System.Decimal.MaxValue, 20));
		
		GUILayout.Label ("Select a character...");
	
		// Let the player select the character
		selected = GUILayout.Toolbar (selected, targetButtonNames);
	
		// If the user has selected a new character, we'll send new SetControllable messages to turn on the other character. 
		// Then we'll change who the CameraScrolling script is tracking.
		if (GUI.changed && targets[selected] != cameraScrolling.GetTarget ()) {
			targets[selected].gameObject.SendMessage ("SetControllable", true, SendMessageOptions.DontRequireReceiver);
			cameraScrolling.GetTarget ().gameObject.SendMessage ("SetControllable", false, SendMessageOptions.DontRequireReceiver);
			cameraScrolling.SetTarget (targets[selected]);
		}
		
		// Show a different instruction label depending on what was selected above.
		switch (selected) {
			case 0:
				GUILayout.Label ("Instructions:\nUse the left and right arrow keys to move and space bar to jump.  To run, hold down the control key.");
			break;
			case 1:
				GUILayout.Label ("Instructions:\nUse the left and right arrow keys to rotate and the up arrow to thrust.");
			break;
		}
	}
	
}
