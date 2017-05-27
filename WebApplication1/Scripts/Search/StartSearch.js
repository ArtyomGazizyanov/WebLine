 jQuery("#send").click(function(event)
{
    $("#search_result").hide();  

    if (isInputValid())
    {
        $("#search_result").show();  
        var SearchParams = new Array;
        var SearchRequest =
        {
            HotelName: $("#HotelName").val(),
            RoomName: $("#Room").val(),
            Date: $("#Date").val()
        };
        //SearchParams.push($("#HotelName").val());
        //SearchParams.push($("#Room").val());
        //SearchParams.push($("#Date").val());

        console.log(JSON.stringify(SearchRequest));
        $.ajax({
            type: "POST",
            data: JSON.stringify(SearchRequest),
            dataType: "json",
            url: "http://localhost:1329/Search/Send/",
            contentType: "application/json",
            success: function (data)
            {
                //console.log("!" + JSON.stringify(data) + "!");
                ResponseHandler(data);
            },
            error: function (data) {
                console.log("!" + JSON.stringify(data) + "!");                
            }
        }); 
    }
    else
    {
        $("#search_result").hide();  
        $("#error_box").show();
        $("#error_box span").html("Заполните все поля!") ;
    }
    
});