function fetchAvailableDeparture() {
    var info = document.getElementById('departureName').value;
    $.ajax({
        url: UrlSettings.AirportsUrl,//'@Url.Action("GetAirports","HomeController")',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{value:"' + info + '"}',
        success: function (result) {
            if (result.length === $("#departure").length) {
                return;
            }
            $("#departure").empty();

            for (var i = 0; i < result.length; i++) {
                if (result[i].City !== null) {
                    $("#departure").append('<option value="'
                        + result[i].Name
                        + '">' +
                        result[i].City + '</option>');
                }
                else {
                    $("#departure").append('<option value="'
                        + result[i].Name
                        + '"></option>');
                }
            }
        },
        error: function () {
            alert('error');
        }
    });
}


function fetchAvailableArrival() {
    var info = document.getElementById('arrivalName').value;
    $.ajax({
        url: UrlSettings.AirportsUrl,//'@Url.Action("GetAirports","HomeController")',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{value:"' + info + '"}',
        success: function (result) {
            //alert(result.length + " " + $("#destination").length - 1);


            if (result.length === $("#arrival").length) {
                return;
            }
            $("#arrival").empty();

            for (var i = 0; i < result.length; i++) {
                if (result[i].City !== null) {
                    $("#arrival").append('<option value="'
                        + result[i].Name
                        + '">' +
                        result[i].City + '</option>');
                }
                else {
                    $("#arrival").append('<option value="'
                        + result[i].Name
                        + '"></option>');
                }
            }
        },
        error: function () {
            alert('error');
        }
    });
}
