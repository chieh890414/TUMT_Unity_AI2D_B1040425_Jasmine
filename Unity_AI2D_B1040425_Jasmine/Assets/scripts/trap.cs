using UnityEngine;

public class trap : MonoBehaviour
{
    public int damage = 30;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jasmine")
        {
            collision.gameObject.GetComponent<Jasmine>().Damage(damage);

            print("死了");
        }
    }
}
