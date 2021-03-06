using UnityEngine;
using System;
using System.Collections.Generic;

public class Buff<T>{
	protected BuffBar<T> buffBar;
	protected float startTime = 0;
	protected int ID = 0;
	protected string buffName = null;
	protected string discription = null;
	public int layerCount = 1;
	public float duration = 0;
	public float restDuration = 0;
	public Dictionary<BuffCallback,BuffDelegator> recieverDic;
	public int GetID(){
		return ID;
	}
	public string GetName(){
		return buffName;
	}
	public string GetDiscription(){
		return discription;
	}
	public Buff(){
		recieverDic = new Dictionary<BuffCallback, BuffDelegator>();
	}

	public virtual void OnAttach(T owner,BuffBar<T> buffBar){
		this.buffBar = buffBar;
		startTime = Time.time;
		//SendMessage : BUFF_ON_ATTACH : owner,this
	}
	public virtual void Run(T owner){
		if (isTimeUp ()) {
			buffBar.Remove (this);
		}
	}
	public virtual void OnRemove(T owner){
		//SendMessage : BUFF_ON_REMOVE : owner,this
		Debug.Log("removed");
	}
	public virtual void OnCover(T owner,Buff<T> buff){
		// Dictionary<string,System.Object> param = new Dictionary<string,System.Object>();
		// param.Add("owner",owner.GetID());
		// NotifySystem.NotifyEvent evt = new NotifySystem.notifyEvent(NotifySystem.NotifyType.BUFF_ON_COVER,param);
		// NotifySystem.NotifacitionCenter.getInstance().postNotification()
		// //SendMessage : BUFF_ON_COVER : owner,this
	}
	protected virtual bool isTimeUp(){
		return Time.time > startTime + duration;;
	}
	protected virtual float UpdateRestDuration(){
		restDuration = startTime + duration - Time.time;
		return restDuration;
	}
}
