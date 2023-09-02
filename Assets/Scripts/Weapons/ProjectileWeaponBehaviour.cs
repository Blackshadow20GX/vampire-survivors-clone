using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all projectile behaviours [To be placed on a prefab of a weapon that is a projectile]
/// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{

    protected Vector3 direction;
    public float destroyAfterSeconds;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 direction)
    {
        this.direction = direction;

        float directionX = direction.x;
        float directionY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(directionX < 0 && directionY == 0)
        {
            scale.x *= -1;
            scale.y *= -1;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); // Can't simply set the vector because can't convert
    }
}
