using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComoponent : MonoBehaviour
{
    [SerializeField]
    Button colorButton;

    float speed = 10f;

    private bool left;
    private bool right;

    string colorName = "yellow";

    SpriteRenderer spriteRenderer;

    int life = 3;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorButton.onClick.AddListener(() =>
        {
            CngColor();
        });
    }

    private void Update()
    {

        //이동
        if (left)
        {
            gameObject.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (right)
        {
            gameObject.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        //화면 밖으로 못나가게 경계
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //이동 제어
    public void LeftDown()
    {
        left = true;
    }
    public void RightDown()
    {
        right = true;
    }
    public void LeftUp()
    {
        left = false;
    }
    public void RightUp()
    {
        right = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!=colorName)
        {
            --life;
            if(life<=0)
            {
                GameManager.Instance.UpdateState(GameState.STANDBY);
                FloorComponent.Instance.FloorReset();
                PlayerReset();
            }
        }
    }

    //플레이어 색 바꾸기
    public void CngColor()
    {
        if (colorName == "yellow")
        {
            colorName = "red";
            spriteRenderer.color = Color.red;
        }
        else if (colorName == "red")
        {
            colorName = "green";
            spriteRenderer.color = Color.green;

        }
        else if (colorName == "green")
        {
            colorName = "yellow";
            spriteRenderer.color = Color.yellow;

        }
    }

    private void PlayerReset()
    {
        transform.position = new Vector3(0f, 3.95f, 0f);
        colorName = "yellow";
        spriteRenderer.color = Color.yellow;
        life = 3;
    }
}
