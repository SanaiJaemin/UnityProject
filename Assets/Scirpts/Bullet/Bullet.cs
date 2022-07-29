using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform FireTransform;
    LineRenderer bulletLineRenderer;
    AudioSource _audioSource;
    BulletData _bullData;

    float fireDistance;

    // Start is called before the first frame update
    void Start()
    {
        FireTransform = GetComponent<Transform>();
        bulletLineRenderer = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shot()
    {
        RaycastHit hit;
        Vector3 hitposition = Vector3.zero;

        if(Physics.Raycast(FireTransform.position,FireTransform.forward,out hit,fireDistance))
        {
            IDamageable target = hit.collider.GetComponent<IDamageable>();
            if(target != null)
            {
                target.OnDamage(_bullData.Damage, hit.point, hit.normal);
                hitposition = hit.point;
            }
            else
            {
                hitposition = FireTransform.position + FireTransform.forward * fireDistance;
            }
        }

        
    }
}
