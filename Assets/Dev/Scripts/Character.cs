using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxDistance = 0.45f;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector2[] points;
    
    public float unit;
    
    private int currentPoint;
    private Vector2 prePosition;
    private Vector2 vectorDistance;
    private Vector2 targetPosition;

    void Awake()
    {
        if (Random.Range(0, 4) == 0) points[0].x = 1.5f;
        else points[0].x = 3.5f + 3 * Random.Range(0, 3);
        
        points[0].y = Random.Range(4f, 7f);
        points[1].x = points[2].x = points[0].x;
        points[1].y = 8.5f;
    }

    public void Init()
    {
        currentPoint = 0;
        transform.position = prePosition = new Vector2(unit * Random.Range(1.5f, 3f), unit * Random.Range(1.5f, 3f));
        targetPosition = points[currentPoint] * unit;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x <= unit) transform.position = new Vector3(unit * 2f, transform.position.y, 0);
        //if (transform.position.y <= unit) transform.position = new Vector3(transform.position.x, unit * 2f, 0);
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < maxDistance)
        {
            currentPoint++;
            targetPosition = points[currentPoint] * unit;
        }

        var position = transform.position;
        vectorDistance = (Vector2)position - prePosition;
        prePosition = position;

        sprite.flipX = vectorDistance.x < 0;
        if (Mathf.Abs(vectorDistance.x) >= Mathf.Abs(vectorDistance.y))
        {
            anim.SetInteger("state", 1);
        }
        else if(vectorDistance.y >= 0)
        {
            anim.SetInteger("state", 0);
        }
        else
        {
            anim.SetInteger("state", 2);
        }
    }
}
