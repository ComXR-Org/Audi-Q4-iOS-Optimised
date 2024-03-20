using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffset : MonoBehaviour
{
    public Vector2 offset;
    public float speed = 2f;

    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset += offset * speed * Time.deltaTime;
    }

}
