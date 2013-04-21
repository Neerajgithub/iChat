$(document).ready(function () {
    var settingsView = { containerResizeSpeed: 350, containerWidth: 700, containerHeight: 500
    };

    var settingsEdit = { containerResizeSpeed: 350, containerWidth: 700, containerHeight: 500
    };

    $('.aGVLinkView').popUpBox(settingsView);
    $('.aGVLinkEdit').popUpBox(settingsEdit);
});