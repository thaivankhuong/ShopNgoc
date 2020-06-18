
$('.L_slide').owlCarousel({
  items: 1,
  loop: true,
  animateOut: 'fadeOut',
  animateIn: 'fadeInRight',
  autoplay:true,
  autoplayHoverPause:true,
});

$(document).ready(function() {
	$('#toTop').click(function(event) {
		event.preventDefault();
		$('html, body').animate({scrollTop: 0},500)
	});
                                            $('#fb_a').attr('href', 'http://www.facebook.com/sharer.php?u=' + location.href);
                                            $('#gg_a').attr('href', 'https://plus.google.com/share?url=' + location.href);
                                            $('#tw_a').attr('href', 'https://twitter.com/share?url=' + location.href);
                                        
});
$(window).scroll(function() {
	var hTop = $(this).scrollTop();
	if(hTop > 200) {
		$('#toTop').stop().animate({right:'10px'},1000);
	}else {$('#toTop').stop().animate({right:'-50px'},1000);}
});

$(document).ready(function(e) {
    $(".map-1").click(function(e) {
		$('.map-2').hide(),
        $(this).siblings('.map-2').show();
		
    });
});

$(window).load(function(e) {
    $('td#gs_tti50 input.gsc-input').attr('placeholder','Tìm kiếm sản phẩm tại đây');
});

$('.thumbs_list img').click(function(){
			var img_show=$(this).attr('src');
			$('#slider img').attr('src',img_show);
});

/// seand Order
function Orders() {
    var t = this;
    t.FullName = $('#Order_FullName').val();
    t.Address = $('#Order_Address').val();
    t.Mobi = $('#Order_Mobi').val();
    t.ProductName = $('#Order_ProductName').val();
    t.Email = $('#Order_Email').val();
    t.Content = $('#Order_Content').val();
}
function SendOrder() {
    $('#senOrderp').attr('disabled', 'disabled');
    $.ajax({
        type: "POST",
        url: "/Contact/OrderCreate/",
        data: JSON.stringify({ model: (new Orders) }),
        contentType: "application/json; charset=utf-8",
        dataType: "text",
        success: function (t) {

            if (t == 'true' || t == true) {
                $(".uk-modal-close").click();
                $('#senOrderp').removeAttr('disabled');
            }
            else {
                $('#ms_errorOrder').html("Gửi thông tin thất bại. Vui lòng kiểm tra lại thông tin!");
                //$('#ms_errorOrder').html(t);
            }

        }
    }).done(function () { })
}