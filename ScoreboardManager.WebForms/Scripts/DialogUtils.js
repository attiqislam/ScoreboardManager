///Dependent on followings:

/// <reference path="jquery-3.3.1.js" />
/// <reference path="../resources/node_modules/pnotify/dist/iife/pnotify.js" />

function ShowNotificationDialog(message, title, type) {
    type = type.toLowerCase();

    if (typeof window.stackTopCenter === 'undefined') {
        window.stackTopCenter = {
            'dir1': 'down',
            'firstpos1': 25
        };
    }

    var opts = {
        title: title,
        text: message,
        stack: window.stackTopCenter
    };

    switch (type) {
        case 'notice':
            opts.type = type;
            PNotify.notice(opts);
            break;
        case 'info':
            opts.type = type;
            PNotify.info(opts);
            break;
        case 'success':
            opts.type = type;
            PNotify.success(opts);
            break;
        case 'error':
            opts.type = type;
            opts.hide = false;
            PNotify.error(opts);
            break;
    }
}
