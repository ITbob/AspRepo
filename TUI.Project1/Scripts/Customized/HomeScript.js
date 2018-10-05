
$(function () {
    $('#DepartureAirport').bind('input', function () {
        fetchAirport('DepartureAirport', "#departure");
    });

    $('#ArrivalAirport').bind('input', function () {
        fetchAirport('ArrivalAirport', "#arrival");
    });
});



function fetchAirport(inputId, datalistId) {
    var info = document.getElementById(inputId).value;//'DepartureAirport' ,'ArrivalAirport'
    $.ajax({
        url: UrlSettings.AirportsUrl,//'@Url.Action("GetAirports","HomeController")',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{value:"' + info + '"}',
        success: function (result) {
            //alert(result.length + " " + $("#destination").length - 1);
            if (result.length === $(datalistId).length) {//"#arrival"
                return;
            }

            $(datalistId).empty();//"#arrival", '#departure'

            $.each(result, function (i, item) {
                var val = item.Name;
                var text = val + " [" + item.City + ']';
                $(datalistId).append($("<option>").attr('value', val).text(text));//"#arrival"
            });
        },
        error: function () {
            alert('error');
        }
    });
}
