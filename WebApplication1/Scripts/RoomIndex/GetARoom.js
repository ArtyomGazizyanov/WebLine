var hotelId = getUrlParameter("hotelId");
var roomId = getUrlParameter("roomId");
$(document).ready(function ()
{
    $.ajax({
        url: "http://localhost:1329/api/RoomApi/" + hotelId + "/" + roomId,
        type: "Get",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (data)
        {
            item = JSON.parse(data);
            $("#Name").val(item.Name);
            $("#AdultBeds").val(item.AdultBeds);
            $("#ChildrenBeds").val(item.ChildrenBeds);
            $("#State").val(item.State);                
        }
    });
});
