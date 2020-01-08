using UnityEngine;

public class die_ground : MonoBehaviour
{
    public int damage = 100;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jasmine")
        {
            collision.gameObject.GetComponent<Jasmine>().Damage(damage);

            print("去了");
        }
    }
}
