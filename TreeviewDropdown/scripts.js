(function() {
    var demo = window.demo = window.demo || {};
    var isEnabled = false;

    function disableConversationWindow() {
        if (!demo.$conversationWindow.hasClass()) {
            demo.$conversationWindow.addClass("disabled");

            demo.messageButton.set_enabled(false);
            demo.callButton.set_enabled(false);

            demo.$name.text("");
            demo.$mail.text("");
            demo.$phone.text("");

            demo.imageHolder.style.backgroundImage = "url('images/default.png')";
        }
    }

    function enableConversationWindow() {
        demo.$conversationWindow.removeClass("disabled");

        demo.messageButton.set_enabled(true);
        demo.callButton.set_enabled(true);
    }

    window.onClientClearButtonClicked = function(sender, args) {
        disableConversationWindow();
        isEnabled = false;
    };

    window.onClientEntryAdded = function(sender, args) {
        if (!isEnabled)
            enableConversationWindow();

        var entry = args.get_entry(),
            values = entry.get_value().split("_"),
            imageUrl = "images/" + values[0] + ".jpg",
            name = entry.get_text(),
            mail = values[1],
            phone = values[2];

        demo.imageHolder.style.backgroundImage = "url('" + imageUrl + "')";
        demo.$name.text(name);
        demo.$mail.text(mail);
        demo.$phone.text(phone);

        isEnabled = true;
    };
}())