using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComoponent : MonoBehaviour
{

    [SerializeField]
    Button colorButton;
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Text rewardTxt;

    [SerializeField]
    GameObject overPanel;

    float speed = 10f;
    int reward = 5;

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
        retryButton.onClick.AddListener(() =>
        {
            reward = 5;
            CancelInvoke("reTimer");
            isDamage = true;
            GameManager.Instance.life = 3;
            UIManager.Instance.UpdateUI();
            overPanel.SetActive(false);
            GameManager.Instance.isOver = false;
            isDamage = false;
        });
    }

    private void Update()
    {

        //�̵�
        if (left)
        {
            gameObject.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (right)
        {
            gameObject.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        //ȭ�� ������ �������� ���
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //�̵� Ȯ�� �� ����
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

    //�÷��̾� �浹 ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.isOver) return; 
        if (UIManager.Instance.isSetting) return; //����â�� �������� ����
        //�ٴ� ���� ������ �Ǵ�
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
                GameManager.Instance.isOver = true;
                InvokeRepeating("reTimer", 0f, 1f);
                overPanel.SetActive(true);
                
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
    void reTimer()
    {
        rewardTxt.text = string.Format("{0}", reward);
        reward--;
        Debug.Log("D");
        if (reward < 0)
        {
            reward = 5;
            CancelInvoke("reTimer");
            GameOverFun();
        }
    }
    void GameOverFun()
    {
        GameManager.Instance.isOver = false;
        isDamage = false;
        overPanel.SetActive(false);
        GameManager.Instance.UpdateState(GameState.OVER);
        UIManager.Instance.OverUPdateUI();
        PlayerReset();
        ObjComponent.Instance.FloorReset();
        ObjComponent.Instance.ItemReset();
        SoundManager.Instance.SoundOn("BGM", 1);
    }
    //�÷��̾� �� �ٲٱ�
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

    //�÷��̾� ��ġ�� �� ���� ����
    public void PlayerReset()
    {
        transform.position = new Vector3(3f, 3.95f, 0f);
        spriteRenderer.enabled = true;
        colorName = "yellow";
        spriteRenderer.color = Color.yellow;
        GameManager.Instance.life = 3;
        GameManager.Instance.score = 0;
        colorButton.GetComponent<Image>().color = Color.red;
        UIManager.Instance.UpdateUI();
    }

    //������ ���� ����Ʈ
    private IEnumerator LifeMin()
    {
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }

    //�� �ٲٴ� ��ư Ŭ�� �� ��ư �� �ٲ��
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
