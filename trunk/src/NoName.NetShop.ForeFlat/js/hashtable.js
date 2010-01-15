var Hashtable = function() { this.Clear(); }
Hashtable.prototype = {
    Add: function(key, value) { //实现Add 方法
        if (!key) return;
        if (typeof (value) === 'undefined') return;
        if (!this.ContainsKey(key)) this.Count++;
        this.Items[key] = value;
    },
    Clear: function() {                //实现Clear 方法
        this.Items = null;
        this.Items = new Object();
    },
    ContainsKey: function(key) {        //实现ContainsKey,检测表中是否包含特定的键
        if (!key) return false;
        if (typeof (this.Items[key]) == 'undefined')
            return false;
        return true;
    },
    ContainsValue: function(value) {    //实现ContainsValue,检测表中是否包含特定的值
        if (!value) return false;
        for (var key in this.Items) {
            if (this.Items[key] == value)
                return true;
        }
        return false;
    },
    Count: 0,        //键或值总数
    GetValue: function(key) {    //实现GetValue方法,通过键值获取value;                
        if (!this.ContainsKey(key)) return null;
        return this.Items[key];
    },
    GetValueAt: function(index) {    //实现GetValueAt方法,通过索引值获取value;
        if (isNaN(index)) return null;
        if (index < 0 || index > this.Count) return null;
        var i = 0;
        for (var key in this.Items) {
            if (i == index) return this.Items[key];
            i++;
        }
        return null;
    },
    Keys: function() {  //实现Keys方法,获取hash表的所有key 返回Array
        var arr = new Array();
        for (var key in this.Items)
            arr.push(key);
        return arr;
    },
    Remove: function(key) {    //实现Remove方法,删除某个特定的键
        if (!key) return;
        delete this.Items[key];
        this.Count--;
        return;
    },
    RemoveAt: function(index) {    //实现Remove方法,删除某个特定的索引值
        if (isNaN(index)) return null;
        if (index < 0 || index > this.Count) return null;
        var i = 0;
        for (var key in this.Items) {
            if (i == index) { this.Remove(key); return; }
            i++;
        }
        return null;
    },
    RemoveRange: function(startindex, endindex) {    //RemoveRange 删除索引值在某个范围的值
        if (isNaN(startindex) || isNaN(endindex)) return null;
        if (startindex < 0) startindex = 0;
        if (endindex > this.Count - 1) endindex = this.Count - 1;
        for (var i = startindex; i < this.Count; i++)
            this.RemoveAt(i);
    },
    Values: function() {    //实现Values方法,获取hash表的所有键的值 返回Array
        var arr = new Array();
        for (var key in this.Items)
            arr.push(this.Items[key]);
        return arr;
    },
    ToString: function() {
        var str = '';

        for (var i = 0; i < this.Keys().length; i++) {
            str += this.Keys()[i] + ':' + this.Values()[i] + ',';
        }

        return str.substring(0, str.length - 1);
    }
}