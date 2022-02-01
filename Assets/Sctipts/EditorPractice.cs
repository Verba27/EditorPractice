using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random; 

public class EditorPractice : EditorWindow
{
    private Color paintColor;
    private Color eraseColor;
    private Texture2D texture;
    private static int rows = 9;
    private static int colums = 9;
    private int width = 50;
    private int height = 50;
    private Color[,] colors = new Color[rows, colums];
    private GameObject obj;
    
    
    [MenuItem("Window/DrawTexture")]
    private static void OpenMyEditorWindow()
    {
        GetWindow<EditorPractice>();
    }

    void OnEnable()
    {
        for (int i = 0; i < colums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                colors[i,j] = new Color(
                    Random.Range(0, 1f),
                    Random.Range(0, 1f),
                    Random.Range(0, 1f),
                    1);
            }
        } 
        texture = new Texture2D(20, 20);
    }
    
    private Color SetRandomColor()
    {
        var color = new Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            1);
        return color;
    }
    
    private void OnGUI()
    {
        Event evnt = Event.current;
        GUILayout.Label("Choose color");
        paintColor = EditorGUILayout.ColorField(paintColor);
        eraseColor = EditorGUILayout.ColorField(eraseColor);
        obj = EditorGUILayout.ObjectField(obj,typeof(GameObject)) as GameObject;
        if (GUILayout.Button("FillTextureByColor"))
        {
            ColorAllSquares();
        }
        if (GUILayout.Button("ColorObject"))
        {
            SetNewTexture();
        }
        for (int i = 0; i < colums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                var position = new Rect((i* (width + 5)), (j* (height + 5)) + 150, width, height);
                
                GUI.color = colors[i,j];
                GUI.DrawTexture(position,texture);
                if (position.Contains(evnt.mousePosition))
                {
                    if (evnt.type == EventType.MouseDown && evnt.button == 0)
                    {
                        Debug.Log("left");
                        colors[i,j] = paintColor;
                        texture.SetPixel(i, j, GUI.color);
                        Event.current.Use();
                    }
                    if (evnt.type == EventType.MouseDown && evnt.button == 1)
                    {
                        Debug.Log("Right");
                        colors[i,j] = eraseColor;
                        texture.SetPixel(i, j, GUI.color);
                        Event.current.Use();
                    }
                }
           }
        }
    }

    private void SetNewTexture()
    {
        Texture2D alternativeTexture = new Texture2D(colums, rows);
        for (int i = 0; i < colums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                alternativeTexture.SetPixel(i,j, colors[i,j]);
            }
        }

        alternativeTexture.filterMode = FilterMode.Point;
        alternativeTexture.Apply();
        if (obj.TryGetComponent(out MeshRenderer renderer))
        {
            Material material = renderer.material; 
            material.mainTexture = alternativeTexture;
            
        }
    }

    void ColorAllSquares()
    {
        for (int i = 0; i < colums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                colors[i,j] = paintColor;
            }
        }
    }
}
