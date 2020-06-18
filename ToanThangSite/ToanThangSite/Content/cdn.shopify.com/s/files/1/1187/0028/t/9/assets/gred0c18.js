window.gred = window.gred || {};
gred.init = function () {
  gred.showPopup();
  gred.hidePopup();
    gred.btnAddtocart();
    gred.toggleMenu();
  //gred.quickView();
  gred.checkItemsInMiniCart();
  gred.removeItemsInMiniCart();
  gred.updatePricing();

  gred.hideDropdown();
 // gred.initAddToCart();

  gred.initWishlist();
  gred.initProductWishlist();
  gred.initRemoveWishlist();


};

jQuery(document).ready(function(){
  "use strict";

  /*
  $('.toggle-menu .active').closest('.toggle-content').addClass('active');
*/
  
  var hH = $('.header--fixed').outerHeight();  
  $('.header-vsb').css( "height", hH );

  /* Currency */
  $('.currency-Picker .dropdown-content a').on('click', function() { 
    $("select.currency-picker").val($(this).data('value')).change();
    $(this).closest('.dropdown-content').removeClass('active');     
  });

  /* Memamenu */
  $(".width-full").each( function(){
    $(this).closest('.megamenu').addClass('full-width');

  });

  /* Countdown */
  $('.countdown ul').each( function(){      
    var endDate = $(this).data( 'date' );      
    $(this).countdown({
      date: endDate,        
      render: function(data) {
        $(this.el).html(
          '<li><span>' + this.leadingZeros(data.days, 2) + '</span> Days</li>'
          + '<li><span>' + this.leadingZeros(data.hours, 2) + '</span>Hours</li>'
          + '<li><span>' + this.leadingZeros(data.min, 2) + '</span>Mins</li>'
          + '<li><span>' + this.leadingZeros(data.sec, 2) + '</span>Secs</li>'
        );
      }
    });
  });

  /* Back to top */
  if ($('.back-to-top').length) {
    var scrollTrigger = 100, // px
        backToTop = function () {
          var scrollTop = $(window).scrollTop();
          if (scrollTop > scrollTrigger) {
            $('.back-to-top').addClass('show');
          } else {
            $('.back-to-top').removeClass('show');
          }
        };
    backToTop();
    $(window).on('scroll', function () {
      backToTop();
    });
    $('.back-to-top').on('click', function (e) {
      e.preventDefault();
      $('html,body').animate({
        scrollTop: 0
      }, 700);
    });
    }
    sumcart();
})


$(document).on('click','.overlay, .close-popup', function() {   
  gred.hidePopup('.gred-popup'); 
  setTimeout(function(){
    $('.loading').removeClass('loaded-content');
  },500);
  return false;
})


$(document).on('click touchstart', function(e) {
  var dropdown = $(".mini-cart.click.active");
    if (!dropdown.is(e.target) && dropdown.has(e.target).length === 0) {
        dropdown.removeClass('active');
    }
    else {
       //showcontentminicart khuong
       // alert("showw");
    }
});

jQuery('body').keydown(function(e) {
  if( e.which == 27) {
    gred.hidePopup('.gred-popup');    
    jQuery('body').unbind('keydown');
  }
});

$(".swiper-container").each( function(){

  var xs_item = $(this).attr('data-xs-items');
  var datarow = $(this).attr('data-row');


  if (typeof xs_item !== typeof undefined && xs_item !== false) {    
  } else{
    xs_item = 1;
  }

  if (typeof datarow !== typeof undefined && datarow !== false) {    
  } else{
    datarow = 1;
  }

  var config = {
    spaceBetween: $(this).data('margin'),
    slidesPerView: $(this).data('items'),
    direction: $(this).data('direction'),
    slidesPerColumn: datarow,
    paginationClickable: true,
    grabCursor: true,
    nextButton: '.swiper-button-next',
    prevButton: '.swiper-button-prev',
    breakpoints: {

      320: {
        slidesPerView: xs_item,
        spaceBetweenSlides: 10
      },

      480: {
        slidesPerView: xs_item,
        spaceBetweenSlides: 20
      },

      640: {
        slidesPerView: xs_item,
        spaceBetweenSlides: 20
      },

      980: {
        slidesPerView: 3,
        spaceBetweenSlides: 20
      }
    }
  };		
  var swiper = new Swiper(this, config);
});


/********************************************************
# MINICART
********************************************************/
$('.mini-cart.click > a').click(function(event) {
  event.preventDefault();
  $(this).parent().toggleClass("active");
});


jQuery(document).ready(function(){

  gred.quantity();
  $('.close-noitice').click(function(e){
    e.preventDefault(); 
    $(this).parent().animate({right: '-300px'}, 500);  
  })


  $('.dropdown-toggle > a').click(function() {
    $('.mini-cart-default').removeClass('active');    
    if($(this).closest('.dropdown-toggle').find('.dropdown-content').hasClass('active')){
      $('.dropdown-content').removeClass('active');
    }else{
      $('.dropdown-content').removeClass('active');
      $(this).closest('.dropdown-toggle').find('.dropdown-content').addClass('active');  
    }     
    return false;              
  }); 



  /* Tabs */
  $(".e-tabs").each( function(){
    $(this).find('.tabs-title li:first-child').addClass('current');
    $(this).find('.tab-content').first().addClass('current');

    $(this).find('.tabs-title li').click(function(){
      var tab_id = $(this).attr('data-tab');

      var url = $(this).attr('data-url');
      $(this).closest('.e-tabs').find('.tab-viewall').attr('href',url);

      $(this).closest('.e-tabs').find('.tabs-title li').removeClass('current');
      $(this).closest('.e-tabs').find('.tab-content').removeClass('current');

      $(this).addClass('current');
      $(this).closest('.e-tabs').find("#"+tab_id).addClass('current');
    });    
  });

});


/********************************************************
# toggle-menu
********************************************************/
gred.toggleMenu = function () {  
  $('.toggle-menu .caret').click(function() {
    $(this).closest('.toggle-content').find('.sub-menu').slideToggle("fast");
    return false;              
  }); 
}


/********************************************************
# QUANTITY
********************************************************/
gred.hideDropdown = function () {  
  $(document).on('click touchstart', function(e) {
    var dropdown = $(".dropdown-content");
    if (!dropdown.is(e.target) && dropdown.has(e.target).length === 0) {
      dropdown.removeClass('active');      
    }
  });
}

gred.quantity = function () {  
  $('.qtyplus').click(function(e){  
    e.preventDefault();   
    fieldName = $(this).attr('data-field'); 
    var currentVal = parseInt($('input[data-field='+fieldName+']').val());
    if (!isNaN(currentVal)) { 
      $('input[data-field='+fieldName+']').val(currentVal + 1);
    } else {
      $('input[data-field='+fieldName+']').val(0);
    }
    gred.updatePricing();
  })

  $(".qtyminus").click(function(e) {
    e.preventDefault(); 
    fieldName = $(this).attr('data-field');
    var currentVal = parseInt($('input[data-field='+fieldName+']').val());
    if (!isNaN(currentVal) && currentVal > 1) {          
      $('input[data-field='+fieldName+']').val(currentVal - 1);
    } else {
      $('input[data-field='+fieldName+']').val(1);
    }
    gred.updatePricing();
  })

  $('#Quantity').on('change' , function () { 
    gred.updatePricing();
  })
}


/********************************************************
# SHOW NOITICE
********************************************************/
gred.showNoitice = function (selector) {   
  $(selector).animate({right: '0'}, 500);
  setTimeout(function() {
    $(selector).animate({right: '-300px'}, 500);
  }, 3500);
};


/********************************************************
# SHOW LOADING
********************************************************/
gred.showLoading = function (selector) {    
  var loading = $('.loader').html();
  $(selector).addClass("loading").append(loading);  
}

/********************************************************
# HIDE LOADING
********************************************************/
gred.hideLoading = function (selector) {  
  $(selector).removeClass("loading"); 
  $(selector + ' .loading-icon').remove();
}


/********************************************************
# SHOW POPUP
********************************************************/
gred.showPopup = function (selector) {
  $(selector).addClass('active');
};

/********************************************************
# HIDE POPUP
********************************************************/
gred.hidePopup = function (selector) {
  $(selector).removeClass('active');
}

/********************************************************
# CONVERTTOSLUG
********************************************************/
gred.convertToSlug = function (text) {
  return text.toLowerCase().replace(/[^a-z0-9 -]/g, '').replace(/\s+/g, '-').replace(/-+/g, '-');
}


/********************************************************
# UPDATEPRICING
********************************************************/
gred.updatePricing = function(){

  var regex = /([0-9]+[.|,][0-9]+[.|,][0-9]+)/g;
  var unitPriceTextMatch = jQuery('.product-single .product-single-prices .money').text().match(regex);

  if (!unitPriceTextMatch) {
    regex = /([0-9]+[.|,][0-9]+)/g;
    unitPriceTextMatch = jQuery('.product-single .product-single-prices .money').text().match(regex);     
  }

  if (unitPriceTextMatch) {
    var unitPriceText = unitPriceTextMatch[0];     
    var unitPrice = unitPriceText.replace(/[.|,]/g,'');
    var quantity = parseInt(jQuery('#Quantity').val());
      var totalPrice = unitPrice * quantity;

      var totalPriceHtml = formatNumber(totalPrice, '.', ',');
    //var totalPriceText = Shopify.formatMoney(totalPrice, window.money_format);
    //regex = /([0-9]+[.|,][0-9]+[.|,][0-9]+)/g;     
    //if (!totalPriceText.match(regex)) {
    //  regex = /([0-9]+[.|,][0-9]+)/g;
    //} 
    //totalPriceText = totalPriceText.match(regex)[0];

    //var regInput = new RegExp(unitPriceText, "g"); 
     // var totalPriceHtml = jQuery('.product-single .money').html().replace(regInput, totalPriceText);
     
    $('.total-price .money').html(totalPriceHtml); 

  }
}

function formatNumber(nStr, decSeperate, groupSeperate) {
    nStr += '';
    x = nStr.split(decSeperate);
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
    }
    return x1 + x2;
}


/********************************************************
# QUICKVIEW - ADDTOCART
********************************************************/
gred.quickviewAddToCart = function () {
  if ($('.quickview-product .btn-addToCart').length > 0) {
    $('.quickview-product .btn-addToCart').click(function() {
      var variant_id = $('.quickview-product select[name=id]').val();
      if (!variant_id) {
        variant_id = $('.quickview-product input[name=id]').val();
      }
      var quantity = $('.quickview-product input[name=quantity]').val();
      if (!quantity) {
        quantity = 1;
      }

      var title = $('.quickview-product .product-name a').html();
      var image = $('.quickview-product .featured-image img').attr('src');

      gred.doAjaxAddToCart(variant_id, quantity, title, image);               
    });
  }
}


/********************************************************
# PRODUCT DETAIL - ADDTOCART
********************************************************/
gred.btnAddtocart = function () {
  $(window.btn_addToCart).click(function(event) { 
    event.preventDefault();
    if ($(this).attr('disabled') != 'disabled') {
      var variant_id = $(window.product_detail_form +' select[name=id]').val();
      if (!variant_id) {
        variant_id = $(window.product_detail_form +' input[name=id]').val();
      }
      var quantity = $(window.product_detail_form +' input[name=quantity]').val();
      if (!quantity) {
        quantity = 1;
      }
      var title = $(window.product_detail_name).html();
      var image = $(window.product_detail_mainImg).attr('src');
      gred.doAjaxAddToCart(variant_id, quantity, title, image);
    }
    return false;
  });
}


/********************************************************
# ADD TO CART
********************************************************/
//gred.initAddToCart = function () {
//  $('.product-item .btn-addToCart').click(function(event) {    
//    event.preventDefault();
//    if ($(this).attr('disabled') != 'disabled') {      
//      var productItem = $(this).closest('.product-item');
//      var productId = $(this).closest('.product-item').attr('data-id');      
//      productId = productId.match(/\d+/g);

//      var variant_id = $('#AddToCartForm-' + productId + ' select[name=id]').val();
//      if (!variant_id) {
//        variant_id = $('#AddToCartForm-' + productId + ' input[name=id]').val();
//      }

//      var quantity = $('#AddToCartForm-' + productId + ' input[name=quantity]').val();
//      if (!quantity) {
//        quantity = 1;
//      }

//      var title = $(productItem).find('.product-item-name').html();
//      var image = $(productItem).find('.product-item-photo img').attr('src');
//      gred.doAjaxAddToCart(variant_id, quantity, title, image); 
//    }
//    return false;
//  });
//}

gred.doAjaxAddToCart = function (variant_id, quantity, title, image) { 
  //$.ajax({
  //  type: "post",
  //  url: "/cart/add.js",
  //  data: 'quantity=' + quantity + '&id=' + variant_id, 
  //  dataType: 'json', 
  //  beforeSend: function() {    
  //    if(window.theme_load == "icon"){
  //      gred.showLoading('.btn-addToCart');
  //    } else{
  //      gred.showPopup('.loading'); 
  //    }
  //  },
  //  success: function(msg) {  

  //    gred.hidePopup('.quickview-product');       
  //    if(window.theme_load == "icon"){
  //      gred.hideLoading('.btn-addToCart');
  //    } else{
  //      $('.loading').addClass('loaded-content');         
  //    }

  //    switch (window.addcart_susscess) {
  //      case ('popup'):     
  //        $('.addcart-popup').find('.product-name').html(title);
  //        $('.addcart-popup').find('.product-image img').attr('src', image);

  //        gred.showPopup('.addcart-popup');

  //        break;
  //      case ('text'):
  //        gred.hidePopup('.loading'); 
  //        gred.hideLoading('.btn-addToCart');

  //        break;
  //      case ('noitice'):          
  //        gred.hidePopup('.loading'); 
  //        gred.hideLoading('.btn-addToCart');
  //        $('.product-noitice.susscess').find('.product-name').html(title);
  //        $('.product-noitice.susscess').find('.product-image img').attr('src', image);
  //        gred.showNoitice('.product-noitice.susscess');

  //        break;
  //      default: gred.showPopup('.addcart-popup');

  //    }

  //    gred.updateMiniCart();

  //  },
  //  error: function(xhr, text) {
  //    gred.hidePopup('.loading'); 
  //    $('.error-message').text($.parseJSON(xhr.responseText).description);
  //    gred.showPopup('.error-popup');

  //  }
  //});
}


/********************************************************
# UPDATE MINICART
********************************************************/
gred.updateMiniCart = function() {
  Shopify.getCart(function(cart) {        
    gred.doUpdateMiniCart(cart);
  });
}

/* DO UPDATE MINICART */ 
gred.doUpdateMiniCart = function(cart) {   
  //var template = '<li class="item clearfix" id="cart-item-{id}"><a href="{url}" title="{title}" class="product-image"><img src="{img}" alt="{title}"></a><div class="product-details"><a class="product-name" href="{url}">{title}</a><div class="custom-reviews hide-caption"><span class="shopify-product-reviews-badge" data-id="{product_id}"></span></div><span class="money">{price}</span><span class="qty">'+window.quantity+'{quantity}</span> <a href="javascript:void(0)" title="Remove This Item" class="btn-remove"> <i class="fa fa-trash-o"></i></a></div></li>';
  //$(window.cart_count).text(cart.item_count); 
  //$(window.cart_total).html(Shopify.formatMoney(cart.total_price, window.money_format)); 
  //$('.miniCart-list').html('');

  //if (cart.item_count > 0) {
  //  for (var i = 0; i < cart.items.length; i++) {
  //    var item = template;
  //    item = item.replace(/\{id\}/g, cart.items[i].id);
  //    item = item.replace(/\{url\}/g, cart.items[i].url);
  //    item = item.replace(/\{title\}/g, cart.items[i].title);
  //    item = item.replace(/\{quantity\}/g, cart.items[i].quantity);
  //    item = item.replace(/\{product_id\}/g, cart.items[i].product_id);
  //    item = item.replace(/\{img\}/g, Shopify.resizeImage(cart.items[i].image, 'compact'));
  //    item = item.replace(/\{price\}/g, Shopify.formatMoney(cart.items[i].price, window.money_format));
  //    $('.miniCart-list').append(item);
  //  }
  //  gred.removeItemsInMiniCart();
  //  gred.initReview(); 
  //  gred.ConvertCurrency();
  //  gred.checkItemsInMiniCart();
  //} else{
  //  $('.miniCart-content .summary').remove();
  //  $('.miniCart-content .miniCart-list').remove();    
  //}
}

/* reConvertCurrency */
gred.reConvertCurrency = function() {       
  return window.show_multiple_currencies && Currency.currentCurrency != shopCurrency;  
};

/* REMOVE ITEM CART */
gred.removeItemsInMiniCart = function() { 
  $('.btn-remove').click(function(event) { 
    event.preventDefault();       
    var productId = $(this).parents('.item').attr('id');
    productId = productId.match(/\d+/g);
    Shopify.removeItem(productId, function(cart) {
      gred.doUpdateMiniCart(cart);
    });          
  }); 
};


/* CHECK ITEM MINI CART */
gred.checkItemsInMiniCart = function() {  
  if($('.miniCart-list').children().length > 0) {
    $('.miniCart-content').removeClass('empty-cart');           
  } else{
    $('.miniCart-content').addClass('empty-cart'); 
  }
}

/********************************************************
# WISHLIST
********************************************************/

gred.initWishlist = function() {
  $('.product-item-info .add-to-wishlist').click(function(e) {
    e.preventDefault();
    var form = $(this).closest('form');  
    var productItem = $(this).closest('.product-item-info');

    $.ajax({
      type: 'POST',
      url: '/contact',
      data: form.serialize(),
      beforeSend: function() {
        gred.showPopup('.loading');
      },
      success: function(data) { 
        form.html('');
        var title = $(productItem).find('.product-item-name').html();
        var image = $(productItem).find('.product-item-photo img').attr('src');                             
        $('.wishlist-popup').find('.product-name').html(title);
        $('.wishlist-popup').find('.product-image img').attr('src', image);    
        gred.showPopup('.wishlist-popup');
      },
      error: function(xhr, text) { 
        form.html('');   
        $('.error-message').text($.parseJSON(xhr.responseText).description);
        gred.showPopup('.error-popup');
      }
    });
  });

}


gred.initProductWishlist = function() {
  $('.product-single .add-to-wishlist').click(function(e) {
    e.preventDefault();
    var form = $(this).parent();
    $.ajax({
      type: 'POST',
      url: '/contact',
      data: form.serialize(),
      beforeSend: function() {
        gred.showPopup('.loading'); 
      },
      success: function(data) {        
        form.html('');            
        var title = $('.product-info h1').html();
        var image = $('.product-single-photos img').attr('src');
        $('.wishlist-popup').find('.product-name').html(title);
        $('.wishlist-popup').find('.product-image img').attr('src', image);
        gred.showPopup('.wishlist-popup');
      },
      error: function(xhr, text) {
        gred.hidePopup('.loading');    
        $('.error-message').text($.parseJSON(xhr.responseText).description);
        gred.showPopup('.error-popup');  
      }
    });
  }); 
}

/* Remove Wishlist */ 
gred.initRemoveWishlist = function() {
  $('.btn-remove-wishlist').click(function(e) {
    e.preventDefault();
    var row = $(this).parents('tr');
    var tagID = row.find('.tag-id').val();
    var form = jQuery('#remove-wishlist-form');
    form.find("input[name='contact[tags]']").val('x' + tagID);
    $.ajax({
      type: 'POST',
      url: '/contact',
      data: form.serialize(),
      beforeSend: function() {
        gred.showPopup('.loading'); 

      },
      success: function(data) {
        row.fadeOut(500);
        gred.hidePopup('.loading');  
      },
      error: function(xhr, text) {
        $('.error-message').text($.parseJSON(xhr.responseText).description);
        gred.showPopup('.error-popup');
      }
    });
  });
}

/* Review */
gred.initReview = function() {
  if ($(".spr-badge").length > 0) {
    return window.SPR.registerCallbacks(), window.SPR.initRatingHandler(), window.SPR.initDomEls(), window.SPR.loadProducts(), window.SPR.loadBadges();
  };
}


/* ConvertCurrency */
gred.ConvertCurrency = function() {
  if (gred.reConvertCurrency() && window.show_multiple_currencies ) {
    Currency.convertAll(window.shop_currency, jQuery('.currency-picker').val(), 'span.money', 'money_format' ); 
                        }
                        }


$(gred.init)

    function addtocart ( t,isItem =  false) {
        $(".error-popup ").addClass("active");
        var jsonordercar = localStorage.getItem("orderCar");
        var quantity = 1;
        if (isItem) {
            quantity =  $("#Quantity").val();
        }
        var productId = $(t).attr("data-productid");
        var url = $(t).attr("data-url");
        var price = $(t).attr("data-price");
        var pricesale = $(t).attr("data-pricesale");
        var urlimg = $(t).attr("data-urlimg");
        var name = $(t).attr("data-name");
        if (jsonordercar === null) {
            var arrorder = [];
            var obj = {
                quantity: quantity,
                productId: productId,
                price: price,
                pricesale: pricesale,
                urlimg: urlimg,
                url: url,
                name : name
            }
            arrorder.push(obj);
            var json = JSON.stringify(arrorder);
            localStorage.setItem("orderCar", json);
        }
        else {
            var ordercart = jQuery.parseJSON(jsonordercar);
            var result = ordercart.find(fruit => fruit.productId == parseInt(productId));
            if (result === null || result === undefined) {
                var obj = {
                    quantity: quantity,
                    productId: productId,
                    price: price,
                    pricesale: pricesale,
                    urlimg: urlimg,
                    url: url,
                    name: name
                }
                ordercart.push(obj);
            }
            else {
                result.quantity = parseInt(result.quantity) + parseInt(quantity);
               
            }
            var json = JSON.stringify(ordercart);
            localStorage.setItem("orderCar", json);
        }
        sumcart();
        setTimeout(function () {
            $(".error-popup ").removeClass("active");
        }, 1500);
    }

function sumcart() {
    var jsonordercar = localStorage.getItem("orderCar");
    if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined") {
        var ordercart = jQuery.parseJSON(jsonordercar);
        var total = 0;
        var pricetotal = 0;
        var htmlminicart = '';
        $.each(ordercart, function (item) {
            var objiteam = ordercart[item];
            total += parseInt(objiteam.quantity);
            var priceshow = 0;
            if (parseInt(objiteam.pricesale) > 0) {
                pricetotal += (parseInt(objiteam.pricesale) * parseInt(objiteam.quantity));
                priceshow = parseInt(objiteam.pricesale);
            }
            else {
                pricetotal +=( parseInt(objiteam.price) * parseInt(objiteam.quantity) );
                priceshow = parseInt(objiteam.price);
            }
            var myvar = '<li class="item clearfix" id="cart-item-' + objiteam.productId + '">' +
                '                                   <a href="' + objiteam.url + '" class="product-image">' +
                '                                        <img src="' + objiteam.urlimg +'" alt="'+ +'">' +
                '                                    </a>' +
                '                                    <div class="product-details">' +
                '                                        <a class="product-name" href="' + objiteam.url + '">' +  objiteam.name + 
                '                                        </a>' +
                '                                        <div class="custom-reviews hide-caption">' +
                '                                            <span class="shopify-product-reviews-badge" data-id="' + objiteam.productId +'"></span>' +
                '                                        </div>' +
                '                                        <span class=""> <span class="money" >' + formatNumber(priceshow, '.', ',') +'</span></span>' +
                '                                        <span class="qty"> x <span>' + objiteam.quantity + '</span></span>' +
                '                                        <a href="javascript:void(0)" onclick="deleteCart(this)" data-productid="'+ objiteam.productId  +'" title="remove" class="btn-remove"><i class="fa fa-trash-o"></i></a>' +
                '                                    </div>' +
                '                                </li>';
            htmlminicart += myvar;

        });
        $(".miniCart-list").html(htmlminicart);
        $(".cart-count").html(total);
        $(".cart-total .money").html(formatNumber(pricetotal, '.', ','));
    }
}

function deleteCart(t) {
    var productId = $(t).attr("data-productid");
    $("#cart-item-" + productId).remove();
    var jsonordercar = localStorage.getItem("orderCar");
    if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined") {
        var ordercart = jQuery.parseJSON(jsonordercar);
        ordercart = ordercart.filter(function (el) { return el.productId != parseInt(productId); });
        var json = JSON.stringify(ordercart);
        localStorage.setItem("orderCar", json);
        sumcart();
    }
}


