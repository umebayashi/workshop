$(function () {
	var onLoad = function () {
		$('#SearchResourceTypeID').empty();
		$('#SearchResourceID').empty();

		$.getJSON(
			'/Scheduler/ResourceReserve/GetResourceTypes',
			null,
			function (data, textStatus) {
				$('#SearchResourceTypeID').append('<option></option>');
				for (var i = 0; i < data.length; i++) {
					$('#SearchResourceTypeID').append('<option value="' + data[i].id + '">' + data[i].name + '</option>');
				}
			}
		);
	}

	var onResourceTypeChanged = function () {
	    $('#SearchResourceID').empty();
		$('#EditSection').hide();

		var selected = $('#SearchResourceTypeID option:selected')[0];
		if ((selected != 'undefined') && (selected.value != "")) {
			$.getJSON(
				'/Scheduler/ResourceReserve/GetResources',
				{ strResourceTypeID: selected.value },
				function (data, textStatus) {
					$('#SearchResourceID').append('<option></option>');
					for (var i = 0; i < data.length; i++) {
						$('#SearchResourceID').append('<option value="' + data[i].id + '">' + data[i].name + '</option>');
					}
				}
			);
		}
	}

	onLoad();

	$('#SearchResourceTypeID').change(onResourceTypeChanged);
});

