using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject firePoint;

    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Lấy ra vị trí điểm bắt đầu ( vị trí bắn ra đạn )
            Vector3 firePointPosition = firePoint.transform.position;
            //Transform firePointPosition = gameObject.transform;

            // Lấy ra vị trí chuột đã click
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
             * 1 . (fireX) vị trí bắt đầu
             * 2 . (mousePosition - fireX) *20 góc di chuyển
             * 3. 20 độ dài 
             * 4. layer
             */
            RaycastHit2D hit = Physics2D.Raycast(firePointPosition, (mousePosition - firePointPosition), 20, layer);
            // Vẽ 1 đường thẳng theo Raycast
            
                Debug.Log(hit.collider.tag);


            
        }
    }
}