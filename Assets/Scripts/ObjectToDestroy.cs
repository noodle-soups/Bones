using UnityEngine;
using System.Collections;

public class ObjectToDestroy : MonoBehaviour
{

    private BoxCollider cl;
    public float objectHealth;
    public bool isObjectDead = false;
    private float destroyRotationSpeed = 250f;
    private float destroyShrinkSpeed = 1;

    private void Awake()
    {
        cl = GetComponent<BoxCollider>();
    }

    public void ChangeToDead()
    {
        if (isObjectDead) return;
        isObjectDead = true;
        cl.enabled = false;
        Debug.Log("Destroy");
        StartCoroutine(OnObjectDeath());
    }

    private IEnumerator OnObjectDeath()
    {
        while (Mathf.Min(transform.localScale.x, transform.localScale.y, transform.localScale.z) > 0)
        {
            // rotate
            float _destroyRotationSpeed = destroyRotationSpeed * Time.deltaTime;
            transform.Rotate(0, _destroyRotationSpeed, 0);

            // shrink
            float _destroyShrinkSpeed = destroyShrinkSpeed * Time.deltaTime;
            transform.localScale -= new Vector3(_destroyShrinkSpeed, _destroyShrinkSpeed, _destroyShrinkSpeed);

            // prevent negative scale
            if (transform.localScale.x < 0) transform.localScale = Vector3.zero;

            yield return null;
        }
        Destroy(gameObject);
    }

}
