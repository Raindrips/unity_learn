using System;
using System.Collections;
using System.Collections.Generic;


//创建委托函数
public delegate void EventMessage();

//创建事件类
public class EventTarget {
    public event EventMessage eventMessage;

    public void Invoke() {
        eventMessage.Invoke();
    }
}


public class EventManager {
    private static Dictionary<string, EventTarget> dict = new Dictionary<string, EventTarget>();


    private static EventManager _instance;

    public static EventManager Instance {
        get {
            if (_instance == null) {
                _instance = new EventManager();
            }
            return _instance;
        }
    }

    public void On(string eventName, EventMessage message) {
        //如果不存在则添加
        if (!dict.ContainsKey(eventName)) {
            dict.Add(eventName, new EventTarget());
        }
        // 添加关注的事件
        dict[eventName].eventMessage += message;
    }

    public void Off(string eventName, EventMessage message) {
        if (!dict.ContainsKey(eventName)) {
            return;
        }
        dict[eventName].eventMessage -= message;
    }

    // 通知事件
    public void Invoke(string eventName) {
        if (dict.ContainsKey(eventName)) {
            dict[eventName].Invoke();
        }
    }


    private EventManager() {

    }
}
