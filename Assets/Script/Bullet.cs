using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public Transform target;    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * (target.position - transform.position).normalized);

    }
}
