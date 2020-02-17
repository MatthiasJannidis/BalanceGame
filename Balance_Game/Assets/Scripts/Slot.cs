using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    int blocksUp = 0;
    int blocksDown = 0;
    float spriteHalfHeight = .0f;
    float blockHalfHeight = .0f;

    public enum Direction : int
    {
        Up = 1,
        Down = -1
    }

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Bounds spriteBounds = spriteRenderer.sprite.bounds;
        spriteHalfHeight = spriteBounds.size.y;

        blockHalfHeight = settings.blockSprite.bounds.size.y*.5f;
    }

    void Update()
    {
        float blockPush = (float)(blocksDown - blocksUp);
        transform.Translate(Vector3.up * blockPush * settings.slotSpeed * Time.deltaTime);

        //todo : communicate this to a game controller-like object
        if(transform.position.y > settings.slotBoundaries) 
        {
            Debug.Log("UP PLAYER WON");
        }
        if(transform.position.y < -settings.slotBoundaries) 
        {
            Debug.Log("DOWN PLAYER WON");
        }
    }

    public void AddUpBlock() 
    {
        blocksUp++;
    }

    public void AddDownBlock() 
    {
        blocksDown++;
    }

    public bool InRangeUp(float givenY) 
    {
        float y = (transform.worldToLocalMatrix * new Vector4(transform.position.x, givenY, transform.position.z, 1.0f)).y;
        return y <= NextBlockYUp;
    }

    public float NextBlockYUp 
    { 
        get 
        {
            return (blocksUp+1)*blockHalfHeight + spriteHalfHeight*.5f; 
        } 
    }

    public bool InRangeDown(float givenY)
    {
        float y = (transform.worldToLocalMatrix * new Vector4(transform.position.x, givenY, transform.position.z, 1.0f)).y;
        return y >= NextBlockYDown;
    }

    public float NextBlockYDown
    { 
        get 
        {
            return -((blocksDown) * blockHalfHeight + spriteHalfHeight);
        } 
    }

    
}
