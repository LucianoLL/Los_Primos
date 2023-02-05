using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Track : MonoBehaviour
{
    ARTrackedImageManager image;
    public GameObject ok;

    void Awake()
    {
        image = GetComponent<ARTrackedImageManager>();       
    }

    private void OnEnable()
    {
        image.trackedImagesChanged += OnTrackedChanged;
    }

    private void OnDisable()
    {
        image.trackedImagesChanged -= OnTrackedChanged;
    }

    void OnTrackedChanged(ARTrackedImagesChangedEventArgs spawnArgs) {

        foreach (var spawnSymbol in spawnArgs.added) {
            Debug.Log(spawnSymbol.name);   
        }

        foreach(var spawnSymbol in spawnArgs.removed) {
            Destroy(spawnSymbol);
        }

    }

}
