/* DELETE */
$("table").on("click", ".delete_button", function () {
    var hotelId = $(this).parent().parent().attr('id');
    $.ajax({
        url: "http://localhost:1329/api/Hotel/" + hotelId,
        type: "DELETE",
        contentType: "application/json",
        success: function () {
            console.log("Proposal deleted successfully. DELETED = " + hotelId);
            $(this).parent().slideUp();
        },
        error: function () {
            console.log("Error on delete");
        }
    });

    $(this).parent().parent().slideUp();
});

/*EDIT*/
$("table").on("click", ".edit_button", function () {
    var hotelId = $(this).parent().parent().attr('id');
    window.location.replace("http://localhost:1329/Edit/Hotel?id=" + hotelId);
});

/*ROOMS*/
$("table").on("click", ".rooms_button", function () {
    var hotelId = $(this).parent().parent().attr('id');
    window.location.replace("http://localhost:1329/Room?hotelId=" + hotelId);
});
