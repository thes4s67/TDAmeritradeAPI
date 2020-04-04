$(document).ready(function () {
    $('#searchQuote').on("click", function () {
        var symbol = $('#symbol').val();
        $.post('/api/endpoint/quote/' + symbol.toUpperCase(),
            function (data) {
                $('#quoteTA').val('');
                if (data.success === true) {
                    $('#quoteTA').val('Symbol: ' + data.quote.quotes[0].symbol + '\nDescription: ' + data.quote.quotes[0].description + '\nLast Price: ' + data.quote.quotes[0].lastPrice);
                } else {
                    $('#quoteTA').val('Something failed...');
                }
            });
    });
});