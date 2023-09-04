using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: MonoBehaviour
{

    public float speedY = 3f;
    public float speedX = 3f;
    public float resetPosX = 3.4f;
    public float resetPosY = 3.5f;

    public GameObject[] win = new GameObject[4];

    private Vector2 resetPos;
    private Vector2 resetRot;
    private SpriteRenderer sRender;

    SceneManage sceneManager = new SceneManage();

    void Start()
    {
        resetPos = new Vector2(transform.position.x, transform.position.y);
        resetRot = new Vector2(transform.rotation.x, transform.rotation.y);

        sRender = gameObject.GetComponent<SpriteRenderer>();

        print(resetPos);
        print(resetRot);
    }

    void Update()
    {
        Move();
        ResetPos();
        
    }

    public void Move()
    {
        // W:위
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, speedY, 0);
        }
        //S:아래
        else if(Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -speedY, 0);
        }
        //A:왼쪽
        else if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-speedX, 0, 0);
            sRender.flipX = true;
        }
        //D:오른쪽
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speedX, 0, 0);
            sRender.flipX = false;
        }
    }

    //제자리로 초기화
    void ResetPos()
    {
        if(transform.position.x >= resetPosX)
        {
            transform.position = resetPos;
        }
        else if(transform.position.x <= -resetPosX)
        {
            transform.position = resetPos;
        }

        else if(transform.position.y >= resetPosY)
        {
            transform.position = resetPos;
        }

        else if(transform.position.y <= -resetPosY)
        {
            transform.position = resetPos;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //장애물에 닿을 경우
        if (col.gameObject.CompareTag("Obstacle"))
        {
            print("닿았어요");
            transform.position = resetPos;
            transform.rotation = Quaternion.Euler(resetRot);
        }
        //목표 도달시
        else if (col.gameObject.CompareTag("Goal"))
        {
            print("Goal");

            win[0].SetActive(true);
            win[2].SetActive(false);
            win[3].SetActive(false);
            Destroy(win[1]);

        }
    }
}
