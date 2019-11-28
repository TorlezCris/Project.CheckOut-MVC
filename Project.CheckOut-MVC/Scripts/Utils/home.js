$(document).ready(function () {
	var ii = 0, j = 0;

	var navListItems = $('div.setup-panel div a'),
		allWells = $('.setup-content'),
		allNextBtn = $('.nextBtn');
	
	var validado = false;
	var actual = null;
	var inicial = $(navListItems[0]).attr('id');

	var navList = $('div.setup-panel div a'),
		allWell = $('.setup-content'),
		allPasosBtn = $('.paso');

	allWells.hide();

	navList.click(function () {
		var $target = $($(this).attr('href')),
			$item = $(this);
		actual = $item.attr('id');
		if (inicial !== actual) {
			validado = false;
			console.log("actual " + JSON.stringify(actual) + " validado " + validado + " inicial " + inicial);
		}
		else {
			validado = true;
			console.log("validado " + validado + " inicial " + inicial);
		}

		allWell.hide();
		$target.show();
		$target.find('input:eq(0)').focus();
	});

	navListItems.click(function (e) {
		console.log("i = " + ii);
		e.preventDefault();

		if (validado) {
			console.log("into validado navListItems");
			var $target = $($(this).attr('href')),
				$item = $(this);


			console.log("ifsaso " + $item.attr('id') + " segundo " + $(navListItems[ii]).attr('id') + " i " + ii);
			console.log("actual " + JSON.stringify(actual) + " validado " + validado + " inicial " + inicial);
			if (!$item.hasClass('disabled')) {
				//navListItems.removeClass('btn-primary').addClass('btn-default');

				if ($item.attr('id') !== $(navListItems[ii]).attr('id')  && ii<2) {
					$(navListItems[ii]).removeClass('btn-primary').addClass('btn-success');
					console.log("ifsaso " + $item.attr('id') + " segundo " + $(navListItems[ii]).attr('id') + " i " + ii);

					ii++;
				}
				
				//$('#item3').addClass('btn-success');
				$item.addClass('btn-primary');
				allWells.hide();
				$target.show();
				$target.find('input:eq(0)').focus();
			}
		}
	});

	allNextBtn.click(function (e) {
		//if (validado) {
			
			console.log("into validado allNextBtn");
			var curStep = $(this).closest(".setup-content"),
				curStepBtn = curStep.attr("id"),
				nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
				curInputs = curStep.find("input[type='text'],input[type='password'], input[type='email']"),
				isValid = true;

			$(".form-group").removeClass("has-error");
			for (var i = 0; i < curInputs.length; i++) {
				if (!curInputs[i].validity.valid) {
					isValid = false;
					$(curInputs[i]).closest(".form-group").addClass("has-error");
				}
			}


			if (ii < 2) {
				inicial = $(navListItems[ii + 1]).attr('id');

				if (isValid)
					nextStepWizard.removeAttr('disabled').trigger('click');
			}
			else {

				inicial = $(navListItems[2]).attr('id');
				console.log("actual " + JSON.stringify(actual) + " validado " + validado + " inicial " + inicial);

				if (isValid)
					$(navListItems[2]).removeClass('btn-primary').addClass('btn-success');
			}
			console.log("actual " + JSON.stringify(actual) + " validado " + validado + " inicial " + inicial);

		//}
	});

	$('div.setup-panel div a.btn-primary').trigger('click');
});