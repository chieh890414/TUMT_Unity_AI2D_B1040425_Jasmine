using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Jasmine : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string JasmineName = "Jasmine";
    public bool pass = false;
    public bool isGround;

    private Rigidbody2D r2d;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
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
}
