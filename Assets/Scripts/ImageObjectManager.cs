using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageObjectManager : MonoBehaviour
{
    
    private ARTrackedImageManager _trackedImagesManager;

    // Array of gameobject prefabs to instantiate
    public GameObject[] ARPrefabs;

    public Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    private void Awake(){
        // Cache reference to tracked images manager comp
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable(){
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
 
    }   

    private void OnDisable(){
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    } 

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs){
        foreach (var trackedImage in  eventArgs.added) {
            var imageName = trackedImage.referenceImage.name;

            foreach (var prefab in ARPrefabs){
                if (string.Compare(prefab.name, imageName, System.StringComparison.OrdinalIgnoreCase) == 0 && !_instantiatedPrefabs.ContainsKey(imageName)){
                    var modifiedTransform = trackedImage.transform;
                    // modifiedTransform.Rotate(90.0f,0.0f,0.0f);
                    var newPrefab = Instantiate(prefab, trackedImage.transform.position, prefab.transform.rotation, trackedImage.transform);
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated) {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in eventArgs.removed){
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            // _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(false);
        }
    }

    

}
