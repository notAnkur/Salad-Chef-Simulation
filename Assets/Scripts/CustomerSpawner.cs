using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> CustomerSpawnPoints;
    [SerializeField] private GameObject CustomerPrefab;
    private List<string> ItemsList = new List<string>(new string[] 
    { 
        Constants.Tomato, Constants.Brocolli, Constants.Carrot, Constants.Tomolli, Constants.Tarrot, Constants.Brorrocolli
    });
    private System.Random random = new System.Random();

    private void Start()
    {
        // instantiate customers at random intervals
        for(int customerIndex = 0; customerIndex < 3; customerIndex++)
        {
            int RandomIndex = random.Next(0, 3); // random int between [0, 3)

            //StartCoroutine(SpawnCustomer(CustomerSpawnPoints[customerIndex]));
            GameObject customer = Instantiate(CustomerPrefab, CustomerSpawnPoints[customerIndex], false);
            customer.GetComponent<CustomerController>().SetCustomerOrder(GetRandomOrder());
        }
    }

    private string GetRandomOrder()
    {
        return ItemsList[random.Next(0, ItemsList.Count)]; // random int between [0, listSize)
    }

    public void SpawnCustomer(Transform ParentTransform)
    {
        StartCoroutine(SpawnCustomerCoroutine(ParentTransform));
    }

    public IEnumerator SpawnCustomerCoroutine(Transform ParentTransform)
    {
        yield return new WaitForSeconds(new System.Random().Next(2, 6));
        
        if(ParentTransform.childCount == 0)
        {
            GameObject customer = Instantiate(CustomerPrefab, ParentTransform, false);
            customer.GetComponent<CustomerController>().SetCustomerOrder(GetRandomOrder());
        }

    }
}
