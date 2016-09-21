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

var sSelected = 'blei';

$('.tabs-buttons > li > button').click(function (oEvent) {
    var oTabPages = $('.tabs-content')[0],
        oTextOld = $('#' + sSelected + 'text')[0],
        oSelectedText = $('#' + oEvent.target.id.substring(0, 4) + 'text')[0];

    $(oTabPages).removeClass(sSelected);
    $(oTextOld).addClass('hidden');
    $(oTextOld).removeClass('selectedText');

    sSelected = oEvent.target.id.substring(0, 4);

    $(oTabPages).addClass(sSelected);
    $(oSelectedText).addClass('selectedText');
    $(oSelectedText).removeClass('hidden');

});