using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubeRender : MonoBehaviour
{
    public GameObject cubePrefab;
    GameObject spawnedObj; // ê∂ê¨Ç≥ÇÍÇΩÇ‡ÇÃCube
    ARRaycastManager arRaycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // É^ÉbÉvÇµÇΩèÍèäÇ…ê∂ê¨
        if (Input.touchCount > 0)
        {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                if (spawnedObj == null)
                {
                    spawnedObj = Instantiate(cubePrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObj.transform.position = hitPose.position;
                }
            }

        }
    }
}
