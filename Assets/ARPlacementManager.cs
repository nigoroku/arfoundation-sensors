using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;

//ゲームオブジェクトにアタッチすると、ARRaycastManager.csを必要な依存関係として自動的に加える。
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(Camera))]
public class ARPlacementManager : MonoBehaviour
{
    [SerializeField]
    GameObject arObject;            //ARで表示するオブジェクト
    [SerializeField]
    private GameObject arCamera;    //ARで利用するカメラ
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Awake()
    {
        //RequireComponentで追加されたARRaycastManager.csを代入する。
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //arObjectが非アクティブの場合、アクティブにする。
            if (arObject.activeSelf == false)
            {
                arObject.SetActive(true);
            }

            Camera camera = GameObject.FindGameObjectWithTag("ARCamera").GetComponent<Camera>();
            Vector3 position = camera.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(arObject, position, Quaternion.identity);
        }
    }


    // public GameObject Clone(GameObject obj, Vector3 vector)
    // {
    //     var clone = GameObject.Instantiate(obj) as GameObject;
    //     clone.transform.parent = obj.transform.parent;
    //     clone.transform.localPosition = vector;
    //     clone.transform.localScale = obj.transform.localScale;
    //     return clone;
    // }
}