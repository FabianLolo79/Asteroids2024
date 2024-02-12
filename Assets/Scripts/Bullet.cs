using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 500.00f;
    public float maxLifeTime = 10.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //funcion para donde vá la bala
    public void Proyect(Vector2 direction)
    {
        _rigidbody.AddForce(direction * bulletSpeed);

        //la destruye luego de 10 segundos
        Destroy(this.gameObject, maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
