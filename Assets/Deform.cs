using UnityEngine;

public enum Axis
{
    x, y, z
};

public class Deform : MonoBehaviour { 

    Mesh mesh;
    Vector3[] initVertices;
    Vector3[] vertices;
    Vector3[] noiseVertices;

    [SerializeField] float amount = 30.0f;
    [SerializeField] float frequency = 1.0f;
    [SerializeField] float smooth = 1.0f;
    [SerializeField] Axis axis  = Axis.z;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        initVertices = mesh.vertices;
        noiseVertices = mesh.vertices;
    }
    void Update()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        for (var i = 0; i < vertices.Length; i++)
        {
            if (axis == Axis.z)
                noiseVertices[i].z = initVertices[i].z + (amount * Mathf.PerlinNoise(Time.time * frequency + i * smooth, 0));
            if (axis == Axis.x)
                noiseVertices[i].x = initVertices[i].x + (amount * Mathf.PerlinNoise(Time.time * frequency + i * smooth, 0));
            if (axis == Axis.y)
                noiseVertices[i].y = initVertices[i].y + (amount * Mathf.PerlinNoise(Time.time * frequency + i * smooth, 0));
        }

        mesh.vertices = noiseVertices;
    }
}