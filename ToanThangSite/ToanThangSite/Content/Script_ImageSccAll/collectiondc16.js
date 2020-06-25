(function($) {  

  $(document).ready(function() {
    collection.init();
    
    	$('#productSelect-option-1').change(function(){
  			location.reload();
  	
  		});
    
  }); 
	
  
  if ($(".collection-sidebar")) {
    History.Adapter.bind(window, 'statechange', function() {
      var State = History.getState();
      if (!collection.fillterClick) {        
        collection.filterParams();
        var newurl = collection.filterCreateUrl();
        collection.filterGetContent(newurl);
        collection.resetFilter();
      }
      collection.fillterClick = false;
    });
  }
	

  var collection = { 
    init: function() {

      /* Collection Filter */
      this.initCollectionFilter();

      /* Collection Sorting */
      this.initCollectionSorting();

      /* Collection Show */
      this.initCollectionShow();

      /* Collection ViewMode */     
      this.initCollectionViewMode();

      /* Paging */
    //  this.initPaging();
      
      this.clearfix();

    },


    /* --------------------------------------------------------- */
    /* Review */
    initReview: function() {
      if (window.review){
        if ($(".spr-badge").length > 0) {
          return window.SPR.registerCallbacks(), window.SPR.initRatingHandler(), window.SPR.initDomEls(), window.SPR.loadProducts(), window.SPR.loadBadges();
        };
      }
    },

    /* Hide Dropdown */
    initToggle: function(){
      $('.caret').click(function() {        
        $(this).parent().next().toggleClass('active');        
        return false; 
      }); 

      $(".block-category .sub-menu > li").each( function(){
        if($(this).hasClass('active')){
          $(this).parent().addClass('active');
        }
      });

      $('.dropdown-toggle').click(function() {
        $('.dropdown-content').removeClass('active');
        $(this).next().toggleClass('active');    
        return false;              
      });   
    },

    /* --------------------------------------------------------- */
    /* Categories Fillter */

    filterCategories: function() {
      $(".block-category.ajax a").click(function(e) {
        if (!$(this).hasClass('active')) {
          delete Shopify.queryParams.q;
          collection.filterAjaxClick($(this).attr('href'));
          $(".block-category.ajax a.active").removeClass("active");
          $(this).addClass("active");
        }
        e.preventDefault();
      });
    },

    fillterTagEvents: function() {
      $('.filter-tag a:not(".clear"), .filter-tag label').click(function(e) {           
        var currentTags = [];
        if (Shopify.queryParams.constraint) {
          currentTags = Shopify.queryParams.constraint.split('+');     
        }  

        if (!window.filter_mul_choice && !$(this).prev().is(":checked")) {  
          var otherTag = $(this).parents('.filter-tag').find("input:checked");
          if (otherTag.length > 0) {
            var tagName = otherTag.val();
            if (tagName) {
              var tagPos = currentTags.indexOf(tagName);
              if (tagPos >= 0) {           
                currentTags.splice(tagPos, 1);
              }
            }
          }          
        }

        var tagName = $(this).prev().val();
        if (tagName) {
          var tagPos = currentTags.indexOf(tagName);
          if (tagPos >= 0) {            
            currentTags.splice(tagPos, 1);
          } else {
            currentTags.push(tagName);
          }
        }
        if (currentTags.length) {
          Shopify.queryParams.constraint = currentTags.join('+');
        } else {
          delete Shopify.queryParams.constraint;
        }
        collection.filterAjaxClick();
        e.preventDefault();
      });
    },

    filterMapClearAll: function() {
      //clear all selection
      $('.refined-widgets a.clear-all').click(function(e) {
        delete Shopify.queryParams.constraint;
        delete Shopify.queryParams.q;
        collection.filterAjaxClick();
        e.preventDefault();
      });
    },

    filterMapClear: function() {
      $(".filter-tag").each(function() {
        var filterTag = $(this);
        if (filterTag.find("input:checked").length > 0) {
          //has active tag
          filterTag.find(".clear").show().click(function(e) {    
            var currentTags = [];
            if (Shopify.queryParams.constraint) {
              currentTags = Shopify.queryParams.constraint.split('+');
            }
            filterTag.find("input:checked").each(function() {
              var selectedTag = $(this);
              var tagName = selectedTag.val();
              if (tagName) {
                var tagPos = currentTags.indexOf(tagName);
                if (tagPos >= 0) {
                  //remove tag
                  currentTags.splice(tagPos, 1);
                }
              }
            });
            if (currentTags.length) {
              Shopify.queryParams.constraint = currentTags.join('+');
            } else {
              delete Shopify.queryParams.constraint;
            }
            collection.filterAjaxClick();
            e.preventDefault();
          });
        }
      });
    }, 

    filterParams: function() {
      Shopify.queryParams = {};
      if (location.search.length) {
        for (var aKeyValue, i = 0, aCouples = location.search.substr(1).split('&'); i < aCouples.length; i++) {
          aKeyValue = aCouples[i].split('=');
          if (aKeyValue.length > 1) {
            Shopify.queryParams[decodeURIComponent(aKeyValue[0])] = decodeURIComponent(aKeyValue[1]);
          }
        }
      }
    },    

    filterMapEvents: function() {
      collection.fillterTagEvents();
      collection.filterCategories();
    },

    resetFilter: function() {
      $(".filter-custom .active, .filter-links .active").removeClass("active");
      $(".filter-tag input:checked").attr("checked", false);

      //category
      var cat = location.pathname.match(/\/collections\/(.*)(\?)?/);
      if (cat && cat[1]) {
        $(".filter-links a[href='" + cat[0] + "']").addClass("active");
      }
    },

    filterMapData: function(data) {
      var currentList = $(".collection-grid");
      if (currentList.length == 0) {
        currentList = $(".collection-list");
      }

      var productList = $(data).find(".collection-grid");
      if (productList.length == 0) {
        productList = $(data).find(".collection-list");
      }
      if (productList.length > 0 && productList.hasClass("products-grid")) {
        if (window.product_image_resize) {
          productList.find('img').fakecrop({
            fill: window.images_size.is_crop,
            widthSelector: ".products-grid .grid-item .product-image",
            ratioWrapper: window.images_size
          });
        }
      }
      currentList.replaceWith(productList);


      //replace paging
      if ($(".pagination").length > 0) {
        $(".pagination").replaceWith($(data).find(".pagination"));
      }

      //replate sidebar
      $(".filter-block").replaceWith($(data).find(".filter-block"))

      //replace view count
      if ($(".view-count").length > 0) {
        $(".view-count").replaceWith($(data).find(".view-count"));
      }

      //replace title & description
      var currentHeader = $(".collection-info");
      var dataHeader = $(data).find(".collection-info");

      if (currentHeader.find("h3").text() != dataHeader.find("h3").text()) {
        currentHeader.find("h3").replaceWith(dataHeader.find("h3"));
        if (currentHeader.find(".c-des").length) {
          if (dataHeader.find(".c-des").length) {
            currentHeader.find(".c-des").replaceWith(dataHeader.find(".c-des"));
          }
        }

      }


    },

    filterCreateUrl: function(baseLink) {
      var newQuery = $.param(Shopify.queryParams).replace(/%2B/g, '+');
      if (baseLink) {

        if (newQuery != "")
          return baseLink + "?" + newQuery;
        else
          return baseLink;
      }
      return location.pathname + "?" + newQuery;
    },       

    filterAjaxClick: function(baseLink) {
      delete Shopify.queryParams.page;  
      var newurl = collection.filterCreateUrl(baseLink);
      collection.fillterClick = true;
      History.pushState({
        param: Shopify.queryParams  
      }, newurl, newurl);
      collection.filterGetContent(newurl);         
    },        

    filterGetContent: function(newurl) {

      $.ajax({
        type: 'get',
        url: newurl, 
        beforeSend: function() {    
          gred.showPopup('.loading'); 
        },

        success: function(data) {
          collection.filterMapData(data);           

          collection.filterMapClear();
          collection.filterMapClearAll();     

          collection.filterMapEvents(); 
          collection.initReview(); 

        //  collection.initPaging();
          collection.initToggle();
          gred.ConvertCurrency();
          
          gred.quickView();
          gred.initWishlist();
          gred.initAddToCart();
          gred.hidePopup('.loading'); 

        }, 

        error: function(xhr, text) {
          gred.hidePopup('.loading')
          $('.ajax-error-message').text($.parseJSON(xhr.responseText).description);
          gred.showPopup('.ajax-error-modal');
        }

      });
    },

    initCollectionFilter: function() {
      if ($(".collection-sidebar").length > 0) {
        collection.filterParams();
        collection.filterMapEvents();
        collection.filterMapClear();
        collection.filterMapClearAll();
      }
    },

    /* --------------------------------------------------------- */
    /* Collection Sorting */
    initCollectionSorting: function(e) {
      $(".collection-sortBy li a").click(function(e) {
        e.preventDefault();     
        if (!$(this).parent().hasClass("active")) {   
          Shopify.queryParams.sort_by = $(this).attr("href");
          collection.filterAjaxClick();          

          $(".collection-sortBy li.active").removeClass("active");
          $(this).parent().addClass("active");
        }    
        var selected = $(this).text();   
        $(this).closest('.dropdown-toggle').find('.dropdown-label').text(selected);
        $(this).closest('.dropdown-content').removeClass('active');  

      });
    },


    /* --------------------------------------------------------- */
    /* Collection View Mode */
    initCollectionViewMode: function() {
      $(".view-mode a").click(function(e) {
        if (!$(this).hasClass("active")) {
          var paging = $(".collection-show .dropdown-label").text();
          if ($(this).hasClass("list")) {
            Shopify.queryParams.view = "list" + paging;
          } else {
            Shopify.queryParams.view = paging;
          }

          collection.filterAjaxClick();
          $(".view-mode a.active").removeClass("active");
          $(this).addClass("active");
        } else{
          return false;
        }
        e.preventDefault();
      });
    },


    /* --------------------------------------------------------- */
    /* Collection Show */
    initCollectionShow: function() {   
      $(".collection-show li a").click(function(e) {  
        e.preventDefault();
        if (!$(this).parent().hasClass("active")) {
          var currentPage = $(this).attr('href'); 
          var view = $(".view-mode a.active").attr("data-mode");       
          if (view == "list") {
            Shopify.queryParams.view = "list" + currentPage;
          } else {
            Shopify.queryParams.view = currentPage;
          }
          collection.filterAjaxClick();
          $(".collection-show li.active").removeClass("active");
          $(this).parent().addClass("active");
          $(this).closest('.dropdown-toggle').find('.dropdown-label').text(currentPage);
          $(this).closest('.dropdown-content').removeClass('active');  
        }
      });
    },

    /* --------------------------------------------------------- */
    /* Paging */
    //initPaging: function() {
    //  $(".pagination a").click(function(e) {
    //    var page = $(this).attr("href").match(/page=\d+/g); 
    //    if (page) {
    //      Shopify.queryParams.page = parseInt(page[0].match(/\d+/g));
    //      if (Shopify.queryParams.page) {
    //        var newurl = collection.filterCreateUrl();
    //        collection.fillterClick = true;
    //        History.pushState({
    //          param: Shopify.queryParams
    //        }, newurl, newurl);
    //        collection.filterGetContent(newurl);
    //        //go to top
    //        $('body,html').animate({
    //          scrollTop: 0
    //        }, 600);

    //      }
    //    }
    //    e.preventDefault();
    //  });
    //},
	
    clearfix: function(){
    	var ctr = 1;
      	$.each($('.collection-wrapper .collection-wrap'),function(e, i){
      		
          	if( ctr % 3 == 0 ){
              $(i).after('<div class="clr"></div>');
          	}
          	
          ctr++;
      	});
    },
    
  }

  })(jQuery);