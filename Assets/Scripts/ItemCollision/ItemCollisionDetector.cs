using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCollisionDetector : MonoBehaviour
{
    protected SpriteRenderer mySpriteRenderer;

    [SerializeField] Sprite denySprite;
    protected Sprite mySprite;

    [SerializeField] protected GameObject gridManagerObj; 
    protected GridManager gridManager;

    protected float counter = 0;

    void Start()
    {
        gridManager = gridManagerObj.GetComponent<GridManager>();
    }

    public abstract bool CanBePlaced();

    public void ResetCounter()
    {
        counter = 0;
    }

    public void SetSprite(Sprite sp) {
        mySprite = sp;

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = mySprite;
    }

    public void ChangeSprite() // nie podoba mi się to, wykonuje się cały czas
    {
        if (CanBePlaced()) // trzeba zmienić
        {
            mySpriteRenderer.sprite = mySprite;
        }
        else
        {
            mySpriteRenderer.sprite = denySprite;
        }
    }
}
