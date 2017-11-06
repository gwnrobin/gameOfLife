using UnityEngine;

public class CubesColor : MonoBehaviour
{
    public bool active;
    public bool aboutActive;
    public bool ready;
    public Renderer renderer;

	void Start ()
    {
        renderer = GetComponent<Renderer>();
        active = false;
        ChangeColor();
    }
	public void ToggleActive()
    {
        active = !active;
        aboutActive = active;
        ChangeColor();
    }
    public void SetReady()
    {
        active = aboutActive;
        ChangeColor();
    }
    public void ChangeColor()
    {
        if (active)
            {
                renderer.material.color = Color.red;
            } 
            else if (!active)
            {
                renderer.material.color = Color.blue;
            }
    }
}
