using UnityEngine;
using UnityEngine.Rendering;

public class BlockMovement : MonoBehaviour
{
    public static BlockMovement CurrentBlock { get; set; }
    public static BlockMovement LastBlock { get; set; }
    public static bool GameOver { get; set; }
    public static bool XDirection { get; set; }

    [Header("Block Settings")] 
    public float speed = 5f;
    [SerializeField] private float perfectThreshold = 0.03f;
    
    private void OnEnable()
    {
        if (LastBlock == null)
            LastBlock = this;

        if (this != LastBlock)
            CurrentBlock = this;
    }
    
    public void Stop()
    {
        speed = 0;
        Vector3 hangover = new(transform.position.x - LastBlock.transform.position.x, 0, transform.position.z - LastBlock.transform.position.z);
        Vector3 direction = new(hangover.x >= 0 ? 1 : -1, 0, hangover.z >= 0 ?  1 : -1);
        if (Mathf.Abs(hangover.x) > transform.localScale.x || Mathf.Abs(hangover.z) > transform.localScale.z)
        {
            GameOver = true;
            CurrentBlock.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            if (Mathf.Abs(hangover.x) / 2 <= perfectThreshold && Mathf.Abs(hangover.z) / 2 <= perfectThreshold)
            {
                transform.localScale = new Vector3(LastBlock.transform.localScale.x, transform.localScale.y, LastBlock.transform.localScale.z);
                transform.position = new Vector3(LastBlock.transform.position.x, transform.position.y, LastBlock.transform.position.z);
            }
            else
            {
                Vector3 newScale = new (transform.localScale.x - Mathf.Abs(hangover.x), transform.localScale.y,
                    transform.localScale.z - Mathf.Abs(hangover.z));
                Vector3 fallingBlockScale = new (transform.localScale.x - (XDirection ? newScale.x : 0), transform.localScale.y,
                    transform.localScale.z - (!XDirection ? newScale.z : 0));
            
                transform.localScale = newScale;
                transform.position = new Vector3(LastBlock.transform.position.x + hangover.x / 2f, transform.position.y,
                    LastBlock.transform.position.z + hangover.z / 2f);
            
                GameObject fallingBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                fallingBlock.transform.localScale = fallingBlockScale;
                fallingBlock.transform.position = new Vector3(
                    transform.position.x + (XDirection ? newScale.x + fallingBlockScale.x : 0) / 2f * direction.x, 
                    transform.position.y, 
                    transform.position.z + (!XDirection ? newScale.z + fallingBlockScale.z : 0) / 2f * direction.z
                );
                fallingBlock.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
                fallingBlock.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
                fallingBlock.AddComponent<Rigidbody>();
            }

            XDirection = !XDirection;
            LastBlock = this;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Transform t = transform;
        t.position += (XDirection ? t.right : t.forward) * (Time.deltaTime * speed);

        if (t.position.x is > 5 or < - 5 || t.position.z is > 5 or < - 5)
        {
            speed *= -1;
        }
    }
}
