var cityData=
[
	{
		province:"北京市",value:"1",
		cities:[
			{name:"朝阳区",value:"10"},
			{name:"海淀区",value:"11"},
			{name:"东城区",value:"12"},
			{name:"西城区",value:"13"},
			{name:"崇文区",value:"14"},
			{name:"宣武区",value:"15"},
			{name:"顺义区",value:"16"},
			{name:"通州区",value:"17"}
		]
	},
	{
		province:"江西省",value:"2",selected:true,
		cities:[
			{name:"南昌市",value:"20"},
			{name:"九江市",value:"21",selected:true},
			{name:"赣州市",value:"22"},
			{name:"上饶市",value:"23"},
			{name:"吉安市",value:"24"},
			{name:"鹰潭市",value:"25"}
		]
	}
	,
	{
		province:"浙江省",value:"3",
		cities:[
			{name:"温州市",value:"30"},
			{name:"嘉兴市",value:"31"},
			{name:"绍兴市",value:"32"},
			{name:"杭州市",value:"33"}
		]
	}
]

function loadInitData(){
	provinceBox.clearOptions();
	var hasSelected=false;
	for(var i=0;i<cityData.length;i++){
		provinceBox.addOption(
			cityData[i].province,
			cityData[i].value,
			cityData[i].selected?"Selected":""
		)
		if(cityData[i].selected){
			showCityData(cityData[i].province,cityData[i].value);
			hasSelected=true;
		}
	}
	provinceBox.update();
	if(!hasSelected){
		showCityData(cityData[0].province,cityData[0].value);
	}
}

function showCityData(t,v){
	cityBox.clearOptions();
	for(var i=0;i<cityData.length;i++){
		if(cityData[i].province==t){
			for(var j=0;j<cityData[i].cities.length;j++){
				cityBox.addOption(
					cityData[i].cities[j].name,
					cityData[i].cities[j].value,
					cityData[i].cities[j].selected?"Selected":""
				)
			}
		}
	}
	cityBox.update();
}