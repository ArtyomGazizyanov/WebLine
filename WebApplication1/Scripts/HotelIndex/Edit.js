$("table").on("click", ".edit_button", function () {
    var roomId = $(this).parent().parent().attr('id');
    var hotelId = getUrlParameter("hotelId");
    window.location.replace("http://localhost:1329/Edit/Room?hotelId=" + hotelId + "&roomId=" + roomId);
}); 
