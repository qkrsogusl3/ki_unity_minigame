﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSceneCatPlayGame : MonoBehaviour {
    public enum CATTYPE
    {
        HEAVEN = 0,
        MALE = 1,
        FEMALE =2,
    }
    public CMalecat PFMalecat = null;
    public CFemalecat PFFemalecat = null;
    public CDeadcat PFDeadcat = null;

    public Transform mSpawnPosition = null;

    public List<CCat> mCatList = null;

    public CUI mpUI = null;

    public GameObject mPanelResult = null;

    private bool mIsVisible = false;
    [SerializeField]
    private int mCatNum = 0;

    public List<Transform> mBoxList = null;

    public Text mTxtCount = null;

    // Use this for initialization
    void Start () {


        mpUI.SetScene(this);

        mCatList = new List<CCat>();

        CCat tpCat = null;

        //0
        tpCat = null;
        tpCat = Instantiate<CDeadcat>(PFDeadcat, mSpawnPosition.position, Quaternion.identity) as CDeadcat;
        tpCat.SetScene(this);
        mCatList.Add(tpCat);
        //1
        tpCat = null;
        tpCat = Instantiate<CMalecat>(PFMalecat, mSpawnPosition.position, Quaternion.identity) as CMalecat;
        tpCat.SetScene(this);
        mCatList.Add(tpCat);
        //2
        tpCat = null;
        tpCat = Instantiate<CFemalecat>(PFFemalecat, mSpawnPosition.position, Quaternion.identity) as CFemalecat;
        tpCat.SetScene(this);
        mCatList.Add(tpCat);
        
        

        int ti = 0;
        int tCount = 0;

        tCount = mCatList.Count;
        for(ti = 0; ti <tCount;ti++)
        {
            mCatList[ti].SetIsVisible(false);
        }

        // InvokeRepeating("Appear", 0.0f, 0.1f);
        Appear();
    }
	
	// Update is called once per frame
	void Update () {
  //      MyAppear();


    }
    public void Appear()
    {
        mCatNum = Random.Range(0, 3);

        mCatList[mCatNum].SetIsVisible(true);
        mCatList[mCatNum].transform.position = new Vector3(-2.0f, 0.0f, 0.0f);    
    }

    public void CompareBoxtoCat(CATTYPE tBoxType)
    {

        if(((CATTYPE)mCatNum) == tBoxType)
        {
            CHanMgr.GetInstance().AddCount();
            mTxtCount.text = CHanMgr.GetInstance().GetCount().ToString();

        }
    }

    public CCat GetCurrentCat()
    {
        return mCatList[mCatNum];
    }

    void MyAppear()
    {
        int tAppear = Random.Range(0, 3);
        int ti = 0;
        int tiCount = 0;
        int tCount = 0;
        tCount = mCatList.Count;
        /*
        for (ti = 0; ti < tCount; ti++)
        {
            if(false == mCatList[ti].GetIsVisible())
            {
                tiCount++;
                //if()
                mIsVisible = true;
              
            }
        }

        if (true == mIsVisible)
        {
            switch (tAppear)
            {
                case 0:
                    mCatList[0].SetIsVisible(true);
                    mIsVisible = false;
                    break;
                case 1:
                    mCatList[1].SetIsVisible(true);
                    mIsVisible = false;
                    break;
                case 2:
                    mCatList[2].SetIsVisible(true);
                    mIsVisible = false;
                    break;
            }
        }
        */
    }
    public Transform GetBox(CATTYPE tCatType)
    {
        return mBoxList[(int)tCatType];
    }

    public void SetReSultVisible(bool tIsVisible)
    {
        mPanelResult.SetActive(tIsVisible);
    }
}
