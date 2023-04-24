using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{

    [SerializeField] private GameObject wandTargetObject;
    [SerializeField] private GameObject sphereTargetObject;

    public Transform getWandTargetTransform(){
        return wandTargetObject.transform;
    }

    public Transform getSphereTransform(){
        return sphereTargetObject.transform;
    }

}
