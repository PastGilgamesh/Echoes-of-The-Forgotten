using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float length;
    private float startPos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private void Start()
    {
        cam = GameObject.Find("CM vcam1");
        startPos = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

    }


    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
