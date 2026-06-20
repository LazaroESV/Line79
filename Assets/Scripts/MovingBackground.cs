using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float resetX = -93.55f;
    [SerializeField] private float maxX = 85.95f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > maxX)
        {
            Vector3 pos = transform.position;
            pos.x = resetX;
            transform.position = pos;
        }
    }
}
