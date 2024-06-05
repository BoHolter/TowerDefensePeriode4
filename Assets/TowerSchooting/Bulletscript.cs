using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Bulletscript : MonoBehaviour
{
    private Transform Target;

    public float speed = 70f;

    public void Seek(Transform _Target)
    {
        Target = _Target;
    }
    void Update()
    {
        if(Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisframe, Space.World);
    }
    void HitTarget ()
    {
        Debug.Log("HIT");
    }
}
