var oWrapper = $('.galery-wrapper')[0],
    oGalery = $('.galery')[0],
    oImages = $('.galery > ul > li > img');

function getPreviousPos() {
    var pos,
        left,
        margin;

    for (var i = 0; i < oImages.length; i++) {
        if (!left) {
            if (($(oImages[i]).offset().left - $(oGalery).offset().left) >= 0) {
                //komplett sichtbar
                left = -oGalery.clientWidth;
                i = -1;
            } else if (Math.abs($(oImages[i]).offset().left - $(oGalery).offset().left) < oImages[i].width) {
                left = $(oImages[i < oImages.length ? i + 1 : i]).offset().left - $(oGalery).offset().left - oGalery.clientWidth;
                i = -1;
            }
        } else if (($(oImages[i]).offset().left - $(oGalery).offset().left) >= left) {
            break;
        }
    }

    if (i == oImages.length) {
        return;
    }

    if (document.defaultView && document.defaultView.getComputedStyle) {
        margin = parseInt(document.defaultView.getComputedStyle(oImages[i].parentElement, "").getPropertyValue("margin-Left"));
    }

    pos = $(oImages[i]).offset().left - $(oGalery).offset().left;
    pos -= margin;
    pos = oGalery.scrollLeft + pos;
    return pos > 0 ? pos : 0;
}

function getNextPos() {
    var margin = 0,
        right,
        left;


    for (var i = 0; i < oImages.length; i++) {
        left = $(oImages[i]).offset().left - $(oGalery).offset().left;
        right = left + oImages[i].width;
        if (right > oGalery.clientWidth) {
            break;
        }
    }
    if (i == oImages.length) {
        return;
    }

    if (document.defaultView && document.defaultView.getComputedStyle) {
        margin = parseInt(document.defaultView.getComputedStyle(oImages[i].parentElement, "").getPropertyValue("margin-Left"));
    }

    return oGalery.scrollLeft + left - margin;
}

if (getNextPos()) {
    $('#next').show();
    $('#previous').hide();
}

$('#next').click(function (oEvent) {
    var pos = getNextPos();

    if (!pos) {
        return;
    }
    $(oGalery).animate({
        scrollLeft: pos
    },
    'slow',
    function () {
        if (!getNextPos()) {
            $('#next').hide();
        }
        $('#previous').show();
    });
});

$('#previous').click(function (oEvent) {
    var pos = getPreviousPos();

    if (pos == oGalery.scrollLeft) {
        return;
    }

    $(oGalery).animate({
        scrollLeft: pos
    },
                'slow',
                function () {
                    if (!oGalery.scrollLeft) {
                        $('#previous').hide();
                    }
                    $('#next').show();
                });
});
function getBrowserSize() {
    return {
        width: document.documentElement.clientWidth,
        height: document.documentElement.clientHeight
    };
}
/*
$('.galery > ul > li > img').hover(function (event) {
    var screenSize = getBrowserSize(),
        targetPosition = {},
        availableSpace = {},
        size = {};

    availableSpace.top = event.target.y - (event.pageY - event.clientY);
    //availableSpace.left = event.target.x - (event.pageX - event.clientX);
    //availableSpace.right = screenSize.width - availableSpace.left - event.target.width;
    availableSpace.bottom = screenSize.height - availableSpace.top - event.target.height;

    size.height = availableSpace.top > availableSpace.bottom ? availableSpace.top : availableSpace.bottom;
    size.factorImage = 1.0 * event.target.width / event.target.height;

    targetPosition.top = event.pageY - event.clientY;//go into screen 
    targetPosition.top += availableSpace.top > availableSpace.bottom ? 0 : availableSpace.top + event.target.height;
    if (size.height > event.target.naturalHeight && availableSpace.top > availableSpace.bottom) {
        targetPosition.top += size.height - event.target.naturalHeight;
    }

    $('#preview-img').attr({
        src: event.target.src,
        alt: event.target.alt
    });

    $('#preview').removeClass('hidden');
    $('#preview').show();

    $('#preview').width();
    $('#preview').height(size.height > event.target.naturalHeight ? event.target.naturalHeight : size.height);

    $('#preview').offset({
        top: targetPosition.top
    });

}, function (event) {
    $('#preview').hide();
});*/

var sSelected = 'blei';

$('.tabs-buttons > li > button').click(function (oEvent) {
    var oTabPages = $('.tabs-content')[0],
        oTextOld = $('#' + sSelected)[0],
        oSelectedText = $('#' + oEvent.target.id.substring(0, 4))[0];

    //$(oTabPages).removeClass(sSelected);
    $(oTextOld).addClass('hidden');
    //$(oTextOld).removeClass('selectedText');

    $('#' + sSelected + 'btn1').removeClass('active');
    $('#' + sSelected + 'btn2').removeClass('active');
    $('#' + sSelected + 'btn3').removeClass('active');
    sSelected = oEvent.target.id.substring(0, 4);
    $(oEvent.target).addClass('active');

    //$(oTabPages).addClass(sSelected);
    //$(oSelectedText).addClass('selectedText');
    $(oSelectedText).removeClass('hidden');

});