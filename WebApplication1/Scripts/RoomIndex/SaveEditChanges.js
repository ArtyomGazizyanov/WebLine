var roomId = getUrlParameter("roomId");
$("#edit_Form").submit(function (event)
{
    event.preventDefault();
    $("#error_box").hide();
    if (isInputValid()) {
        var hotel =
            {
                RoomId: roomId,
                HotelId: hotelId,
                Name: $("#Name").val(),
                AdultBeds: $("#AdultBeds").val(),
                ChildrenBeds: $("#ChildrenBeds").val(),
                State: $("#State").val()
            };

        var json = $.getJSON(hotel);
        $.ajax({
            type: "PUT",
            data: JSON.stringify(hotel),
            dataType: "json",
            url: "http://localhost:1329/api/RoomApi/",
            contentType: "application/json",
            success: function (data) {
                console.log(json);
                window.location.replace("http://localhost:1329/Room?hotelId=" + hotelId);
            }
        });

        console.log(json);
        window.location.replace("http://localhost:1329/Room?hotelId=" + hotelId);
    }
    else
    {
        ErrorBoxHandler();
    }
});
