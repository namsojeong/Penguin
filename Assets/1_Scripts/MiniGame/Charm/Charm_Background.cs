using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_Background : MonoBehaviour
{
    private MeshRenderer renderer;

    private float speed=0.05f;
    private float offset;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
