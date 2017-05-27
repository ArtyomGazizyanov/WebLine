var hotelId = getUrlParameter("hotelId");
var href = '/Room?hotelId=' + hotelId;
var backButton = "<a href=" + href + "> Back to List</a>";
$("#back_to_list").append(backButton);
