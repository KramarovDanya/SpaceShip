using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MeshRenderer meshRenderer;

    private Vector2 meshOffset;
    // Start is called before the first frame update
    void Start()
    {
        meshOffset = meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        meshRenderer.sharedMaterial.mainTextureOffset = meshOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float speedOffsetX = speed * Input.GetAxis("Horizontal");
        float speedOffsetY = speed * Input.GetAxis("Vertical");
        float x = Mathf.Repeat(Time.deltaTime * speed, 1);
        float y = Mathf.Repeat(Time.deltaTime * speedOffsetY, 1);

        Vector2 offset = new Vector2(x, meshOffset.y);

        meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
