using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubeA;
    public GameObject cubeS;
    public GameObject cubeD;
    private Vector3 _position;
    private float _timeSpawn = 1f;
    private float _time = 0f;
    private GameObject _cubA;
    private GameObject _cubS;
    private GameObject _cubD;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Time.time > _time)
        {
            int i = Random.Range(0, 3);
            switch (i)
            {
                case 0:
                {
                    _position = new Vector3(-2.5f, 5.5f, 0);
                    if (!_cubA)
                        _cubA =  Instantiate(cubeA, _position, Quaternion.identity, transform);
                    break;
                }
                case 1:
                {
                    _position = new Vector3(0, 5.5f, 0);
                    if (!_cubS)
                        _cubS = Instantiate(cubeS, _position, Quaternion.identity, transform);
                    break;
                }
                case 2:
                {
                    _position = new Vector3(2.5f, 5.5f, 0);
                    if (!_cubD)
                        _cubD = Instantiate(cubeD, _position, Quaternion.identity,transform);
                    break;
                }
            }
            _time += _timeSpawn;
        }
    }
}
