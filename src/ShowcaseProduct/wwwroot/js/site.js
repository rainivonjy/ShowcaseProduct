// Write your Javascript code.
$(document).ready(function () {
    /*------------All variable global------------*/

    var requestShop = new Object();

    /*------------End All variable global------------*/
    /*-----------------All Event  Change--------------------------*/
    $(document).on('change', '#viewProduct', function () {
        requestShop.NbShow = $("#viewProduct").val();
        getProductShop(requestShop);
    });
    /*-----------------End All Event  Change--------------------------*/
    /*-----------------All Event  Click--------------------------*/
    $(document).on('click', '#idbtDiscountShop', function () {
        requestShop.IsDiscount = true;
        requestShop.IsNewest = false;
        getProductShop(requestShop);
    });
    $(document).on('click', '#idbtNewShop', function () {
        requestShop.IsNewest = true;
        requestShop.IsDiscount = false;
        getProductShop(requestShop);
    });
    /*-----------------End All Event  Click--------------------------*/
    /****************************Page Shop***********************/
    /*-------------Get Product for Shop------------------*/
    
    function getProductShop(requestShop) {
        $.ajax({
            contentType: 'application/json',
            type: "POST",
            url: "api/WebServiceApplication/GetShopProducts",
            data: JSON.stringify({ "Id": "5" }),
            success: function (data, textStatus, jqXHR) {
              //  console.log(data);
                //console.log(data.error);
                var contentHtml = CreateStringHtmlContentProduct(data);
                console.log(contentHtml);
                $("#list-shop").append(contentHtml);
            },
            error: function (jqXHR, textStatus, errorThrown) {
            }
        });
    }
    
    /*-------------End Get Product for Shop------------------*/
    /*---------------Create string html for Content product----------*/
    function CreateStringHtmlContentProduct(data) {
        var contentHtml = '';
        if (!data.error.message) {
            data.listProducts.forEach(function (element) {
                contentHtml +=CreateHtmlProduct(element.image, element.nom, element.prixUniraire);
            });
        }
        return contentHtml;
    }
    /*-----------Create Html Product-------------*/
    function CreateHtmlProduct(pathImg, title, price) {
        var FormatHtml =  '<div class="col-12 col-sm-6 col-md-12 col-xl-6">' +
                    '<div class="single-product-wrapper">'+ 
                        '<!-- Product Image -->' +
                        '<div class="product-img">'  +
                        '<img src="' + pathImg + '" alt="">'+
                            '<!-- Hover Thumb -->'+
                            '<img class="hover-img" src="' + pathImg + '" alt="">'+
                        '</div>'+

                        '<!-- Product Description -->'+
                        '<div class="product-description d-flex align-items-center justify-content-between">'+
                            '<!-- Product Meta Data -->'+
                            '<div class="product-meta-data">'+
                                '<div class="line"></div>'+
                                '<p class="product-price">$' + price + '</p>'+
                                 '<a href="product-details.html">'+
                                 '<h6>' + title + '</h6>'+
                                '</a>'+
                            '</div>'+
                            '<!-- Ratings & Cart -->'+
                            '<div class="ratings-cart text-right">'+
                                '<div class="ratings">'+
                                    '<i class="fa fa-star" aria-hidden="true"></i>'+
                                    '<i class="fa fa-star" aria-hidden="true"></i>'+
                                    '<i class="fa fa-star" aria-hidden="true"></i>'+
                                    '<i class="fa fa-star" aria-hidden="true"></i>'+
                                    '<i class="fa fa-star" aria-hidden="true"></i>'+
                                '</div>'+
                                '<div class="cart">'+
                                    '<a href="cart.html" data-toggle="tooltip" data-placement="left" title="Add to Cart"><img src="img/core-img/cart.png" alt=""></a>'+
                                '</div>'+
                            '</div>'+
                        '</div>'+
                    '</div>'+
                    '</div>';
                    return FormatHtml;
    }
    /*-----------End Create Html Product-------------*/
    /************Call All function**********/
    requestShop.NbShow = 1;
    requestShop.Pagination = 1;
    requestShop.Total = 1;
    requestShop.IsDiscount = 1;
    requestShop.IsNewest = 1;
    requestShop.IsFirstRequest = 1;
    requestShop.CurrentPagination = 1;
    requestShop.CurrentTotal = 1;
    getProductShop(requestShop);
    /************End Call All function**********/
    /****************************End Page Shop***********************/
});