using UnityEngine;

public class Destroyball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Collider2D col = GetComponent<Collider2D>();
        Debug.Log($"Destroyball.Start: name={name}, hasRigidbody2D={rb != null}, hasCollider2D={col != null}");
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        

        bool thisIsBall = IsBall(gameObject);
        bool otherIsBall = IsBall(other);
        bool thisIsFloor = IsFloor(gameObject);
        bool otherIsFloor = IsFloor(other);

       
        Debug.Log($"Destroyball.OnCollisionEnter2D: this={gameObject.name} tag={gameObject.tag} other={other.name} tag={other.tag}");

        if (thisIsBall && otherIsFloor)
        {
            
            if (IsBall(gameObject)) ScoreManager.Instance?.ResetCombo();
            Destroy(gameObject);
            return;
        }

      
        if (thisIsFloor && otherIsBall)
        {
            
            if (IsBall(other)) ScoreManager.Instance?.ResetCombo();
            Destroy(other);
            return;
        }

        
        if (other.name.ToLower().Contains("floor") && (thisIsBall || otherIsBall))
        {
            if (thisIsBall)
            {
                ScoreManager.Instance?.ResetCombo();
                Debug.Log($"Destroyball: destroying this ball {gameObject.name}");
                Destroy(gameObject);
            }
            else
            {
                ScoreManager.Instance?.ResetCombo();
                Debug.Log($"Destroyball: destroying other object {other.name}");
                Destroy(other);
            }
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        

        bool thisIsBallT = IsBall(gameObject);
        bool otherIsBallT = IsBall(otherObj);
        bool thisIsFloorT = IsFloor(gameObject);
        bool otherIsFloorT = IsFloor(otherObj);

        Debug.Log($"Destroyball.OnTriggerEnter2D: this={gameObject.name} tag={gameObject.tag} other={otherObj.name} tag={otherObj.tag}");

        if (thisIsBallT && otherIsFloorT)
        {
            
            if (IsBall(gameObject)) ScoreManager.Instance?.ResetCombo();
            Destroy(gameObject);
            return;
        }

        if (thisIsFloorT && otherIsBallT)
        {
           
            if (IsBall(otherObj)) ScoreManager.Instance?.ResetCombo();
            Destroy(otherObj);
            return;
        }

        if (otherObj.name.ToLower().Contains("floor") && (thisIsBallT || otherIsBallT))
        {
            if (thisIsBallT)
            {
                ScoreManager.Instance?.ResetCombo();
                Debug.Log($"Destroyball: destroying this ball (trigger) {gameObject.name}");
                Destroy(gameObject);
            }
            else
            {
                ScoreManager.Instance?.ResetCombo();
                Debug.Log($"Destroyball: destroying other object (trigger) {otherObj.name}");
                Destroy(otherObj);
            }
        }
    }

    

    private bool IsBall(GameObject go)
    {
        if (go == null) return false;
        string t = go.tag != null ? go.tag.ToLowerInvariant() : "";
        if (t == "ball") return true;
        if (go.name != null && go.name.ToLowerInvariant().Contains("ball")) return true;
        return false;
    }

    private bool IsFloor(GameObject go)
    {
        if (go == null) return false;
        string t = go.tag != null ? go.tag.ToLowerInvariant() : "";
        if (t == "floor") return true;
        if (go.name != null && go.name.ToLowerInvariant().Contains("floor")) return true;
        return false;
    }
}
