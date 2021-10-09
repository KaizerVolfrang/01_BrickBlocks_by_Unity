using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerBuilder : MonoBehaviour
{
    [SerializeField]
    private Block[] _blockVariants;
    [SerializeField]
    private int _blockCount;
    private Tower _tower;
    private Block[] _blocks;

    private void Awake()
    {
        if (_blockVariants.Length == 0)
            Debug.LogError("array of block variant empty");

        Build();
    }

    private void Build()
    {
        _blocks = new Block [_blockCount];
        _tower = gameObject.AddComponent<Tower>();

        var firstVariant = GetRandomBlockVariante();
        var position = transform.position + Vector3.up * firstVariant.Height / 2f;
        var rotation = Quaternion.identity;

        CreateBlock(0, firstVariant, position, rotation);

        for (int i = 1; i < _blockCount; i++)
        {
            var nextVariant = GetRandomBlockVariante();
            position = position + transform.up * nextVariant.Height;
            CreateBlock(i, nextVariant, position, rotation);

        }
         _tower.SetBlocks(_blocks);

        Destroy(this);
    }

    private Block GetRandomBlockVariante()
    {
        int index = Random.Range(0, _blockVariants.Length);
        return _blockVariants[index];
    }

    private void CreateBlock(int index, Block variant, Vector3 position, Quaternion rotation)
    {   
        Block newBlock = Instantiate<Block>(variant, position, rotation, transform);
        _blocks[index] = newBlock;
    }
}
