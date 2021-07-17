using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    public void SpawnCard()
    {
        //GameObject card = new GameObject("Card", typeof(SpriteRenderer));
        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        GameObject card = Instantiate(GameAsset.Instance.cardTemplate, position, Quaternion.identity, this.transform);
        card.GetComponent<SpriteRenderer>().sprite = GameAsset.Instance.hearts[Random.Range(0, 13)];
        card.transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        card.transform.SetAsLastSibling();
    }
}
