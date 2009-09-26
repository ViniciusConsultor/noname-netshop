String.prototype.Trim = function() 
{  
  var m = this.match(/^\s*(\S+(\s+\S+)*)\s*$/);  
  return (m == null) ? "" : m[1];  
}

String.prototype.isMobile = function() 
{  
  return (/^1[358]\d{9}$/.test(this.Trim()));  
} 

String.prototype.isTelephone = function()
{
	//"兼容格式: 国家代码(2到3位)-区号(2到3位)-电话号码(7到8位)-分机号(3位)"
	//return (/^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/.test(this.Trim()));
	return (/^(([0\+]\d{2,3}-?)?(0\d{2,3})-?)(\d{7,8})(-(\d{3,}))?$/.test(this.Trim()));
}

String.prototype.isEmail = function()
{
	return (/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(this.Trim()));
}

String.prototype.isDouble = function()
{
	return (/^[-\+]?\d+(\.\d+)?$/.test(this.Trim()));
}

String.prototype.isCurrency = function()
{
	return (/^\d+(\.\d+)?$/.test(this.Trim()));
}

String.prototype.isChinese = function()
{
	return (/^[\u0391-\uFFE5]+$/.test(this.Trim()));
}

String.prototype.isCurrency = function()
{
	return (/^[-\+]?\d+(\.\d+)?$/.test(this.Trim()));
}

String.prototype.isInteger = function()
{
	return (/^[-\+]?\d+$/.test(this.Trim()));
}

String.prototype.isNumber = function()
{
	return (/^\d+$/.test(this.Trim()));
}

String.prototype.isEnglish = function()
{
	return (/^[A-Za-z]+$/.test(this.Trim()));
}

String.prototype.isUrl = function()
{
	return (/^http:\/\/([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?$/.test(this.Trim()));
}

String.prototype.isQQ = function()
{
	return (/^[1-9]\d{4,8}$/.test(this.Trim()));
}

String.prototype.isIDNO = function()
{
	return (/^\d{6}(19|20)?\d{2}(0[1-9]|10|11|12)([012]\d|30|31)\d{3}[xX\d]?$/.test(this.Trim()));
}

String.prototype.isPostalCode = function()
{
	return (/^\d{6}$/.test(this.Trim()));
}




