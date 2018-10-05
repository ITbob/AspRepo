
$(function () {
    $('#DepartureAirport').bind('input', function () {
        fetchAirport('DepartureAirport', "#departure");
    });

    $('#ArrivalAirport').bind('input', function () {
        fetchAirport('ArrivalAirport', "#arrival");
    });
});



function fetchAirport(inputId, datalistId) {
    var info = document.getElementById(inputId).value;
    $.ajax({
        url: UrlSettings.AirportsUrl,//'@Url.Action("GetAirports","HomeController")',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{value:"' + info + '"}',
        success: function (result) {
            if (result.length === $(datalistId).length) {
                return;
            }

            $(datalistId).empty();

            $.each(result, function (i, item) {
                var val = item.Name;
                var text = val + " [" + item.City + ']';
                $(datalistId).append($("<option>").attr('value', val).text(text));
            });
        },
        error: function () {
            alert('Sorry, an unexpected error happened.');
        }
    });
}
