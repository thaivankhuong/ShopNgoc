jQuery(document).ready(function () {
    CheckShowCart();
});

function CheckShowCart() {
    var jsonordercar = localStorage.getItem("orderCar");
    if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined" && jsonordercar != [] && jsonordercar != "[]") {
        $("#noneproduct").hide();
        $("#showproductcart").show();

        var ordercart = jQuery.parseJSON(jsonordercar);
        var total = 0;
        var pricetotal = 0;
        var htmlcart = '';

        $.each(ordercart, function (item) {
            var objiteam = ordercart[item];
            total += parseInt(objiteam.quantity);
            var total_quantity = 0;
            var priceshow = 0;
            if (parseInt(objiteam.pricesale) > 0) {
                pricetotal += parseInt(objiteam.pricesale);
                priceshow = parseInt(objiteam.pricesale);
                total_quantity = parseInt(objiteam.pricesale) * parseInt(objiteam.quantity);
            }
            else {
                pricetotal += parseInt(objiteam.price);
                priceshow = parseInt(objiteam.price);
                total_quantity = parseInt(objiteam.price) * parseInt(objiteam.quantity);
            }
            var myvar = '<tr class="product-item">' +
                '                        <td class="a-center">' +
                '                            <a class="removeitemcart" data-productid="' + objiteam.productId + '"    href="javascript:void(0)">' +
                '                                <i class="fa fa-trash-o"></i>' +
                '                            </a>' +
                '                        </td>' +
                '                        <td>' +
                '                            <a href="' + objiteam.url + '" class="cart-image">' +
                '                                <img class="product-image-cart" src="' + objiteam.urlimg + '" alt="' + objiteam.name + '">' +
                '                            </a>' +
                '                        </td>' +
                '                        <td>' +
                '                            <a href="' + objiteam.url + '" class="product-name">' + objiteam.name + ' - ' + objiteam.sizename + ' / ' + objiteam.colorname +
                '                            </a>' +
                '                        </td>' +
                '                        <td>' +
                '                            <span class="money" >' + formatNumber(priceshow, '.', ',') + '</span>' +
                '                        </td>' +
                '                        <td>' +
                '                            <div class="product-single-quantity">' +
                '                                <div class="quantity">' +
                '                                    <span class="qtyminus qtyminuscart" data-price="' + priceshow + '"  data-productid="' + objiteam.productId + '"><i class="fa fa-angle-down"></i></span>' +
                '                                    <input type="text" id="Quantity' + objiteam.productId + '" data-field="quantity" name="quantity' + objiteam.productId + '" value="' + objiteam.quantity + '" class="quantity-selector">' +
                '                                    <span class="qtyplus qtypluscart" data-price="' + priceshow + '" data-productid="' + objiteam.productId + '" data-field="quantity1"><i class="fa fa-angle-up"></i></span>' +
                '                                </div>' +
                '                            </div>' +
                '                        </td>' +
                '                        <td>' +
                '                            <span>' +
                '                                <span class="money money-item" id="money-' + objiteam.productId + '">' + formatNumber(total_quantity, '.', ',') + '</span>' +
                '                            </span>' +
                '                        </td>' +
                '                    </tr>';

            htmlcart += myvar;
        });
        $("#tbodyproducrcart").html(htmlcart);
        InitQuantityplus();
    }
    else {
        $("#noneproduct").show();
        $("#showproductcart").hide();

    }
}
function InitQuantityplus() {
    $(".qtypluscart").click(function () {
        var productid = $(this).attr("data-productid");

        var quantity = $("#Quantity" + productid).val();
        quantity = parseInt(quantity) + 1;
        $("#Quantity" + productid).val(quantity);
        var price = $(this).attr("data-price");
        var total = parseInt(price) * quantity;
        $("#money-" + productid).html(formatNumber(total, '.', ','));

        var jsonordercar = localStorage.getItem("orderCar");
        if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined") {
            var ordercart = jQuery.parseJSON(jsonordercar);
            var result = ordercart.find(fruit => fruit.productId == parseInt(productid));
            result.quantity = quantity;

            var json = JSON.stringify(ordercart);
            localStorage.setItem("orderCar", json);
            sumcart();
        }
    });

    $(".qtyminuscart").click(function () {
        var productid = $(this).attr("data-productid");
        var quantity = $("#Quantity" + productid).val();
        quantity = parseInt(quantity) - 1;
        if (quantity <= 1) {
            quantity = 1;
        }
        $("#Quantity" + productid).val(quantity);
        var price = $(this).attr("data-price");
        var total = parseInt(price) * quantity;
        $("#money-" + productid).html(formatNumber(total, '.', ','));

        var jsonordercar = localStorage.getItem("orderCar");
        if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined") {
            var ordercart = jQuery.parseJSON(jsonordercar);
            var result = ordercart.find(fruit => fruit.productId == parseInt(productid));
            result.quantity = quantity;

            var json = JSON.stringify(ordercart);
            localStorage.setItem("orderCar", json);
            sumcart();
        }

    });

    $(".removeitemcart").click(function () {
        var productId = $(this).attr("data-productid");
        $("#cart-item-" + productId).remove();
        var jsonordercar = localStorage.getItem("orderCar");
        if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined") {
            var ordercart = jQuery.parseJSON(jsonordercar);
            ordercart = ordercart.filter(function (el) { return el.productId != parseInt(productId); });
            var json = JSON.stringify(ordercart);
            localStorage.setItem("orderCar", json);
            sumcart();
        }
        $(this).closest(".product-item").remove();
    })
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


//function SubmitCartProduct() {
//    debugger;
//}

$('#form-productsubmit').submit(function (event) {
    $(".loading ").addClass("active");
    event.preventDefault();
    var jsonordercar = localStorage.getItem("orderCar");

    if (jsonordercar !== null && jsonordercar !== undefined && jsonordercar !== "undefined" && jsonordercar != [] && jsonordercar != "[]") {
        var model = {
            Id: 0,
            FullName: $("#fullname").val(),
            Address: $("#address").val(),
            Mobi: $("#phone").val(),
            Email: $("#email").val(),
            Content: $("#CartSpecialInstructions").val(),
            ProductName: jsonordercar
        };
        $.ajax({
            url: "/Contact/OrderCreate/",
            method: 'POST',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            dataType: "text",
            success: function (data) {
                $(".success-popup ").addClass("active");
                setTimeout(function () {
                    $(".success-popup ").removeClass("active");
                    window.location.href = '/';
                }, 2500);
            }
        }).done(function () {
            $(".loading ").removeClass("active");
        })

    }
    else {
        alert("Bạn chưa chọn sản phẩm nào!");
    }
   
})