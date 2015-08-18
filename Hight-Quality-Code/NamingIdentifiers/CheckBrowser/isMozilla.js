function checkIsBrowserIsMozilla(event, arguments) {
    var myWindow = window,
        currentBrowser = myWindow.navigator.appCodeName,
        isMozilla = (currentBrowser == "Mozilla");

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}