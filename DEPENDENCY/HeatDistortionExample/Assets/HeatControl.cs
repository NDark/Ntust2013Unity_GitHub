using UnityEngine;
using System.Collections;

public class HeatControl : MonoBehaviour {
    public GameObject heat;
    Material heatMaterial;
    float strength;
    float defaultStrength;
    float transparency;
    float defaultTransparency;

	// Use this for initialization
	void Start () {
        heatMaterial = heat.renderer.material;
        defaultStrength = heatMaterial.GetFloat("strength");
        strength = defaultStrength;
        defaultTransparency = heatMaterial.GetFloat("transparency");
        transparency = defaultTransparency;
	}

    void OnGUI() {
        if (GUI.Button(new Rect(0, 0, 150, 20), "More Distortion")) {
            if (strength <= 0.3f)
                strength += 0.01f;
            heatMaterial.SetFloat("strength", strength);
        }
        if (GUI.Button(new Rect(0, 30, 150, 20), "Less Distortion")) {
            if (strength >= 0.1f)
                strength -= 0.01f;
            heatMaterial.SetFloat("strength", strength);
        }
        if (GUI.Button(new Rect(0, 60, 150, 20), "Default Distortion")) {
            strength = defaultStrength;
            heatMaterial.SetFloat("strength", strength);
        }
        if (GUI.Button(new Rect(0, 90, 150, 20), "More Transparency")) {
            if (transparency <= 0.1f)
                transparency += 0.01f;
            heatMaterial.SetFloat("transparency", transparency);
        }
        if (GUI.Button(new Rect(0, 120, 150, 20), "Less Transparency")) {
            if (transparency >= 0.02f)
                transparency -= 0.01f;
            heatMaterial.SetFloat("transparency", transparency);
        }
        if (GUI.Button(new Rect(0, 150, 150, 20), "Default Transparency")) {
            transparency = defaultTransparency;
            heatMaterial.SetFloat("transparency", transparency);
        }
        if (GUI.Button(new Rect(0, 180, 150, 20), "Toggle Heat")) {
            heat.active = !heat.active;
        }
    }
}
