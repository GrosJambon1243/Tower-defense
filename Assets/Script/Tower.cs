using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float AtkSpeed;
    private float AtkCooldown;

    private CircleCollider2D circleCollider2D;

    [SerializeField]private uint AtkRange;

    void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        Instantiate(bullet, this.transform);
        AtkCooldown = AtkSpeed;
        circleCollider2D.radius = AtkRange;
    }

   

    void Update()
    {
        AtkSpeed -= Time.deltaTime;
        if (AtkSpeed <= 0)
        {
            Instantiate(bullet, this.transform);
            AtkSpeed = AtkCooldown;
            Debug.Log("Firing bullet");
        }
    }
}
