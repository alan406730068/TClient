using UnityEngine;

public class Tweener : MonoBehaviour
{
    [SerializeField] private float delay;
    private Vector3 scaleVector = new Vector3(0.3f, 0.3f, 0.3f);

    private void Start()
    {
        LeanTween.scale(gameObject, Vector3.one, 0.001f);
        LeanTween.scale(gameObject, scaleVector, 0.5f)
            .setDelay(delay)
            .setEase(LeanTweenType.easeInCirc)
            .setLoopPingPong();
    }
}
