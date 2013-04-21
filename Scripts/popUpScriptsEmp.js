$(document).ready(function () {
    var settingsView = { containerResizeSpeed: 350, containerWidth: 700, containerHeight: 800
    };

    var settingsEdit = { containerResizeSpeed: 350, containerWidth: 700, containerHeight: 900
    };

    $('.aGVLinkView').popUpBox(settingsView);
    $('.aGVLinkEdit').popUpBox(settingsEdit);
});