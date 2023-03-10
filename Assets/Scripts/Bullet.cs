using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Enemy enemyscript;
    public Transform target;

    public float speed = 1f;

    public int damage = 5;


    public void Seek(Transform _target)
    {
        target = _target;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target.gameObject && target != null)
        {
            enemyscript = target.GetComponent<Enemy>();
            enemyscript.losehp(damage);
            Destroy(this.gameObject);
        }
    }
}