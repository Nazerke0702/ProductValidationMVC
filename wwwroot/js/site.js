// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Болашақ өндірілген күнге клиенттік тексеру адаптері.
(function ($) {
    if (!$ || !$.validator || !$.validator.unobtrusive) return;

    $.validator.addMethod("futuredate", function (value, element) {
        if (!value) return true;
        const selected = new Date(value + "T00:00:00");
        const today = new Date();
        today.setHours(0, 0, 0, 0);
        return !Number.isNaN(selected.getTime()) && selected <= today;
    });

    $.validator.unobtrusive.adapters.addBool("futuredate");
})(window.jQuery);
