using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float radius;

    private bool _IsStartShake = false;
    private float _currentduration;

    Vector3 _camera_initial_pos;

    private void Start()
    {
        _camera_initial_pos = transform.localPosition;
        _currentduration = duration;
    }

    private void Update()
    {
        if(_IsStartShake)
        {
            transform.localPosition = new Vector3(Random.insideUnitSphere.x * radius * Time.deltaTime, Random.insideUnitSphere.y * radius * Time.deltaTime, transform.localPosition.z);

            _currentduration -= Time.deltaTime;

            if(_currentduration < 0 ) 
            {
                _currentduration = duration;
                transform.localPosition = _camera_initial_pos;
                _IsStartShake = false;
            }

        }
    }

    public void StartCameraShake()
    {
        _IsStartShake = true;
    }
}
