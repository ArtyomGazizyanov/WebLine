$("#edit_Form").submit(function (event)
{
    event.preventDefault();
    $("#error_box").hide();
    if (isInputValid())
    {
        var hotel = {
            Name: $("#Name").val(),
            Address: $("#Address").val(),
            Phone: $("#Phone").val(),
            Email: $("#Email").val(),
            State: $("#State").val()
        };
        var json = $.getJSON(hotel);
        $.ajax({
            type: "POST",
            data: JSON.stringify(hotel),
            dataType: "json",
            url: "http://localhost:1329/api/Hotel/",
            contentType: "application/json",
            success: function (data) {
                window.location.replace("http://localhost:1329/");

            }
        }); 
        window.location.replace("http://localhost:1329/");
    }
    else
    {
        ErrorBoxHandler();
    }
});
