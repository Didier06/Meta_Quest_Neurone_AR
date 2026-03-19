using UnityEngine;

public class RectangleOutline3D : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3 size = new Vector3(2f, 2f, 0f);
    public float lineWidth = 0.05f;
    public Color lineColor = Color.white;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 5; // 4 coins + retour au premier coin
        lineRenderer.loop = true; // Ferme automatiquement la boucle
        lineRenderer.useWorldSpace = true;

        // Définir les points du rectangle en 3D
        Vector3[] points = new Vector3[4];
        points[0] = transform.position + new Vector3(-size.x / 2, -size.y / 2, 0);
        points[1] = transform.position + new Vector3(size.x / 2, -size.y / 2, 0);
        points[2] = transform.position + new Vector3(size.x / 2, size.y / 2, 0);
        points[3] = transform.position + new Vector3(-size.x / 2, size.y / 2, 0);

        lineRenderer.SetPositions(points);
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // Utiliser un matériau simple pour les lignes
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }
}


