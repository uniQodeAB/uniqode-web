/*global require: false, Element: false*/
(function (window) {
    'use strict';

    // some shortcuts
    if (!Element.prototype.on) {
        Element.prototype.on = function (ev, cb) {
            this.addEventListener(ev, cb, false);
        };
    }
    window.document.on = Element.prototype.on;

    // uniQode logic
    var uniQode = {
        adminAction: function (stateName, state) {
            if (location.href.indexOf(stateName) > 0) {
                return;
            }
            location.href = location.href + (location.href.indexOf('?') > 0 ? '&' : '?') + stateName + '=' + state;
        },
        confirmRemoval: function (e, obj) {
            if (!obj)
                obj = 'entry';

            if (!confirm('Confirm removal of ' + obj + '?'))
                e.preventDefault();
        }
    };

    // when all is loaded
    window.document.on('DOMContentLoaded', function () {
        window.uniQode = uniQode;
    });
}(window));