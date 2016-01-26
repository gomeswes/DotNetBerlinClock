$(document).ready(function () {
    var date = new Date();
    var time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
    var $timeInput = $("#timeInput");
    $timeInput.mask("00:00:00");
    berlinClock.init(time, $("#btnChangeTime"), $timeInput);
});

var berlinClock = (function () {
    var exports = {};
    var lightsStates = {
        yellow: "Y",
        red: "R",
        off: "O"
    };
    var lightsClasses = {
        yellow: "yellow-light",
        red: "red-light",
        off: "off-light"
    };
    exports.init = function (timeParam, $btnChangeTime, $timeInput) {
        applyTime(timeParam);
        $btnChangeTime.unbind('click');
        $timeInput.bind('keypress', function (evt) {
            if (evt.charCode == 13) {
                toChangeClockTime();
            }
        });
        $btnChangeTime.bind('click', toChangeClockTime);
    };

    var applyTime = function (timeParam) {
        doQueryForTime(timeParam)
        .done(drawTime)
        .fail(informError);
    };

    var toChangeClockTime = function () {
        var time = $("#timeInput").val();
        applyTime(time);
    };

    var doQueryForTime = function (time) {
        var $deferred = $.Deferred();
        $.ajax({
            url: "/api/BerlinClock?time=" + time,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                $deferred.resolve(data);
            }
        });
        return $deferred;
    };


    var drawTime = function (result) {
        var rows = result.split('\n');
        if (checkDataIntegrity(rows)) {
            informError(result);
            return;
        }
        var $topRowLight = $('#topRow').find('span');
        drawRow(rows[0][0], $topRowLight);

        var $firstRowLights = $('#firstRow').find('span');
        drawRow(rows[1], $firstRowLights);

        var $secondRowLights = $('#secondRow').find('span');
        drawRow(rows[2], $secondRowLights);

        var $thirdRowLights = $('#thirdRow').find('span');
        drawRow(rows[3], $thirdRowLights);

        var $fourthRowLights = $('#fourthRow').find('span');
        drawRow(rows[4], $fourthRowLights);
    };

    var checkDataIntegrity = function (dataToCheck) {
        return dataToCheck.length != 5;
    };
    var drawRow = function (rowState, $rowLights) {
        turnLightsOff($rowLights);
        for (var i = 0; i < rowState.length; i++) {
            var currentLightState = rowState[i];
            var $currentLightElement = $rowLights.eq(i);

            if (currentLightState == lightsStates.red) {
                $currentLightElement.addClass(lightsClasses.red);
            }
            else if (currentLightState == lightsStates.yellow) {
                $currentLightElement.addClass(lightsClasses.yellow);
            }
            else {
                $currentLightElement.addClass(lightsClasses.off);
            }
        }
    };

    var turnLightsOff = function ($lights) {
        $lights.removeClass(lightsClasses.yellow)
                .removeClass(lightsClasses.red)
                .removeClass(lightsClasses.off);
    };

    var informError = function (error) {
        $.growl.error({ title: "Ops!", message: error });
    };

    return exports;
})();