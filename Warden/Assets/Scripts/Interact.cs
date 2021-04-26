using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
To do:
- Make a catcher for phrases, missions and aboding comments
- Make a mission list
- Make missions appear on UI
*/
public class Interact : MonoBehaviour
{
    public GameObject bubble,attention,dropdown,target;
    public Text txt;
    public TextAsset dialog;
    private string uncompiled;
    private List<string> eachLine;

    private bool nextline;
    public bool enabledropdown = false, partwaystop = false, enabletarget;
    public int maxlines = 0;
    public int place = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextline = false;
        uncompiled = dialog.text;
        eachLine = new List<string>();
        eachLine.AddRange(uncompiled.Split("\n"[0]));
        if(maxlines == 0){
            maxlines = eachLine.Count;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("return")){
            nextline = false;
        }
    }

    void PrintLine(string find, int loc){
        

        txt.text = eachLine[loc];
        place +=1;
        Debug.Log(txt.text);
        /*float time = 1.0f;
        for(int i = 0; i < eachLine.Count; i++)
        {
            string check = eachLine[i].Trim();
            if(check.Equals(find)){

            }
            else{
                char[] cycle = eachLine[i].ToCharArray();
                int point = cycle.Length;
                while(!nextline){
                    txt.text = eachLine[i];
                    if(nextline){
                        while(time > 0.0f){
                            time -= Time.deltaTime;
                            Debug.Log(time);
                        }
                        txt.text += cycle[cycle.Length-point];
                        point--;
                        time = 1.0f;
                    }
                }

            }
        }*/
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player" && Input.GetKeyDown("return")){
            Debug.Log("Enter");
            if(nextline == false){
                if(place >= maxlines){
                    if(partwaystop){
                        bubble.SetActive(false);
                        attention.SetActive(false);
                        maxlines = eachLine.Count;
                        partwaystop = false;

                        if(enabletarget){
                            target.SetActive(true);
                        }

                        this.gameObject.SetActive(false);
                    }
                    else{
                        if(enabledropdown == false)
                        {
                            bubble.SetActive(false);
                            attention.SetActive(false);
                        }
                        else{
                            
                            attention.SetActive(false);
                            dropdown.SetActive(true);
                            if(dropdown.GetComponent<Dropdown>().value != 0){
                                bubble.SetActive(false);
                                dropdown.SetActive(false);
                            }
                        }
                    }
                }
                else{
                    bubble.SetActive(true);
                    PrintLine("[1]", place);
                }
                nextline = true;
            }
        }
    }
}
