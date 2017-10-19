using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class FauxInputTracking : MonoBehaviour {
    private static FauxInputTracking instance = null;

	// Use this for initialization
	void Awake () {
	    if (instance != null) {
	        Debug.LogError("Multiple FauxInputTracking instances.");
	    }
	    instance = this;
	}

    public static Quaternion GetLocalRotation(VRNode node) {
        if (node != VRNode.Head) {
            Debug.LogError("GetLocalRotation for other than head");
        }
        return instance.transform.localRotation;
    }

    public static void Recenter() {
        instance.transform.localRotation = Quaternion.identity;
    }
	
}

