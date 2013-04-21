$(document).ready(function () {
    var settingsView = { containerResizeSpeed: 350, containerWidth: 700, containerHeight: 880
    };

    var settingsEdit = { containerResizeSpeed: 350, containerWidth: 700, containerHeight: 1000
    };

    $('.aGVLinkView').popUpBox(settingsView);
    $('.aGVLinkEdit').popUpBox(settingsEdit);
});