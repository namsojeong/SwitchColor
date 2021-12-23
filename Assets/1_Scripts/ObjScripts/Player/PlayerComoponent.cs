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

    bool isDamage = false;

    string colorName = "yellow";

    SpriteRenderer spriteRenderer;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorButton.onClick.AddListener(() =>
        {
            ButtonColorChange();
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

    //이동 확인 및 제어
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

    //플레이어 충돌 시
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.isOver) return; 
        if (GameManager.Instance.isAd) return; 
        if (UIManager.Instance.isSetting) return; //설정창이 켜있으면 무시
        //바닥 색과 같은지 판단
        if (collision.tag == colorName)
        {
            GameManager.Instance.score += 10;
            if (GameManager.Instance.score > GameManager.Instance.bestScore)
            {
                GameManager.Instance.bestScore = GameManager.Instance.score;
                PlayerPrefs.SetInt("BESTSCORE", GameManager.Instance.bestScore);
            }

        }
        else if (collision.tag == "heart")
        {
            if (GameManager.Instance.life >= 3)
                GameManager.Instance.life = 3;
            else
                GameManager.Instance.life++;

        }
        else if (collision.tag == "star")
        {
            GameManager.Instance.score += 30;
            if (GameManager.Instance.score > GameManager.Instance.bestScore)
            {
                GameManager.Instance.bestScore = GameManager.Instance.score;
                PlayerPrefs.SetInt("BESTSCORE", GameManager.Instance.bestScore);
            }
        }
        else
        {
            if (isDamage) return;
            isDamage = true;
            GameManager.Instance.life--;
            StartCoroutine(LifeMin());
            if (GameManager.Instance.life <= 0)
            {
                
                UIManager.Instance.OverUI();
            isDamage = false;
            }
            else
            {
            SoundManager.Instance.SoundOn("SFX", 1);
            StopCoroutine(LifeMin());
            isDamage = false;

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

    //플레이어 위치와 색 정보 리셋
    public void PlayerReset()
    {
        transform.position = new Vector3(3f, 3.95f, 0f);
        spriteRenderer.enabled = true;
        colorName = "yellow";
        spriteRenderer.color = Color.yellow;
        GameManager.Instance.life = 3;
        colorButton.GetComponent<Image>().color = Color.red;
        UIManager.Instance.UpdateUI();
    }

    //라이프 감소 이펙트
    private IEnumerator LifeMin()
    {
        isDamage = true;
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }

    //색 바꾸는 버튼 클릭 시 버튼 색 바뀌기
    void ButtonColorChange()
    {
        if (colorName == "red")
            colorButton.GetComponent<Image>().color = Color.yellow;
        else if (colorName == "yellow")
            colorButton.GetComponent<Image>().color = Color.green;
        else if (colorName == "green")
            colorButton.GetComponent<Image>().color = Color.red;
    }
}
