using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40;
    public float projectileLifeSpan = 2f;

public int spinSpeed = 1;
private float angleForHeight = 0;
    //public float heightSpeed = .1f;
    private float startYPos;
    void Start()
    {
        startYPos = transform.position.y;
        Destroy(gameObject, projectileLifeSpan);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x,
        startYPos + Mathf.Sin(angleForHeight) / 2,
        transform.position.z);
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}
