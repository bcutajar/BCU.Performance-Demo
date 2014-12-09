(function () {
    var input = $('.navbar-brand')[0].innerHTML;

    $.get('home/GetAwesomness', { awesomeString: input })
    .done(function (data) {
        alert(data.TheBestString);
        alert(data.AnEvenBetterString);
    });
})();