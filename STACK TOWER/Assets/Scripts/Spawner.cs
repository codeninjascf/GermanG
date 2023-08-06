using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab;

    private int _height;
    private float _heightIncrement;
    
    private void OnEnable()
    {
        _height = 0;

        if (blockPrefab == null)
        {
            Debug.LogError("No block prefab specified in 'Spawner'");
        }
        else
        {
            _heightIncrement = blockPrefab.transform.localScale.y;
        }
    }

    public void Spawn()
    {
        Vector3 spawnPos =
            new(BlockMovement.XDirection ? -5 : BlockMovement.LastBlock.transform.position.x, GetNewHeight(),
                !BlockMovement.XDirection ? -5 : BlockMovement.LastBlock.transform.position.z);
        GameObject toSpawn = BlockMovement.CurrentBlock == null ? blockPrefab : BlockMovement.LastBlock.gameObject;
        
        GameObject newBlock = Instantiate(toSpawn, spawnPos, Quaternion.identity);
        newBlock.GetComponent<BlockMovement>().speed = blockPrefab.GetComponent<BlockMovement>().speed;
        newBlock.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(_height / 50f % 1f, 1f, 1f);

        _height++;
    }

    public float GetNewHeight() => _height * _heightIncrement;
}
