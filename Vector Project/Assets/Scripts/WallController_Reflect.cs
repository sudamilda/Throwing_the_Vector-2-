using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController_Reflect : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 Reflect(Vector2 a, Vector2 n)
    {
        Vector2 p = Mathf.Abs(Vector2.Dot(a, n)) / n.magnitude * n / n.magnitude; // abs ����, dot ����, magnitude ���� ����
        Vector2 b = a + 2 * p;
        return b;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("collision");
            Rigidbody2D ArrowRB_Wall = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 move = collision.gameObject.GetComponent<ArrowController>().move;
            ArrowRB_Wall.velocity = Reflect(move, -collision.GetContact(0).normal); // GetContact �浹 ������ ����, normal ����
        }
    }
}