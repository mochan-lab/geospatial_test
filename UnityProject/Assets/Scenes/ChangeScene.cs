using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private double _nowLat=0;
    private double _nowLon=0;
    private double _nowAlt=0;
    private float _nowAng=0;
    private int _objectNumber = 0;

    [SerializeField] private Dropdown _selectObject;
    [SerializeField] private Dropdown _selectPlace;
    [SerializeField] private InputField _latInput;
    [SerializeField] private InputField _lonInput;
    [SerializeField] private InputField _altInput;
    [SerializeField] private InputField _angInput;

    private double[] _m3place = new double[] { 34.821872, 135.521653, 100.5, -160 };
    private double[] _nakanosimaplace = new double[] { 34.69351, 135.50450, 39.4, 90 };
    private double[] _onTheM3 = new double[] { 34.82209, 135.52129, 100.1, -20 };
    private double[] _onTheKokaido = new double[] { 34.69355, 135.50397, 39.4, -20 };

    public void SelectedPlace()
    {
        if(_selectPlace.value == 0)
        {

        }
        else if(_selectPlace.value == 1)
        {
            _latInput.text = _m3place[0].ToString("F6");
            _lonInput.text = _m3place[1].ToString("F6");
            _altInput.text = _m3place[2].ToString("F6");
            _angInput.text = _m3place[3].ToString("F2");
        }
        else if(_selectPlace.value == 2)
        {
            _latInput.text = _nakanosimaplace[0].ToString("F6");
            _lonInput.text = _nakanosimaplace[1].ToString("F6");
            _altInput.text = _nakanosimaplace[2].ToString("F6");
            _angInput.text = _nakanosimaplace[3].ToString("F2");
        }
        else if (_selectPlace.value == 3)
        {
            _latInput.text = _onTheM3[0].ToString("F6");
            _lonInput.text = _onTheM3[1].ToString("F6");
            _altInput.text = _onTheM3[2].ToString("F6");
            _angInput.text = _onTheM3[3].ToString("F2");
        }
        else if (_selectPlace.value == 4)
        {
            _latInput.text = _onTheKokaido[0].ToString("F6");
            _lonInput.text = _onTheKokaido[1].ToString("F6");
            _altInput.text = _onTheKokaido[2].ToString("F6");
            _angInput.text = _onTheKokaido[3].ToString("F2");
        }
    }

    public void SelectObject()
    {
        _objectNumber = _selectObject.value;
    }

    private void changePlace()
    {
        _nowLat=Convert.ToDouble(_latInput.text);
        _nowLon=Convert.ToDouble(_lonInput.text);
        _nowAlt=Convert.ToDouble(_altInput.text);
        _nowAng=Convert.ToSingle(_angInput.text);
    }

    private void sceneLoadVar(Scene next, LoadSceneMode mode)
    {
        var changer = GameObject.Find("GeospatialController").GetComponent<Google.XR.ARCoreExtensions.Samples.Geospatial.GeospatialController>();
        if (changer != null)
        {

            changer._myLatitude = _nowLat;
            changer._myLongitude = _nowLon;
            changer._myAltitude = _nowAlt;
            changer._myAngle = _nowAng;
            changer.ObjectNumber = _objectNumber;
        }
        SceneManager.sceneLoaded -= sceneLoadVar;

    }

    public void StartARScene()
    {
        changePlace();
        SceneManager.sceneLoaded += sceneLoadVar;
        SceneManager.LoadScene("MyGeospatial");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
