//检查输入对象的值是否符合整数格式
function isInt(str)
{  
	var regu = /^[-]{0,1}[0-9]{1,}$/; 
	return regu.test(str); 
} 

//检查输入字符串是否只由汉字、字母、数字组成 
function isUsername(str)
{
	var regu = "^[0-9a-zA-Z\u4e00-\u9fa5]+$";   
	var re = new RegExp(regu); 
	return re.test(str);
} 

//E-Mail格式验证
function isEmail(str)
{
    var myReg = /^[.-_A-Za-z0-9]+@([-_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,4}$/;//^(?:\w+\.?)*\w+@(?:\w+\.)*\w+$/;//---/^[-_A-Za-z0-9]+@([-_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,3}$/;
    return myReg.test(str);
}

//验证手机号码格式是否正确 
function isMobile(str)
{
    var regu = /^[1][3|5|8|7][0-9]{9}$/;
    var re = new RegExp(regu);
    return re.test(str);
}

//检查输入字符串是否只由汉字、字母、数字组成 
function isPhone(str)
{
	var regu = "^[0-9\-\+]+$";   
	var re = new RegExp(regu); 
	return re.test(str);
} 

//密码验证
function isPassword(s)
{
		
	if(s.length < 6) {
		return 0;
	}
	var ls = 0;
	if(s.match(/([a-z])+/)) {
		ls++;
	}
	if(s.match(/([0-9])+/)) {
		ls++; 
	}
	if(s.match(/([A-Z])+/)) {
		ls++;
	}
   return ls;
}
