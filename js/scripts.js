$(function() {
    $('.custom_tags [what="smallCity"]').css("color", "blue");
    $('.custom_tags [what="bigCity"]').css("color", "green");

    var url = 'http://mvccbl.azurewebsites.net/examples-content';
    //var url = 'http://localhost:52997/examples-content';

    loadExamplesData();

    function loadExamplesData() {
        $.get(url, function(data) {
            setContainerData(data);
            setFormSubmit();
        });
    }

    function setFormSubmit() {
        $('form').submit(function(e) {
            e.preventDefault();

            var postData = $(this).serialize();

            $.post(url, postData, function(data) {
                setContainerData(data);
                setFormSubmit();
            });
        });
    }

    function setContainerData(data) {
        $('.examples-container').empty().append(data);

        $('form').each(function(element) {
            $(this).attr('action', url);
        });
    }
});