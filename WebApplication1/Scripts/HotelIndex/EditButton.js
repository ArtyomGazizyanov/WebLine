$("#edit_Form").submit(function (event)
{
    event.preventDefault();
    $("#error_box").hide();
    if (isInputValid())
    {
        var hotel =
            {
                HotelId: id,
                Name: $("#Name").val(),
                Address: $("#Address").val(),
                Phone: $("#Phone").val(),
                Email: $("#Email").val(),
                State: $("#State").val()
            };
        console.log("hotel = " + hotel);
        var json = $.getJSON(hotel);
        $.ajax({
            type: "PUT",
            data: JSON.stringify(hotel),
            dataType: "json",
            url: "http://localhost:1329/api/Hotel/",
            contentType: "application/json",
            success: function (data) {
                console.log(data);
                window.location.replace("http://localhost:1329/");

            }
        });

        console.log(data);
        window.location.replace("http://localhost:1329/");
    }
    else
    {
        ErrorBoxHandler();
    }
});
