$(function() {
	$('.custom_tags [what="smallCity"]').css("color", "blue");
	$('.custom_tags [what="bigCity"]').css("color", "green");
        
    $('form').submit(function(e) {
		e.preventDefault();
		var cities = [];
		
		$(this).find('input:checked').each(function() {
			var checkboxId = $(this).attr('id'),
				labelText = $('label[for="' + checkboxId + '"]').text();
			cities.push(labelText);
		});
		
		if (cities.length > 0) {
			noty({
				text: '<span class="noty-message">' + cities.join(', ') + '</span>',
				type: 'success',
				layout: 'topCenter',
				timeout: 3000
			});
        }
    });

	$('pre').addClass('prettyprint');
    prettyPrint();
});