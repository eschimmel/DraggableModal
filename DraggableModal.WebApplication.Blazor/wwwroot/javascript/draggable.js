function setPosition(element, startClientX, startClientY, clientX, clientY) {
    var left = parsePosition(element.style.left);
    var top = parsePosition(element.style.top);

    element.style.left = (left + (clientX - startClientX)) + "px";
    element.style.top = (top + (clientY - startClientY)) + "px";
}

function parsePosition(str) {
    if (str !== null && str !== undefined && str.length) {
        return parseInt(str.replace("px", ""), 10);
    }

    return 0;
}

function resetPosition(element) {
    element.style.left = "0px";
    element.style.top = "0px";
}