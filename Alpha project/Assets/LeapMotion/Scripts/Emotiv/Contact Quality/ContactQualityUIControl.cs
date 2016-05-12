using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Emotiv;
public class ContactQualityUIControl : MonoBehaviour {

    public GameObject insight, epoc;
    public enum HeadsetUIType
    {
        Insight = 0,
        Epoc
    }

	private static ContactQualityUIControl _instance;
	public static ContactQualityUIControl Instance{
		get{
			return _instance;
		}
	}
	public Image[] epocChannel, insightChannel;
    public int type;
	// Use this for initialization

	void Awake(){
		_instance = this;
	}
	void Start () {
		setColor (null);
	}

	public void ShowHeadset(int _type){
		if (epoc == null) {
			return;
		}
		type = _type;
		if (type == 0)
		{
			epoc.SetActive(true);
			insight.SetActive(false);
		}
		else
		{
			epoc.SetActive(false);
			insight.SetActive(true);
		}
	}
    //insight
    public void setColor(EdkDll.IEE_EEG_ContactQuality_t[] contacts)
    {
		if (contacts == null) {
			for (var i = 0; i < epocChannel.Length;i++){
				epocChannel[i].color = getColor(EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			}
			insightChannel[0].color = getColor (EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			insightChannel[1].color = getColor (EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			insightChannel[2].color = getColor (EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			insightChannel[3].color = getColor (EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			insightChannel[4].color = getColor (EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			insightChannel[5].color = getColor (EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL);
			return;
		}
//        if (type == 0)
//        {
//			for (var i = 0; i < epocChannel.Length;i++){
//				epocChannel[i].color = getColor(contacts[i]);
//			}
//        }
//        else
//        {
			insightChannel[0].color = getColor(contacts[(int)EdkDll.IEE_InputChannels_t.IEE_CHAN_CMS]);
			insightChannel[1].color = getColor(contacts[(int)EdkDll.IEE_InputChannels_t.IEE_CHAN_AF3]);
			insightChannel[2].color = getColor(contacts[(int)EdkDll.IEE_InputChannels_t.IEE_CHAN_T7]);
			insightChannel[3].color = getColor(contacts[(int)EdkDll.IEE_InputChannels_t.IEE_CHAN_O1]);
			insightChannel[4].color = getColor(contacts[(int)EdkDll.IEE_InputChannels_t.IEE_CHAN_T8]);
			insightChannel[5].color = getColor(contacts[(int)EdkDll.IEE_InputChannels_t.IEE_CHAN_AF4]);
 //       }
    }
    int current = 0;
    public void test()
    {
        EdkDll.IEE_EEG_ContactQuality_t[] contacts = new EdkDll.IEE_EEG_ContactQuality_t[17];
        for (int i = 0; i < 17; i++)
        {
            contacts[i] = (EdkDll.IEE_EEG_ContactQuality_t)((current + i) % 5);
        }
        current++;
        setColor(contacts);
    }

    private Color getColor(EdkDll.IEE_EEG_ContactQuality_t node)
    {
        Color returnButt;
        switch (node)
        {
            case EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_NO_SIGNAL:
                //returnButt = Color.black;
                returnButt = new Color(Color.black.r, Color.black.g, Color.black.b, 1f);
                break;
            case EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_VERY_BAD:
                //returnButt = Color.red;
                returnButt = new Color(Color.red.r, Color.red.g, Color.red.b, 1f);
                break;
            case EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_POOR:
                returnButt = new Color(1.0F, 0.5F, 0.0F, 1f);
                //returnButt = new Color(Color.black.r, Color.black.g, Color.black.b, 0.3f);
                break;
            case EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_FAIR:
                //returnButt = Color.yellow;
                returnButt = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 1f);
                break;
            case EdkDll.IEE_EEG_ContactQuality_t.IEEG_CQ_GOOD:
                //returnButt = Color.green;
                returnButt = new Color(Color.green.r, Color.green.g, Color.green.b, 1f);
                break;
            default:
                //returnButt = Color.black;
                returnButt = new Color(Color.black.r, Color.black.g, Color.black.b, 1f);
                break;
        }
        return returnButt;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
