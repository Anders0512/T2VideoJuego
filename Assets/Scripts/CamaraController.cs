using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject player;
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var y = player.transform.position.y + 0.5f;
        transform.position = new Vector3(_transform.position.x, y, _transform.position.z);
    }
}
