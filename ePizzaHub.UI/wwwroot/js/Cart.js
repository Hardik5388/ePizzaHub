function AddToCart(ItemId, Name, UnitPrice, Quantity) {
    $.ajax({
        type: 'GET',
        url: '/cart/addtocart/' + ItemId + "/" + UnitPrice + "/" + Quantity,
        contentType: 'application/json',
        success: function (d) {
            var data = d.length > 0 ? JSON.parse(d) : null;
            if (data != null && data.CartItems.length > 0) {
                $('.noti_Counter').text(data.CartItems.length);
                var message = '<strong>' + Name + '</strong> added to <a href="/cart">Cart</a> successfully';
                $('#toastCart > .toast-body').html(message);
                $('#toastCart').toast('show');

                setTimeout(function () {
                    $('#toastCart').toast('hide');
                }, 4000);
            }
        }

    });
}