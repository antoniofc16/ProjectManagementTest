window.clipboardCopy = {
    copyText: function (text) {
        navigator.clipboard.writeText(text).then(function () {
            console.log("Copied to clipboard!");
        })
            .catch(function (error) {
                console.log(error);
            });
    }
};

window.menuToggle = () => {
    var menuHolder = document.getElementById('menuHolder');
    var siteBrand = document.getElementById('siteBrand');

    if (menuHolder.className === "drawMenu") menuHolder.removeAttribute("class");
    else menuHolder.setAttribute("class", "drawMenu");
}
