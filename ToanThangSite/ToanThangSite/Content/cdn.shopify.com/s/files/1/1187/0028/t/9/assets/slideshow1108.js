jQuery('#rev_slider').show().revolution({
  dottedOverlay: 'none',
  delay: 4000,
  startwidth: 1170,
  startheight: 858,

  hideThumbs:200,
  thumbWidth:100,                            
  thumbHeight:50, 
  thumbAmount:5,

  navigationType:"both",                  
  navigationArrows:"",        
  navigationStyle: 'preview3',             
  touchenabled:"on",                      
  onHoverStop:"on",        

  navOffsetHorizontal:0,
  navOffsetVertical:50,

  swipe_velocity: 0.7, 
  swipe_min_touches: 1,
  swipe_max_touches: 1,
  drag_block_vertical: false,

  spinner: 'spinner2',
  keyboardNavigation: 'on',

  navigationHAlign: 'center',
  navigationVAlign: 'bottom',
  navigationHOffset: 20,
  navigationVOffset: 20,

  soloArrowLeftHalign: '',
  soloArrowLeftValign: '',
  soloArrowLeftHOffset: 0,
  soloArrowLeftVOffset: 0,

  soloArrowRightHalign: '',
  soloArrowRightValign: '',
  soloArrowRightHOffset: 0,
  soloArrowRightVOffset: 0,

  shadow: 0,
  fullWidth: 'on',
  fullScreen: 'off', 

  stopLoop: 'off',
  stopAfterLoops: -1,
  stopAtSlide: -1,

  shuffle: 'off',
  autoHeight: 'on',
  forceFullWidth: 'off',
  hideTimerBar: 'on',

  hideNavDelayOnMobile: 1500,
  hideThumbsOnMobile: 'off',
  hideBulletsOnMobile: 'off',
  hideArrowsOnMobile: 'off',
  hideThumbsUnderResolution: 0,

  hideSliderAtLimit: 0,
  hideCaptionAtLimit: 0,
  hideAllCaptionAtLilmit: 0,
  startWithSlide: 0
});
