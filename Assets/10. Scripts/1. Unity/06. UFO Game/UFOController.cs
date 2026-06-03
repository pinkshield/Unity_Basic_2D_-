using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFOController : MonoBehaviour
{
    // 위,아래 움직임 기능 넣어보기
    // 기본적으로 하강을 하지만 스페이스를 눌렀을때는 상승

    public float Speed = 1.0f;
    public int CoinCount = 0;

    // Update is called once per frame
    void Update()
    {
        //기본적으로 하강
        Vector3 moveVector = new Vector3(0, -1, 0);

        // Space를 누르면 상승한다
        if (Keyboard.current.spaceKey.isPressed)
        {
            moveVector = moveVector * (-1f); // -1 * -1 = +1;
        }

        //속도 * 프레임당 이동량을 구해준다
        moveVector = moveVector * Speed * Time.deltaTime;

        transform.position += moveVector;
    }
    // 충돌 중일때는 충돌되지 않게 하기 위한 조건 검사용 변수
    private bool isColliding = false;

    //Rigidbody를 가진 GameObject 가 Collider (isTrigger가 true) 개체와 접촉했을때 1회 호출된다
    private void OnTriggerEnter2D(Collider2D collider)
    {

        // .CompareTage() || GameObject.CompareTag()
        // 매개변수로 전달된 값과 지정된 gameObejct 가 갖고 있는 Tag를 비교하여 
        // True/ False bool 타입으로 반환한다. 
        // 전달된 값이 동일하면 true, 아니라면 false 를 반환한다



        if (collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            CoinCount += 1;
        }
        else if ((isColliding == false) && (collider.gameObject.CompareTag("Obstacle")))
        {
            // 지형과의 충돌 로직 작성
            isColliding = true;
            StartCoroutine(CollisionEffect()); // 코루틴 함수를 호출하는 방법
        }
    }
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 게임 오브젝트에 부착된 SpriteRenderer 컴포넌트를 가져온다    
    }

    //IEnumerator
    private IEnumerator CollisionEffect()
    {
        Color origin = spriteRenderer.color;
        Color effect = spriteRenderer.color;
        effect.a = 0.2f; // 투명도를 20% 로 낮춰준다

        float term = 0.1f;
        for (int i = 0; i < 10; ++i)
        {
            spriteRenderer.color = effect;
            yield return new WaitForSeconds(term);
            spriteRenderer.color = origin;
            yield return new WaitForSeconds(term);
        }
      
        isColliding = false;
    }



    
}