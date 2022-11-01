using UnityEngine;


public class CubeScript : MonoBehaviour
{
    private CubeGenerator generator;
    private Vector3 startPoint;
    private float speed;
    private float distance;


    private void Start()
    {
        generator = FindObjectOfType<CubeGenerator>();

        startPoint = transform.position;
        speed = generator.GetSpeed();
        distance = generator.GetDistance();
    }


    void Update()
    {
        Move();
        CheckDistance();
    }

    private void CheckDistance()
    {
        if(Vector3.Distance(startPoint, transform.position) > distance)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
