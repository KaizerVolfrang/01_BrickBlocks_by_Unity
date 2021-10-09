using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour
{
    private LinkedList<Block> _blocks = null;

    public void SetBlocks(Block[] blocks)
    {
        if(blocks.Length == 0)
        {
            Debug.LogError("list of block is empty!");
            return;
        }

        _blocks = new LinkedList<Block>(blocks);
        SetListener();
    }

    private void SetListener()
    {
        foreach(var block in _blocks)
            block.Broken += BlockBrokenHandler;
    }

    private void BlockBrokenHandler(Block block)
    {
        _blocks.Remove(block);
        block.Broken -= BlockBrokenHandler;

        gameObject.transform.position -= Vector3.up * block.Height;
    }
}

