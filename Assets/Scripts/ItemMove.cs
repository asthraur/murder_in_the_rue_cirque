using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public string direction;

    void OnMouseDown()
    {
        if(direction == "left")
        {
            transform.position = new Vector3(transform.position.x - 20, transform.position.y, transform.position.z);
        }

    }

    void Update()
    {
        
    }
}
