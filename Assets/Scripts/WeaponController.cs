using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    
    [SerializeField] private GameObject sessionOrigin;
    [SerializeField] private AudioClip _clip;
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

    public void FireSpell(){
        FireProjectile();
    }

    private void FireProjectile(){
        GameObject projectile;
        if (_ImageObjectManager._instantiatedPrefabs.ContainsKey("Wand")){
            if (_newWand != _ImageObjectManager._instantiatedPrefabs["Wand"]){
                 _newWand = _ImageObjectManager._instantiatedPrefabs["Wand"];
                 wandScript = _newWand.GetComponent<Wand>();
            }
            // _wandTransform = wandScript.getWandTargetTransform();
            _wandTransform = wandScript.getSphereTransform();
            _wandPosition = _wandTransform.position;
             projectile = Instantiate(projectilePrefab, _wandPosition, projectilePrefab.transform.rotation);
        }else{
             projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }

        Projectile _projectile = projectile.GetComponent<Projectile>();
        _projectile.movementDirection = transform.forward; 
        SoundManager.Instance.PlaySound(_clip);
        // Rigidbody rb = projectile.GetComponent<Rigidbody>();
        // rb.velocity = transform.forward * projectileSpeed;
    }   
}
