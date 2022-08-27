using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameBox : MonoBehaviour
{
    RectTransform rectTransform;
    int size = 1;

    int cellsIndex = 0;

    private GameObject cellsPoor;
    public GameObject cell;

    private List<RectTransform> cellsPool = new List<RectTransform>();
    IEnumerator drawProess;
    public Dictionary<int,List<Vector3>> plan;
    public Sprite[] boxSprites;
    
    public List<Vector3> nowPlan;
    Dictionary<RectTransform,Vector3> nowContant = new Dictionary<RectTransform, Vector3>();
    public int nowTimeStemp = 0;
    public void StartGameBox(int winth,int hight,int size){
        rectTransform = gameObject.GetComponent<RectTransform>();
        SetGamebox(winth,hight);
        //TestPlan();
        //StartCoroutine(UpdateBoxContant());
       
    }

    void TestPlan()
    {
        List<Vector3> testList = new List<Vector3>();
        plan = new Dictionary<int, List<Vector3>>();
        int removeInt = 0;
        for(int _t = 0 ; _t < 10 ; _t++){
            testList = new List<Vector3>();
            removeInt ++;
            for(int _h = 0 ; _h < 19-removeInt ; _h++)
            {
                for(int _w = 0 ; _w < 9-removeInt ; _w++)
                {
                    Vector3 newCellPos = new Vector3(_w,_h,0);
                
                    testList.Add(newCellPos);
                }
            }
            plan.Add(_t, testList);
            Debug.LogFormat($"DrawTimeStemp :{_t},{testList.Count()}");
        }
        
      
    }
    public void Draw(){
        Debug.LogFormat($"NowTimeStemp :{nowTimeStemp}");
        foreach(KeyValuePair<int,List<Vector3>> obj in plan){
            if(nowTimeStemp == obj.Key){
                Debug.LogFormat($"DrawTimeStemp :{obj.Key}");
                CheckNowplan(obj.Value);
                Debug.LogFormat($"obj.Value :{obj.Value.Count()}");
                // for(int i = 0 ; i < obj.Value.Count; i++){
                //     CheckNowplan
                //         Vector2 _pos = GetCellPos(obj.Value[i].x, obj.Value[i].y);
                //         RectTransform _cell = GetCell();
                //         _cell.anchoredPosition = _pos;
                //         nowContant.Add(_cell);
                // }
                nowPlan = obj.Value;
            }
        }
    }

    void CheckNowplan(List<Vector3> obj){
       
      
        if(nowPlan != null){
            var expectedList = nowPlan.Except(obj);
            Debug.Log($"expectedList{expectedList.Count()}");
            List<RectTransform> rmList = new List<RectTransform>();
            foreach (var item in expectedList)
            {
                Debug.Log($"expectedList{item.ToString()}");
               
                foreach (var _cell in nowContant)
                {
                    if(_cell.Value == item){
                        _cell.Key.gameObject.SetActive(false);
                        rmList.Add(_cell.Key);
                        //nowContant.Remove(_cell.Key);
                    }
                }     
            }
            for(int i = 0 ; i <rmList.Count ; i++){
                nowContant.Remove(rmList[i]);
            }

            var unionList = nowPlan.Union(obj);
            var addList = obj.Except(nowPlan);
            Debug.Log($"addList{addList.Count()}");
            foreach (var item in addList)
            {
            
                Vector2 _pos = GetCellPos(item.x, item.y);
                RectTransform _cell = GetCell();
                _cell.anchoredPosition = _pos;
                nowContant.Add(_cell,item);
            }
        }else{
            foreach (var item in obj)
            {

                Vector2 _pos = GetCellPos(item.x, item.y);
                RectTransform _cell = GetCell();
                _cell.anchoredPosition = _pos;
                nowContant.Add(_cell, item);
            }
        }
            
    }

 
    void Update()
    {
        
    }
    private IEnumerator UpdateBoxContant()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Draw();
            
            nowTimeStemp++;
            if(nowTimeStemp > 10)
                break;
               
        }
        yield break;
    }
   
    void SetGamebox(int width,int hight)
    {
        rectTransform.sizeDelta = new Vector2(width * size * 10,hight *size * 10);
    }

    private Vector2 GetCellPos(float _x,float _y){
        Vector2 _pos = new Vector3();
        _pos.x = 5 + (_x*10);
        _pos.y = 5 + (_y*10);
//        Debug.Log(_pos);
        return _pos;
    }

    private RectTransform GetCell()
    {
        foreach (RectTransform item in cellsPool)
        {
            if(!item.gameObject.activeSelf){
                item.gameObject.SetActive(true);
                return item;
            }
        }
       
        GameObject _cell = Instantiate(cell, transform.position, transform.rotation);
        _cell.transform.SetParent(rectTransform);
        _cell.name = cellsIndex.ToString();
        cellsIndex++;
        RectTransform _cellRect = _cell.GetComponent<RectTransform>();
        _cellRect.localScale = Vector3.one;
        _cellRect.sizeDelta = new Vector2(10, 10);
        cellsPool.Add(_cellRect);
        return _cellRect;
    }

    void UpdateBoxContant(int timeStemp,int boxContant)
    {
        
    }

}
