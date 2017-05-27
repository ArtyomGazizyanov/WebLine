 
/* DELETE */
$("table").on("click", ".delete_button", function ()
{
        var roomId = $(this).parent().parent().attr('id');
        $.ajax({
            url: "http://localhost:1329/api/RoomApi/" + roomId,
            type: "DELETE",
            contentType: "application/json",
            success: function ()
            {
                console.log("Proposal deleted successfully. DELETED = " + roomId);
                $(this).parent().slideUp();
            },
            error: function ()
            {
                console.log("Error on delete");
            }
        });
        $(this).parent().parent().slideUp();
});

    /*EDIT*/
$("table").on("click", ".edit_button", function ()
{
    var roomId = $(this).parent().parent().attr('id');
    var hotelId = getUrlParameter("hotelId");
    window.location.replace("http://localhost:1329/Edit/Room?hotelId=" + hotelId + "&roomId=" + roomId );
}); 

/*ADD*/
$(".add_button").click(function ()
{
    console.log();
var hotelId = getUrlParameter("hotelId");
    window.location.replace("http://localhost:1329/Add/Room?hotelId=" + hotelId);
}); 

/*BACK_TO_MENU*/
$(".row").on("click", ".back_button", function ()
{
    console.log();
window.location.replace("http://localhost:1329");
}); 
