var id = getUrlParameter("id");
$(document).ready(function ()
{
    $.ajax
    ({
        url: "http://localhost:1329/api/Hotel/" + id,
        type: "Get",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (data)
        {          
            item = JSON.parse(data);
            $("#Name").val(item.Name);
            $("#Phone").val(item.Phone);
            $("#Address").val(item.Address);
            $("#Email").val(item.Email);
            $("#State").val(item.State);          
        }
    });
}); 
