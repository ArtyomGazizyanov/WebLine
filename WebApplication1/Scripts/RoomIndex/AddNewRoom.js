var roomId = getUrlParameter("roomId");
$("#edit_Form").submit(function (event)
{
    event.preventDefault();
    $("#error_box").hide();
    if (isInputValid()) {
        var room =
            {
                RoomId: roomId,
                HotelId: hotelId,
                Name: $("#Name").val(),
                AdultBeds: $("#AdultBeds").val(),
                ChildrenBeds: $("#ChildrenBeds").val(),
                State: $("#State").val()
            };

        var json = $.getJSON(room);
        $.ajax({
            type: "Post",
            data: JSON.stringify(room),
            dataType: "json",
            url: "http://localhost:1329/api/RoomApi/",
            contentType: "application/json",
            success: function (data) {
                console.log();
                window.location.replace("http://localhost:1329/Room?hotelId=" + hotelId);
            }
        });
        console.log();
        window.location.replace("http://localhost:1329/Room?hotelId=" + hotelId);
    }
    else
    {
        ErrorBoxHandler();
    }
 });
