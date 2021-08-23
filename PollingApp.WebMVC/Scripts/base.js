var currentIndex = 0;

function indexIterate() {
    var newHref = $("#addChoice").attr("href");
    var newerHref = newHref.replace(/(?:index=)[0-9]+/i, "index=" + ++currentIndex);
    $("#addChoice").attr("href", newerHref);
};
