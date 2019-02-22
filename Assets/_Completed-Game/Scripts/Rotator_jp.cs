using UnityEngine;

public class Rotator_jp : MonoBehaviour {

	[SerializeField] Vector3 eulerAngles;
	
    //毎フレームが更新するたびに何度も実行される（実行される時間間隔は一定ではない）
	void Update () 
	{
        // X軸に15,Y軸に30,Z軸に45、そしてそれぞれにdeltaTimeを掛け算して、
        // このスクリプトがアタッチされているゲームオブジェクト(pick up)を回転させる。
        // deltaTimeをかけるのは、一定速度での回転にするため。
		// deltaTimeはフレーム間の時間を取得してくれている。
		transform.Rotate (eulerAngles * Time.deltaTime);
	}
}