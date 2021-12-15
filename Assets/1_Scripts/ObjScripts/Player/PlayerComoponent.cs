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

    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorButton.onClick.AddListener(() =>
        {
            CngColor();
        });
    }

    private void Start()
    {
        
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
            Debug.Log(GameManager.Instance.life);
            GameManager.Instance.life--;
            if(GameManager.Instance.life <=0)
            {
                UIManager.Instance.OverUPdateUI();
                PlayerReset();
                FloorComponent.Instance.FloorReset();
                GameManager.Instance.UpdateState(GameState.OVER);
            }
        }
        else
        {
            GameManager.Instance.score+=10;
            if(GameManager.Instance.score>GameManager.Instance.bestScore)
            {
                GameManager.Instance.bestScore = GameManager.Instance.score;
                PlayerPrefs.SetInt("BESTSCORE", GameManager.Instance.bestScore);
            }

        }
            UIManager.Instance.UpdateUI();
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

    public void PlayerReset()
    {
        transform.position = new Vector3(3f, 3.95f, 0f);
        colorName = "yellow";
        spriteRenderer.color = Color.yellow;
        GameManager.Instance.life = 3;
        GameManager.Instance.score = 0;
        UIManager.Instance.UpdateUI();
    }
}
