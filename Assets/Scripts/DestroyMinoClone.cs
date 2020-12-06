using UnityEngine;

public class DestroyMinoClone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
