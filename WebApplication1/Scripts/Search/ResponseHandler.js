function ResponseHandler(data)
{
    if (data.length == 0)
    {
        $("#error_box").show();
        $("#search_result").hide();  
    }
    else
    {
        var html = "";
        $("#error_box").hide();
        $("#search_result").show();  
        $.each(data, function (key, val) {
            item = val;
            html +=
                "<tr id = " + item.TariffId + ">" +
                 "<td>" + item.TariffName + "</td >" +
                "<td>" + item.Price + "</td>" +  
                "</tr>";
        });
        $('#allTariffs').html(html);
    }
}