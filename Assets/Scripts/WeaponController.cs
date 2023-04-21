using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 5f;
    [SerializeField] private GameObject sessionOrigin;
    private ImageObjectManager _ImageObjectManager;
    private Transform _wandTransform;
    private Vector3 _wandPosition;
    private GameObject _newWand;
    private Wand wandScript;

    private void Awake(){
        _ImageObjectManager =  sessionOrigin.GetComponent<ImageObjectManager>();
        if (_ImageObjectManager != null){
            // pass should add a safe guard , maybe try finding it again
        }
    }

    public void Fire(InputAction.CallbackContext context){
        if (context.performed){
            FireProjectile();
        }
    }

    private void FireProjectile(){
        GameObject projectile;
        if (_ImageObjectManager._instantiatedPrefabs.ContainsKey("Wand")){
            if (_newWand != _ImageObjectManager._instantiatedPrefabs["Wand"]){
                 _newWand = _ImageObjectManager._instantiatedPrefabs["Wand"];
                 wandScript = _newWand.GetComponent<Wand>();
            }
            _wandTransform = wandScript.getWandTargetTransform();
            _wandPosition = _wandTransform.position;
             projectile = Instantiate(projectilePrefab, _wandPosition, Quaternion.identity);
        }else{
             projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        }
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;
    }   
}
