$(document).ready(function () {
    $.ajax({
        url: "http://localhost:1329/api/Hotel",
        type: "Get",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (data)
        {
            console.log("DATA JSON = " + data);
            html = "";
            if (data.length != 0) {
                $.each(JSON.parse(data), function (key, val)
                {
                    item = val;
                    html +=
                        "<tr id = " + item.HotelId + ">" +
                        "<td>" + item.Name + "</td >" +
                        "<td>" + item.Phone + "</td>" +
                        "<td>" + item.Address + "</td>" +
                        "<td>" + item.Email + "</td>" +
                        "<td>" + item.State + "</td>" +
                        "<td> <div class='delete_button btn btn-primary btn-lg'>Удалить</div>" +
                        "<div class='edit_button btn btn-primary btn-lg'>Изменить</div>" +
                        "<div class='rooms_button btn btn-primary btn-lg'>Номера</div> </td>" +
                        "</tr>";
                });

                $('#allHotels').html(html);
                $('#messege_box').hide();
            }
            else
            {
                html += "<h3>Отели не найдены</h3>";
                $(".table_room").hide();
                $('#messege_box').html(html);
            }
        }

    });
}); 
