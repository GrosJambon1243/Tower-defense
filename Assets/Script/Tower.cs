using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    void Start()
    {
        Instantiate(bullet,this.transform); 
    }

   
    void Update()
    {
        
    }
}
