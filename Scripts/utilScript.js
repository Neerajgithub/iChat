(function ($) {
    $.fn.popUpBox = function (settings) {
        settings = jQuery.extend({
            overlayBgColor: '#000',
            overlayOpacity: 0.8,
            imageLoading: 'images/loading.gif',
            containerBorderSize: 10,
            containerResizeSpeed: 500,
            containerWidth: 700,
            containerHeight: 700
        }, settings);

        // Caching the jQuery object with all elements matched
        var jQueryMatchedObj = this; // This, in this context, refer to jQuery object

        function _initialize() {
            _start(this, jQueryMatchedObj); // This, in this context, refer to object (link) which the user have clicked
            return false; // Avoid the browser following the link
        }

        function _start(objClicked, jQueryMatchedObj) {
            $('embed, object, select').css({ 'visibility': 'hidden' });
            // Call the function to create the markup structure; style some elements; assign events in some elements.
            //var loadUrl = $(".vidid", objClicked).html();
            var loadUrl = objClicked;

            _set_interface(loadUrl);
        }

        function _set_interface(LUrl) {
            $('body').append('<div id="jquery-overlay" /><div id="jquery-popUpBox"><div id="jquery-rel-box"><span id="jquery-logo"></span><span id="jquery-close"></span><div id="jquery-box"><iframe style="height:100%; width:100%;" scrolling="no" src="' + LUrl + '" frameborder="0" allowfullscreen></iframe></div></div></div>');

            // Get page sizes
            var arrPageSizes = ___getPageSize();
            if (arrayPageSize[1] < (settings.containerHeight + 60)) {
                arrayPageSize[1] = (settings.containerHeight + 60);
            }
            // Style overlay and show it
            $('#jquery-overlay').css({
                backgroundColor: settings.overlayBgColor,
                opacity: settings.overlayOpacity,
                width: arrPageSizes[0],
                height: arrPageSizes[1]
            }).fadeIn();

            $('#jquery-overlay,#jquery-popUpBox').click(function () {
                _finish();
            });

            // Get page scroll
            var arrPageScroll = ___getPageScroll();
            // Calculate top and left offset for the jquery-lightbox div object and show it

            $('#jquery-box,#jquery-rel-box').css({
                width: settings.containerWidth,
                height: settings.containerHeight
            });

            $('#jquery-popUpBox').css({
                top: 30,
                left: arrPageScroll[0],
                height: (settings.containerHeight + 6)
            }).show();

            $('#jquery-close').click(function () {
                _finish();
                return false;
            });
            // If window was resized, calculate the new overlay dimensions
            $(window).resize(function () {
                // Get page sizes
                var arrPageSizes = ___getPageSize();
                // Style overlay and show it
                $('#jquery-overlay').css({
                    width: arrPageSizes[0],
                    height: arrPageSizes[1]
                });
                // Get page scroll
                var arrPageScroll = ___getPageScroll();
                // Calculate top and left offset for the jquery-lightbox div object and show it
                $('#jquery-lightbox').css({
                    top: arrPageScroll[1] + (arrPageSizes[3] / 10),
                    left: arrPageScroll[0]
                });
            });

            // Enable keyboard navigation
            _enable_keyboard_navigation();
        }

        function _enable_keyboard_navigation() {
            $(document).keydown(function (objEvent) {
                _keyboard_action(objEvent);
            });
        }


        function _disable_keyboard_navigation() {
            $(document).unbind();
        }

        function _keyboard_action(objEvent) {
            // To ie
            if (objEvent == null) {
                keycode = event.keyCode;
                //escapeKey = 27;
                // To Mozilla
            } else {
                keycode = objEvent.keyCode;
                //escapeKey = objEvent.DOM_VK_ESCAPE;
            }

            escapeKey = 27;

            // Verify the keys to close the popUpBox
            if (keycode == escapeKey) {
                _finish();
            }
        }

        function _finish() {
            $('#jquery-popUpBox').remove();
            $('#jquery-overlay').fadeOut(function () { $('#jquery-overlay').remove(); });
            // Show some elements to avoid conflict with overlay in IE. These elements appear above the overlay.
            $('embed, object, select').css({ 'visibility': 'visible' });
        }

        function ___getPageSize() {
            var xScroll, yScroll;
            if (window.innerHeight && window.scrollMaxY) {
                xScroll = window.innerWidth + window.scrollMaxX;
                yScroll = window.innerHeight + window.scrollMaxY;
            } else if (document.body.scrollHeight > document.body.offsetHeight) { // all but Explorer Mac
                xScroll = document.body.scrollWidth;
                yScroll = document.body.scrollHeight;
            } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
                xScroll = document.body.offsetWidth;
                yScroll = document.body.offsetHeight;
            }
            var windowWidth, windowHeight;
            if (self.innerHeight) {	// all except Explorer
                if (document.documentElement.clientWidth) {
                    windowWidth = document.documentElement.clientWidth;
                } else {
                    windowWidth = self.innerWidth;
                }
                windowHeight = self.innerHeight;
            } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
                windowWidth = document.documentElement.clientWidth;
                windowHeight = document.documentElement.clientHeight;
            } else if (document.body) { // other Explorers
                windowWidth = document.body.clientWidth;
                windowHeight = document.body.clientHeight;
            }
            // for small pages with total height less then height of the viewport
            if (yScroll < windowHeight) {
                pageHeight = windowHeight;
            } else {
                pageHeight = yScroll;
            }
            // for small pages with total width less then width of the viewport
            if (xScroll < windowWidth) {
                pageWidth = xScroll;
            } else {
                pageWidth = windowWidth;
            }
            arrayPageSize = new Array(pageWidth, pageHeight, windowWidth, windowHeight);
            return arrayPageSize;
        };

        function ___getPageScroll() {
            var xScroll, yScroll;
            if (self.pageYOffset) {
                yScroll = self.pageYOffset;
                xScroll = self.pageXOffset;
            } else if (document.documentElement && document.documentElement.scrollTop) {	 // Explorer 6 Strict
                yScroll = document.documentElement.scrollTop;
                xScroll = document.documentElement.scrollLeft;
            } else if (document.body) {// all other Explorers
                yScroll = document.body.scrollTop;
                xScroll = document.body.scrollLeft;
            }
            arrayPageScroll = new Array(xScroll, yScroll);
            return arrayPageScroll;
        };

        // Return the jQuery object for chaining. The unbind method is used to avoid click conflict when the plugin is called more than once
        return this.unbind('click').click(_initialize);
    };
})(jQuery);