using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float reloadTime;
    private float nextShot;
    [SerializeField]
    private bool isReload = false;

    private bool isShot;

    private InputSystem action;

    [SerializeField]
    private Projectile projectilePrefab;
    private Projectile projectile;

    [SerializeField]
    private Transform spawnPoint;


    private void Awake()
    {
        action = new InputSystem();
        action.Player.Shoot.performed += context => Shot(context);
        action.Player.Shoot.canceled += context => Shot(context);
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        Reload();
    }



    private void Update()
    {
        if (!isReload)
        {
            nextShot = Time.deltaTime + nextShot;
         
            if (nextShot >= reloadTime)
            {
                Reload();
            }
            Debug.Log(nextShot);
        }
    }

    private void Reload()
    {
        projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        isReload = true;
    }

    private void Shot(InputAction.CallbackContext context)
    {
        if (!isReload) return;

        projectile.Shoot();
        Rigidbody body;
        var niceTry = projectile.TryGetComponent<Rigidbody>(out body);
        if (niceTry)
        {
            //var velocity = spawnPoint.forward * _speed;
            body.AddForce(spawnPoint.forward * _speed, ForceMode.Impulse);
        }

        Debug.Log(niceTry);
        isReload = false;
        nextShot = 0f;
    }
}
