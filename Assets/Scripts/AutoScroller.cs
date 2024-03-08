using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{
    
    public float scrollerSpeed = 0.2f;
    [SerializeField] private MeshRenderer mesh;

    // Update is called once per frame
    void Update()
    {
        OffsetForward();
    }

    void OffsetForward()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollerSpeed);
        mesh.material.mainTextureOffset = offset;
    }
}
