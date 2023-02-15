using System.Collections;
using System.Collections.Generic;

public class CTree {
    public int size = 0;
    public List<string> keys = new List<string>();
    public List<string> values = new List<string>();
    public List<int> IDs = new List<int>();
    public List<string> endResult = new List<string>();

    public List<message> getValue(string key) {
        List<message> responses = new List<message>();

        if(keys.Contains(key)) {
            for(int i = 0; i<size; i++) {
                if(keys[i] == key) {
                    responses.Add(new message(values[i], IDs[i]));
                }
            }
        }else{
        }
        return responses;
    }


    public void insert(string key, string value, int ID) {
        size+=1;
        keys.Add(key);
        values.Add(value);
        IDs.Add(ID);
    }

    public int remove(string key, string value, int I) {
        for(int i=0;i<size;i++) {
            if((keys[i] == key && values[i] == value) && IDs[i] == I) {
                keys.RemoveAt(i);
                values.RemoveAt(i);
                IDs.RemoveAt(i);
                size-=1;
                return 1;
            }
        }
        return 0;
    }

    public void AddEndResult(string End) {
        endResult.Add(End);
    }

    public int GetIndexResult(string End) {
        for(int i=0;i<endResult.Count;i++) {
            if(endResult[i] == End) {
                return i;
            }
        }

        return -1;
    }
}

public class message{
    public int id;
    public string s;

    public message(string m, int i) {
        id = i;
        s = m;
    }
}
