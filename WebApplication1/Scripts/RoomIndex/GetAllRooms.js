 var hotelId = getUrlParameter("hotelId");
 $(document).ready(function ()
 {
    $.ajax({
        url: "http://localhost:1329/api/RoomApi/" + hotelId,
        type: "Get",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (data) {
            html = "";
            if (data.length != 0) {
                $.each(JSON.parse(data), function (key, val)
                {
                    item = val;
                    html +=
                        "<tr id = " + item.RoomId + ">" +
                        "<td>" + item.Name + "</td >" +
                        "<td>" + item.AdultBeds + "</td>" +
                        "<td>" + item.ChildrenBeds + "</td>" +
                        "<td>" + item.State + "</td>" +
                        "<td> <div class='delete_button btn btn-primary btn-lg'>Удалить</div>" +
                        "<div class='edit_button btn btn-primary btn-lg'>Изменить</div> </td>" +
                        "</tr>";
                });
                $('#messege_box').hide();
                $('#allHotels').html(html);
            }
            else
            {
                html += "<h3>У данного отеля нет номеров</h3>" +
                    "<div class='back_button btn btn-primary btn-lg'>Назад</div>";
                $(".table_room").hide();
                $('#messege_box').html(html);
            }
        }
    });
});
