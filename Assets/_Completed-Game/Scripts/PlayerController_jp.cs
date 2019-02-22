using UnityEngine;
using UnityEngine.UI;//Unity UI（Textなど）を使用するために必要

public class PlayerController_jp : MonoBehaviour {
	
  // 変数の宣言。プレイヤーのスピードや、テキストのUIゲームオブジェクトのためにpubric(パブリック)な値をつくる
	public float speed;
	public Text countText;
	public Text winText;

  private Rigidbody rb; //プレイヤーについているRigidbody(リジッドボディ)コンポーネントのための宣言
	private int count; //拾ったpick up objectsのカウントのprivate(プライベート)な値の宣言

  // ゲームがスタートしたときに実行
	void Start ()
	{
    //上記で宣言していたrbの値に自分自身のRigidbodyコンポーネントを代入する
		rb = GetComponent<Rigidbody>();

    //ゼロをカウントに代入する
    count = 0;

    //UIをアップデートするためにSetCountText関数(後述)を実行する
    SetCountText ();

    //Win Text UIのtextプロパティに空のstring(ストリング)をセットし、
		//'You Win'(ゲームオーバーメッセージ)を空欄にする
    winText.text = "";
	}

  //一定間隔(physics step)ごとに実行 
  void FixedUpdate ()
	{
		//水平、垂直方向の入力の値をlocalの（FixedUpdate内のみで使用する）float(フロート)値に代入する
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    //Vector3値をつくり、上記の水平・垂直方向の値をXとZに代入する
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    //上記Vector3のmovementに'speed'の値を掛け算し、その値を使ってプレイヤーのrigidbodyに物理的な力を加える
    //'speed'はインスペクターに現れているpublicなプレイヤースピード
		rb.AddForce (movement * speed);
	}

	//このオブジェクト(プレイヤー)が、is triggerのチェックボタンがオンになっているコライダーを通過したときに、
	//コライダーへの参照を変数名'other'に保持しておく('other'にぶつかった相手のオブジェクトが代入される)
  void OnTriggerEnter(Collider other) 
	{
    //もし通過したゲームオブジェクトが'Pick Up'タグになっていたら、
		if (other.gameObject.CompareTag ("Pick Up"))
		{
    	//otherゲームオブジェクト(pick up)を非活性(inactive)にして、非表示にする
			other.gameObject.SetActive (false);

      //'count'の値に1を足す
			count = count + 1;

      //SetCountText関数(下記参照)を実行する
      SetCountText();
		}
	}

  //'countText'UIをアップデートできるように、独立した関数を作り、winに必要な量を満たしているかをチェックする
  void SetCountText()
	{
		//'countText'値のテキストフィールドを更新する
		countText.text = "Count: " + count.ToString ();

		//'count'が12以上かどうかをチェックする
		if (count >= 12) 
		{
			//'winText'にテキストを代入する
			winText.text = "You Win!";
		}
	}
}