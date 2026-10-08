using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationStep;
 
    public Vector3 RotationStep
    {
        get
        {
            Debug.Log("read");
            return rotationStep;
        }
        set
        {
            Debug.Log("write");
            rotationStep = value;
        }
    }
    
    /*
     * To test unity's messages like Awake, Start, etc., try this:
     * - In scene, disable (uncheck) the ship's game object AND this script component.
     * - Press play.
     * - Enable the game object, Awake() is called.
     * - Enable the script, rest are called in order.
     * - Turn off either, OnDisable() called.
     * - Delete in hierarchy, OnDestroy() is called.
     */

    // Awake is called when the script is first loaded
    void Awake()
    {
        Debug.Log("Awake!");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start!");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable!");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable!");
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy!");
    }

    /* https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity
     * From the forum https://discussions.unity.com/t/whats-the-difference-between-update-and-fixedupdate-when-are-they-called/1318:
       
           Update runs once per frame. FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is.
       
       Also refer to the answer given by duck in the same forum for a detailed explanation of the difference between the two.
       
           It's for this reason that FixedUpdate should be used when applying forces, torques, or other physics-related functions - because you know it will be executed exactly in sync with the physics engine itself.
       
           Whereas Update() can vary out of step with the physics engine, either faster or slower, depending on how much of a load the graphics are putting on the rendering engine at any given time, which - if used for physics - would give correspondingly variant physical effects!
     */
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Update on frame {Time.frameCount} has dt {Time.deltaTime}");
        // can reference transform like "this.transform" too
        transform.Rotate(rotationStep * Time.deltaTime, Space.Self);
    }

    void FixedUpdate()
    {
        //Debug.Log($"FixedUpdate on frame {Time.frameCount} has dt {Time.deltaTime}");
    }
}
