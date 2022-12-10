(function(window, undefined) {
  'use strict';

  /*
  NOTE:
  ------
  PLACE HERE YOUR OWN JAVASCRIPT CODE IF NEEDED
  WE WILL RELEASE FUTURE UPDATES SO IN ORDER TO NOT OVERWRITE YOUR JAVASCRIPT CODE PLEASE CONSIDER WRITING YOUR SCRIPT HERE.  */

})(window);

$(".checkBoxValue").on('change', function () {
    let data = $(this).data("input");
    let input = $(`#${data}`);
    console.log(input)
    if ($(this).is(':checked')) {
        input.val("true");
    } else {
        input.val("false");
    }
    console.log($(this).val());
});

