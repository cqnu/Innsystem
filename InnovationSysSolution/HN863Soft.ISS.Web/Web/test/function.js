 template.helper('getStar', function(num){  
     var endnum = 5-parseInt(num);
	 var str = '';
	 for(i=1;i<=parseInt(num);i++)
	 {
		 str += '<i class="fa fa-star"></i>';
	 }
	 
   if (num>parseInt(num)){
		 str += '<i class="fa fa-star-half-o"></i>';
		 for(j=1;j<endnum;j++)
		 {
			 str += '<i class="fa fa-star-o"></i>';
		 }
	 }else{
		 for(j=1;j<=endnum;j++)
		 {
			 str += '<i class="fa fa-star-o"></i>';
		 }
	 }
	 return str;
}); 

template.helper('getTag', function(tags){
	if(tags == null) {
		return '';
	}else if(tags.indexOf(',') > 0){
		var tarr = tags.split(',');
		var str = '';
		for(i=0;i<tarr.length;i++){
			str += '<span class="btn-tutor-1">'+tarr[i]+'</span>';
		}
		return str;
	}
	else
	{
		str = '<span class="btn-tutor-1">'+tags+'</span>';
		return str;
	}
	
});
