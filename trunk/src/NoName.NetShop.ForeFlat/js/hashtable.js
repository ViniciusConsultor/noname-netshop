var hashtable = function() { this.Clear(); }
hashtable.prototype = {
    add: function(key, value) { //实现Add 方法
        if (!key) return;
        if (typeof (value) === 'undefined') return;
        if (!this.containsKey(key)) this.count++;
        this.Items[key] = value;
    },
    clear: function() {                //实现Clear 方法
        this.Items = null;
        this.Items = new Object();
    },
    containsKey: function(key) {        //实现ContainsKey,检测表中是否包含特定的键
        if (!key) return false;
        if (typeof (this.Items[key]) == 'undefined')
            return false;
        return true;
    },
    containsValue: function(value) {    //实现ContainsValue,检测表中是否包含特定的值
        if (!value) return false;
        for (var key in this.Items) {
            if (this.Items[key] == value)
                return true;
        }
        return false;
    },
    count: 0,        //键或值总数
    getValue: function(key) {    //实现GetValue方法,通过键值获取value;                
        if (!this.containsKey(key)) return null;
        return this.Items[key];
    },
    getValueAt: function(index) {    //实现GetValueAt方法,通过索引值获取value;
        if (isNaN(index)) return null;
        if (index < 0 || index > this.count) return null;
        var i = 0;
        for (var key in this.Items) {
            if (i == index) return this.Items[key];
            i++;
        }
        return null;
    },
    keys: function() {  //实现Keys方法,获取hash表的所有key 返回Array
        var arr = new Array();
        for (var key in this.Items)
            arr.push(key);
        return arr;
    },
    remove: function(key) {    //实现Remove方法,删除某个特定的键
        if (!key) return;
        delete this.Items[key];
        this.count--;
        return;
    },
    removeAt: function(index) {    //实现Remove方法,删除某个特定的索引值
        if (isNaN(index)) return null;
        if (index < 0 || index > this.count) return null;
        var i = 0;
        for (var key in this.Items) {
            if (i == index) { this.remove(key); return; }
            i++;
        }
        return null;
    },
    removeRange: function(startindex, endindex) {    //RemoveRange 删除索引值在某个范围的值
        if (isNaN(startindex) || isNaN(endindex)) return null;
        if (startindex < 0) startindex = 0;
        if (endindex > this.count - 1) endindex = this.count - 1;
        for (var i = startindex; i < this.Count; i++)
            this.removeAt(i);
    },
    values: function() {    //实现Values方法,获取hash表的所有键的值 返回Array
        var arr = new Array();
        for (var key in this.Items)
            arr.push(this.Items[key]);
        return arr;
    },
    toString: function() {
        var str = '';

        for (var i = 0; i < this.keys().length; i++) {
            str += this.keys()[i] + ':' + this.values()[i] + ',';
        }

        return str.substring(0, str.length - 1);
    }
}