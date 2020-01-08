using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Jasmine : MonoBehaviour
{
    public int speed = 6;
    public float jump = 175f;
    public string JasmineName = "Jasmine";
    public bool pass = false;
    public bool isGround;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    public UnityEvent onEat;
    public GameObject final;

    private float hpMax;

    public Image hpBar;

    private Rigidbody2D r2d;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        hpMax = hp;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Turn(180);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Turn(0);
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到了" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LifeTree")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();
        }
    }

    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向，左轉為 180，右轉為 0</param>>
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;

        if (hp <= 0)
        {
            final.SetActive(true);
            Destroy(this);
        }
    }
}
