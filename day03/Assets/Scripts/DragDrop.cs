using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    public GameObject tower;
    private towerScript towerScript;
    private Vector3 originPos;
    private RaycastHit2D hit;
    private GameObject tile;
    private Vector3 point;
    private gameManager gameManager;
    public Text damage;
    public Text price;
    public Text fireRate;
    public Text range;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager")
            .GetComponent<gameManager>();
        towerScript = tower.GetComponent<towerScript>();

        // Tower stats
        damage.text = "" + towerScript.damage;
        price.text = "" + towerScript.energy;
        fireRate.text = "" + towerScript.fireRate;
        range.text = "" + towerScript.range;
    }

    private bool EnoughEnergy()
    {
        return gameManager.playerEnergy >= towerScript.energy;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originPos = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (EnoughEnergy())
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(point.x, point.y, 12);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.position = originPos;

        if (hit = Physics2D.Raycast(point, Vector2.zero))
        {
            tile = hit.transform.gameObject;
            if (tile.tag == "empty")
            {
                Instantiate(tower, tile.transform.position, tile.transform.rotation);
                Destroy(hit.transform.gameObject);
                gameManager.playerEnergy -= towerScript.energy;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EnoughEnergy())
            gameObject.GetComponent<Image>().color = Color.white;
        else
            gameObject.GetComponent<Image>().color = Color.red;
    }
}

