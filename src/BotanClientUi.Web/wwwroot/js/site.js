// Write your Javascript code.
(function () {
    var divRes = $('#divRes');

    var txtEventName = $('#eventName');
    var txtUserId = $('#userId');
    var txtRawData = $('#rawData');
    var btnTrackEvent = $('#btnTrackEvent');

    var txtUrlUserId = $('#urlUserId');
    var txtUrl = $('#url');
    var btnShortenUrl = $('#btnShortenUrl');

    btnTrackEvent.click(function () {
        $.post('/api/Botan/Event', {
            eventName: txtEventName.val(),
            uid: txtUserId.val(),
            rawData: txtRawData.val()
        }).then(function (res) {
            divRes.text(divRes.text() + '\n' + `EVENT > ${JSON.stringify(res)}`);
        });
    });

    btnShortenUrl.click(function () {
        var encodedUrl = encodeURIComponent(txtUrl.val());
        $.get(`/api/Botan/Url/${encodedUrl}/${txtUrlUserId.val()}`)
            .then(function (res) {
                divRes.text(divRes.text() + '\n' + ` URL > ${JSON.stringify(res)}`);
            });
    });
})();