using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{

    [SerializeField] private GameObject wandTargetObject;

    public Transform getWandTargetTransform(){
        return wandTargetObject.transform;
    }
}
