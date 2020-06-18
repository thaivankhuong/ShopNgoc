var fc_thumb, fc_thumb_src;
$(document).ready(function(){

	// tạo background cho ảnh
	if($('.fc-thumb').length){
		$('.fc-thumb').each(function(){
			fc_thumb = $(this);
			fc_thumb_src = fc_thumb.children('img').attr('src');
			fc_thumb.attr('style', 'background-image:url('+fc_thumb_src+')');
			fc_thumb_src = fc_thumb.children('img').css({'display': 'none'});
		});
	}

});